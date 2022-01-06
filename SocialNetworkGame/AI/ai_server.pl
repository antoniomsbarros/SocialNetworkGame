% Libraries
:- use_module(library(http/thread_httpd)).
:- use_module(library(http/http_dispatch)).
:- use_module(library(http/http_parameters)).
:- use_module(library(http/http_open)).
:- use_module(library(http/http_cors)).
:- use_module(library(date)).
:- use_module(library(random)).
:- use_module(library(http/http_client)).
:- use_module(library(http/http_ssl_plugin)).

% JSON Libraries
:- use_module(library(http/json_convert)).
:- use_module(library(http/http_json)).
:- use_module(library(http/json)).
:- use_module(library(http/http_open)).

% Primary knowledge base


% Secundary knowledge base
:- dynamic relationship1/2.
:- dynamic users_combination/2.
:- dynamic best_solution_bidirectional/2.
:- dynamic best_solution_unidirectional/2.
:- dynamic best_solution_safe_path/3.

% Server startup                          
start_server :-
    load_local_modules,
    server_port(Port),
    certificate_file_path(Certificate_Path),
    key_file_path(Key_Path),
    http_server(http_dispatch,
                [ port(Port),
                  ssl([ certificate_file(Certificate_Path),
                        key_file(Key_Path)
                      ])
                ]),
    asserta(port(Port)).

% Shutdown server
stopServer :-
        retract(port(Port)),
        http_stop_server(Port,_).

% Services
load_local_modules :-
    consult(ai_server_config),  % Loads server's configuration
    consult(services/geral_use),
    consult(services/compute_socialnetwork_size).

% Server init
:- start_server.

% HTTP Requests
:- http_handler('/shortestPath', shortestPathRoute, []).
:- http_handler('/api/network/saferPath', saferPathRoute, []).
:- http_handler('/api/tagsincommon', computePlayerWithXTagsInCommon, []).

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

%==================================================%

%======== Strongest Path Between Two Users ========%

%===== Unidirectional =====%

strongest_path_unidirectional(Orig,Dest,Result):-
    get_time(Ti),
    (better_path_unidirectional(Orig,Dest);true),
    retract(best_solution_unidirectional(Result,Sum)),
    retract(counter(Counter)),
    get_time(Tf),
    T is Tf-Ti,
    write('Number of Solutions :'),write(Counter),nl,
    write('Solution generation time :'),write(T),nl,
    write('Solution binding strength :'),write(Sum),nl,
    write('Solution list :'),write(Result),nl.

strongest_path_unidirectionalServer(Orig,Dest,Result):-
    (better_path_unidirectional(Orig,Dest);true),
    retract(best_solution_unidirectional(Result,Sum)),
    retract(counter(Counter)).

better_path_unidirectional(Orig,Dest):-
    asserta(best_solution_unidirectional(_,0)),
    asserta(counter(0)),
    dfs_force_unidirectional(Orig,Dest,LCaminho,Sum),
    update_better_unidirectional(LCaminho,Sum),
    fail.

update_better_unidirectional(LCaminho,Sum):-
    retract(counter(NS)),
    NS1 is NS+1,
    asserta(counter(NS1)),
    best_solution_unidirectional(_,N),
    Sum>N,retract(best_solution_unidirectional(_,_)),
    asserta(best_solution_unidirectional(LCaminho,Sum)).


dfs_force_unidirectional(Orig,Dest,Cam,Sum):-
    dfs2_force_unidirectional(Orig,Dest,[Orig],Cam,Sum).

dfs2_force_unidirectional(Dest,Dest,LA,Cam,0):-
    !,
    reverse(LA,Cam).

dfs2_force_unidirectional(Act,Dest,LA,Cam,Sum):-
    no(NAct,Act,_),
    (ligacao(NAct,NX,S1,_);ligacao(NX,NAct,_,S1)),
    no(NX,X,_),
    \+ member(X,LA),
    dfs2_force_unidirectional(X,Dest,[X|LA],Cam,SX),
    Sum is (SX+S1).

%===== Bidirectional =====%

strongest_path_bidirectional(Orig,Dest,Result):-
    get_time(Ti),
    (best_path_bidirectional(Orig,Dest);true),
    retract(best_solution_bidirectional(Result,Sum)),
    retract(counter(Count)),
    get_time(Tf),
    T is Tf-Ti,
    write('Number of Solutions :'),write(Count),nl,
    write('Solution generation time :'),write(T),nl,
    write('Solution binding strength :'),write(Sum),nl,
    write('Solution list :'),write(Result),nl.

strongest_path_bidirectionalServer(Orig,Dest,Result):-
    (best_path_bidirectional(Orig,Dest);true),
    retract(best_solution_bidirectional(Result,Sum)),
    retract(counter(Count)).

best_path_bidirectional(Orig,Dest):-
    asserta(best_solution_bidirectional(_,-10000)),
    asserta(counter(0)),
    dfs_force_bidirectional(Orig,Dest,LCaminho,Sum),
    update_better_bidirectional(LCaminho,Sum),
    fail.

update_better_bidirectional(LCaminho,Sum):-
    retract(counter(NS)),
    NS1 is NS+1,
    asserta(counter(NS1)),
    best_solution_bidirectional(_,N),
    Sum>N,
    retract(best_solution_bidirectional(_,_)),
    asserta(best_solution_bidirectional(LCaminho,Sum)).

dfs_force_bidirectional(Orig,Dest,Cam,Sum):-
    dfs2_force_bidirectional(Orig,Dest,[Orig],Cam,Sum).

dfs2_force_bidirectional(Dest,Dest,LA,Cam,0):-
    !,
    reverse(LA,Cam).

dfs2_force_bidirectional(Act,Dest,LA,Cam,Sum):-
    no(NAct,Act,_),
    (ligacao(NAct,NX,S1,S2);ligacao(NX,NAct,S1,S2)),
    no(NX,X,_),
    \+ member(X,LA),
    dfs2_force_bidirectional(X,Dest,[X|LA],Cam,SX),
    Sum is (SX+S1+S2).

%===================================================%

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

%======== User with X tags in common ========%

computePlayerWithXTagsInCommon(Request) :-
    getPlayerWithXTagsInCommon(Request, Result),
    reply_json(Result).

getPlayerWithXTagsInCommon(Request, Result) :-
    http_parameters(Request, [combinations(X, [number])]),
    getSocialNetworkHostPort(Host, Port),
    http_open([host(Host), port(Port), path('/api/Players')], Stream, [cert_verify_hook(cert_accept_any)]),
    json_read_dict(Stream, Data),
    close(Stream),
    createPlayersWithTags(Data),
    find_users_with_X_common_tags(X, Result),
    retractall(player_tags(_,_)). % Delete all terms generated from here

createPlayersWithTags([PlayerX|OtherPlayers]):-
    createPlayersWithTags(OtherPlayers),
    asserta(player_tags(PlayerX.email, PlayerX.tags)).

createPlayersWithTags([]).     

%sinonimos("cinema","filme").
%sinonimos("csharp","c#").
%sinonimos("musica","cancao").

find_users_with_X_common_tags(X,List_Result):-
    all_tags(Todas_Tags),
    findall(Combinacao,generate_combinations(X,Todas_Tags,Combinacao),Combinacoes),
    findall(User,player_tags(User,_),Users),
    commum_tags_combination(X,Users,Combinacoes),
    findall([Comb,ListUsers],users_combination(Comb,ListUsers),List_Result),
    retractall(users_combination(_,_)).

commum_tags_combination(_,_,[]).
commum_tags_combination(X,Users,[Combinacao|Combinacoes]):-
    users_with_X_commun_tags2(X,Combinacao,Users,Users_Com_Tags),
    commum_tags_combination(X,Users,Combinacoes),
    !,
    get_combination_synonyms(Combinacao, CombinacaoComSinonimos),
    asserta(users_combination(CombinacaoComSinonimos,Users_Com_Tags)).

users_with_X_commun_tags2(_,_,[],[]):-!.
users_with_X_commun_tags2(X,Tags,[U|Users],Result):-
    player_tags(U,User_Tags),
    intersection_with_synonyms(Tags, User_Tags, Commun),
    length(Commun, Size),
    Size >= X, !,
    users_with_X_commun_tags2(X,Tags,Users,Result1),
    append([U], Result1, Result).
users_with_X_commun_tags2(X,Tags,[_|Users],Result):-
    !,
    users_with_X_commun_tags2(X,Tags,Users,Result).


get_tag_synonyms(Tag, LS2):-
    findall(S, (sinonimos(Tag,S);sinonimos(S,Tag)), LS),
    LS1 = [Tag|LS],
    sort(LS1, LS2).


get_combination_synonyms([], []):-!. 
get_combination_synonyms([Tag|Tags], [LS|Combinacao]):-
    get_combination_synonyms(Tags, Combinacao),
    get_tag_synonyms(Tag, LS).


intersection_with_synonyms([], _, []):-!.
intersection_with_synonyms([Tag|Tags], User_Tags, [LC2|Commun]):-
    intersection_with_synonyms(Tags, User_Tags, Commun),
    get_tag_synonyms(Tag, LS),
    intersection(LS, User_Tags, LC), LC\==[],
    !,
    LC1 = [Tag|LC],
    sort(LC1, LC2).
intersection_with_synonyms([_|Tags], User_Tags, Commun):-
    intersection_with_synonyms(Tags, User_Tags, Commun).

all_tags(Tags):-
    findall(User_Tags,player_tags(_,User_Tags),Todas_Tags),
    remove_equal_tags(Todas_Tags,Tags).

remove_equal_tags([],[]).
remove_equal_tags([Lista|Todas_Tags],Tags):-
    remove_equal_tags(Todas_Tags,Tags1),!,
    union(Lista,Tags1,Tags).

generate_combinations(0,_,[]).
generate_combinations(N,[X|T],[X|Comb]):-N>0,N1 is N-1,generate_combinations(N1,T,Comb).
generate_combinations(N,[_|T],Comb):-N>0,generate_combinations(N,T,Comb).