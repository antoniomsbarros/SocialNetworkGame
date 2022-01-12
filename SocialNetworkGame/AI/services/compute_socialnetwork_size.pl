%======== Size of a Player's Social Network ========%

% Secundary knowledge base
:- dynamic relationship1/2.

% HTTP Request
:- http_handler('/api/network/size', computeSocialNetworkSize, []).

computeSocialNetworkSize(Request) :-
    http_parameters(Request, [email(Email, [string]), depth(Depth, [number])]),
    getSocialNetworkHostPort(Host, Port),
    atom_concat('/api/Relationships/network/',Email,X),
    atom_concat(X, '/',Y),
    atom_concat(Y,Depth,Path),
    http_open([host(Host), port(Port), path(Path)], Stream, [cert_verify_hook(cert_accept_any)]),
    json_read_dict(Stream, Data),
    close(Stream),
    getPlayerSocialNetwork(Data, Depth, Size), % compute_socialnetwork_size.pl
    reply_json(Size).

getPlayerSocialNetwork(Data, Depth, Size) :-
    createSocialNetworkTerms(Data),
    compute_network_size(Data.playerId, Depth, Size),
    retractall(relationship1(_,_)). % Delete all relationships generated

createSocialNetworkTerms(Data) :-
    setPlayerSocialNetworkTerms(Data, Data.relationships).

setPlayerSocialNetworkTerms(_, []).

setPlayerSocialNetworkTerms(Player, [PlayerX]) :-
    setPlayerSocialNetworkTerms(PlayerX, PlayerX.relationships),
    asserta(relationship1(Player.playerId, PlayerX.playerId)).

setPlayerSocialNetworkTerms(Player, [PlayerX|Relationships]) :-
    setPlayerSocialNetworkTerms(Player, Relationships),
    asserta(relationship1(Player.playerId, PlayerX.playerId)).

connection(PlayerX, PlayerY) :-
    relationship1(PlayerX, PlayerY);
    relationship1(PlayerY, PlayerX).

compute_network_size(Player, Level, Size) :-
    compute_network_size1(0, Level, [Player], Size1),
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
