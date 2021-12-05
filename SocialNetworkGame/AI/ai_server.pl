% Libraries
:- use_module(library(http/thread_httpd)).
:- use_module(library(http/http_dispatch)).
:- use_module(library(http/http_parameters)).
:- use_module(library(http/http_open)).
:- use_module(library(http/http_cors)).
:- use_module(library(date)).
:- use_module(library(random)).
:- use_module(library(http/http_client)).

% JSON Libraries
:- use_module(library(http/json_convert)).
:- use_module(library(http/http_json)).
:- use_module(library(http/json)).
:- use_module(library(http/http_open)).

% Primary knowledge base



% Secundary knowledge base
:- dynamic relationship1/2.

% HTTP Server setup at 'Port'                           
startServer(Port) :-   
        http_server(http_dispatch, [port(Port)]),
        asserta(port(Port)).

% Server startup
start_server:-
    consult(ai_server_config),  % Loads server's configuration
    server_port(Port),
    startServer(Port).

% Shutdown server
stopServer:-
        retract(port(Port)),
        http_stop_server(Port,_).

% Server init
:- start_server.

% HTTP Requests
:- http_handler('/api/network/size', computeSocialNetworkSize, []).
:- http_handler('/shortestPath', shortestPathRoute, []).
:- http_handler('/api/network/saferPath', saferPathRoute, []).


% Methods

%================== Geral Use ======================%

getSocialNetworkHostPort(Host, Port) :-
    module_socialnetwork_host(Host),
    module_socialnetwork_port(Port).

%======== Size of a Player's Social Network ========%

computeSocialNetworkSize(Request) :-
    getPlayerSocialNetwork(Request, Size),
    reply_json(Size).

getPlayerSocialNetwork(Request, Size) :-
    http_parameters(Request, [email(Email, [string]), depth(Depth, [number])]),
    getSocialNetworkHostPort(Host, Port),
    atom_concat('/api/Relationships/network/',Email,X),
    atom_concat(X, '/',Y),
    atom_concat(Y,Depth,Path),
    http_open([host(Host), port(Port), path(Path)], Stream, [cert_verify_hook(cert_accept_any)]),
    json_read_dict(Stream, Data),
    close(Stream),
    createSocialNetworkTerms(Data),
    compute_network_size(Data.PlayerId, Depth, Size),
    retractall(relationship1(_,_)). % Delete all relationships generated

createSocialNetworkTerms(Data) :-
    setPlayerSocialNetworkTerms(Data, Data.relationships).

setPlayerSocialNetworkTerms(Player, []).

setPlayerSocialNetworkTerms(Player, [PlayerX]) :-
    setPlayerSocialNetworkTerms(PlayerX, PlayerX.relationships),
    asserta(relationship1(Player.PlayerId, PlayerX.PlayerId)).

setPlayerSocialNetworkTerms(Player, [PlayerX|Relationships]) :-
    setPlayerSocialNetworkTerms(Player, Relationships),
    asserta(relationship1(Player.PlayerId, PlayerX.PlayerId)).

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

connection(PlayerX, PlayerY) :-
    relationship1(PlayerX, PlayerY);
    relationship1(PlayerY, PlayerX).

compute_network_size(Player, Level, Size) :-
    compute_network_size1(1, Level, [Player], Size1),
    Size is Size1 - 1.

compute_network_size1(CurrentLevel, LimitLevel,AllPlayers,Size) :-
    LimitLevel > CurrentLevel,
    add_all_level1_connections(AllPlayers, AllPlayers1),
    CurrentLevel1 is CurrentLevel + 1,
    compute_network_size1(CurrentLevel1, LimitLevel, AllPlayers1, Size),
    !.

compute_network_size1(_, _, AllPlayers, Size) :-
        length(AllPlayers, Size),
        !.

level1_connections(Player, AllFriends) :-
    findall(Friends, connection(Player, Friends), AllFriends).

add_all_level1_connections([], []).

add_all_level1_connections([H|T], X) :-
    add_all_level1_connections(T, K),
    level1_connections(H, N),
    append_new([H|N], K, X).

append_new([], X, X).

append_new([X|Y], Z, [X|W]):-
    append_new(Y, Z, W),
    \+ member(X, W),
    !.

append_new([_|Y], Z, W):-
    append_new(Y, Z, W).  


%======== Shortest Path Between Two Users ========%


% define shortest path route %
shortestPathRoute(Request):-
    cors_enable,
    http_parameters(Request, [ userFrom(From, []), userDest(Dest, [])]),
    to_lowercase(From, NormalizedUserFrom),
    to_lowercase(Dest, NormalizedUserDest),
    plan_shortestPath(NormalizedUserFrom, NormalizedUserDest, LCaminho_shortestway),
    R = json(["Path"=LCaminho_shortestway]),
    reply_json_dict(R).

% conversion to lowercase %
to_lowercase(User, UserNormalized):-
    string_lower(User, Low),
    normalize_space(atom(UserNormalized),Low).

plan_shortestPath(Orig, Dest, LCaminho_shortestway) :-

        (melhor_caminho_minimo(Orig, Dest);true),
        retract(caminho_minimo(LCaminho_shortestway,_)),
        nl.

melhor_caminho_minimo(Orig, Dest):-
        asserta(caminho_minimo(_,10000)),
        dfs(Orig, Dest,LCaminho),
        atualiza_melhor_caminho_minimo(LCaminho),
        fail.

atualiza_melhor_caminho_minimo(LCaminho):-
        caminho_minimo(_,N),
        length(LCaminho,C),
        C<N,
        retract(caminho_minimo(_,_)),
        asserta(caminho_minimo(LCaminho,C)).


dfs(Orig,Dest,Cam):-dfs2(Orig,Dest,[Orig],Cam).

dfs2(Dest,Dest,LA,Cam):-!,
        reverse(LA,Cam).

dfs2(Act,Dest,LA,Cam):-
        no(NAct,Act,_),
        (ligacao(NAct,NX,_,_) ; ligacao(NX,NAct,_,_)),
        no(NX,X,_),
        \+ member(X,LA),
        dfs2(X,Dest,[X|LA],Cam).

%===================================================%

%======== Strongest Path Between Two Users ========%

stronger_path(Orig,Dest,LCaminho_forlig):-
    get_time(Ti),
    (best_path(Orig,Dest);true),
    retract(best_solution(LCaminho_forlig,S)),
    get_time(Tf),
    T is Tf-Ti,
    write('Time :'),write(T),nl,
    write('Sum of Binding Forces :'),write(S),nl,
    write('Solution :'),write(LCaminho_forlig),nl.

best_path(Orig,Dest):-
    asserta(best_solution(_,0)),
    dfs_force(Orig,Dest,LCaminho,S),
    best_new_path(LCaminho,S),
    fail.

best_new_path(LCaminho,S):-
    best_solution(_,N),
    S>N,retract(best_solution(_,_)),
    asserta(best_solution(LCaminho,S)).

dfs_force(Orig,Dest,Cam,S):-
    dfs_2_force(Orig,Dest,[Orig],Cam,S).

dfs_2_force(Dest,Dest,LA,Cam,0):-!,reverse(LA,Cam).
dfs_2_force(Act,Dest,LA,Cam,S):-no(NAct,Act,_),(ligacao(NAct,NX,S1,S2);ligacao(NX,NAct,S1,S2)),
no(NX,X,_),\+ member(X,LA),dfs_2_force(X,Dest,[X|LA],Cam,SX),S is (SX+S1+S2) .



%======== Safer path route calculation =============%

% no(1,'Joao',[]).
% no(2,'Miguel',[]).
% no(3,'Francisco',[]).
% no(4,'Andre',[]).
% 
% relationship(1,2,9,1).
% relationship(1,3,4,5).
% relationship(2,4,9,9).
% relationship(3,4,7,6).

:- http_handler('/api/network/saferPath', saferPathRoute, []).


% (caminho, somatorio_forças, força_ligaçao_minima)
:- dynamic best_solution_safe_path/3.


safest_path(Orig,Dest,Min_strength,LCaminho_forlig):-
    (find_safest_path(Orig,Dest,Min_strength);true),
    retract(best_solution_safe_path(LCaminho_forlig,S,M)),
    write('Sum of strengths: '),write(S),nl,
    write('Minimum strength: '),write(M),nl,
    write('Path: '),write(LCaminho_forlig),nl.

find_safest_path(Orig,Dest,Min_strength):-
    asserta(best_solution_safe_path(_,0,Min_strength)),
    dfs_safe(Orig,Dest,LCaminho,S,M),
    check_safe_path(LCaminho,S,M),
    fail.

check_safe_path(LCaminho,S,M):-
    best_solution_safe_path(_,N,OM),
    (M>OM;(M=OM,S>N)),
    retract(best_solution_safe_path(_,_,_)),
    asserta(best_solution_safe_path(LCaminho,S,M)).


%%% apenas sentido da travessia
dfs_safe_apenas_sentido_travessia(Orig,Dest,Cam,S,M):-
    dfs_safe_apenas_sentido_travessia_2(Orig,Dest,[Orig],Cam,S,M).

dfs_safe_apenas_sentido_travessia_2(Dest,Dest,LA,Cam,0,1000):-
    !,
    reverse(LA,Cam).

dfs_safe_apenas_sentido_travessia_2(Act,Dest,LA,Cam,S,M):-
    no(NAct,Act,_),
    ((relationship(NAct,NX,S1,S2),F is S1);(relationship(NX,NAct,S1,S2),F is S2)),
    no(NX,X,_),
    \+ member(X,LA),
    dfs_safe_apenas_sentido_travessia_2(X,Dest,[X|LA],Cam,SX, MX),
    S is (SX+F),
    M is min(MX,F).


%%% 2 sentidos
dfs_safe(Orig,Dest,Cam,S,M):-
    dfs_safe_2(Orig,Dest,[Orig],Cam,S,M).

dfs_safe_2(Dest,Dest,LA,Cam,0,1000):-
    !,
    reverse(LA,Cam).

dfs_safe_2(Act,Dest,LA,Cam,S,M):-
    no(NAct,Act,_),
    (relationship(NAct,NX,S1,S2);relationship(NX,NAct,S1,S2)),
    no(NX,X,_),
    \+ member(X,LA),
    F is min(S1,S2),
    dfs_safe_2(X,Dest,[X|LA],Cam,SX, MX),
    S is (SX+S1+S2),
    M is min(MX, F).

