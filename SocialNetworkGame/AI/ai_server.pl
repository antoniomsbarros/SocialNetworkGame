% Libraries
:- use_module(library(http/thread_httpd)).
:- use_module(library(http/http_dispatch)).
:- use_module(library(http/http_parameters)).
:- use_module(library(http/http_open)).
:- use_module(library(http/http_cors)).
:- use_module(library(date)).
:- use_module(library(random)).

% JSON Libraries
:- use_module(library(http/json_convert)).
:- use_module(library(http/http_json)).
:- use_module(library(http/json)).

% Primary knowledge base



% Secundary knowledge base
:- dynamic relationship/2.


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
:- http_handler('/api/network/size', compute_socialnetwork_size, []).

% Methods

%======== Size of a Player's Social Network ========%

computeSocialnetworkSize(Request) :-
    getPlayerSocialNetwork(Request, Data),
    setPlayerSocialnetworkTerms(Data).

getPlayerSocialNetwork(Request, Data) :-
    http_parameters(Request, [email(Email, [string]), depth(Depth, [number])]),
    getSocialNetworkHostPort(Host, Port),
    atom_concat('/api/Relationships/network/',Email,X),
    atom_concat(X, '/',Y),
    atom_concat(Y,Depth,Path),
    http_open([host(Host), port(Port), path(Path)], Stream, [cert_verify_hook(cert_accept_any)]),
    json_read_dict(Stream, Data).

getSocialNetworkHostPort(Host, Port) :-
    module_socialnetwork_host(Host),
    module_socialnetwork_port(Port).

createSocialnetworkTerms(Data) :-
    setPlayerSocialnetworkTerms(Data.PlayerId, Data.Relationships).

%setPlayerSocialnetworkTerms(Player, []). To review

%setPlayerSocialnetworkTerms(Player, Relationships) :-
%    setPlayerSocialnetworkTerms()
    
connection(PlayerX, PlayerY) :-
    relationship(PlayerX, PlayerY);
    relationship(PlayerY, PlayerX).

level1_connections(Player, All_Friends) :-
    findall(Friends, connection(Player, Friends), All_Friends).

append_new([], X, X).

append_new([X|Y],Z,[X|W]):-
    append_new(Y,Z,W),
    \+ member(X,W),
    !.

append_new([_|Y],Z,W):-
    append_new(Y,Z,W).

add_all_level1_connections([],[]).

add_all_level1_connections([H|T],X) :-
    add_all_level1_connections(T,K),
    level1_connections(H,N),
    append_new([H|N],K,X).

compute_network_size(Player,Level,Size) :-
    compute_network_size1(1,Level,[Player],Size1),
    Size is Size1 - 1.

compute_network_size1(CurrentLevel,LimitLevel,V,N) :-
    LimitLevel >= CurrentLevel,
    add_all_level1_connections(V,X),
    CurrentLevel1 is CurrentLevel + 1,
    compute_network_size1(CurrentLevel1,LimitLevel,X,N),
    !.

compute_network_size1(_,_,V,N) :-
        length(V,N),
        !.      

%===================================================% 


