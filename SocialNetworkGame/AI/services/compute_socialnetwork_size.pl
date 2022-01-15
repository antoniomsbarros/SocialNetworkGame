%======== Size of a Player's Social Network ========%

% HTTP Request
:- http_handler('/api/network/size', computeSocialNetworkSize, []).

computeSocialNetworkSize(Request) :-
    http_parameters(Request, [email(Email, [string]), depth(Depth, [number])]),
    getPlayerSocialNetworkSize(Email, Depth, Size), % compute_socialnetwork_size.pl
    reply_json(Size).

getPlayerSocialNetworkSize(Email, Depth, Size) :-
    getPlayerSocialNetwork(Email, Depth),
    compute_network_size(Email, Depth, Size),
    deletePlayerSocialNetwork.

connection(PlayerX, PlayerY) :-
    relationship(PlayerX, PlayerY, _, _),
    relationship(PlayerY, PlayerX, _, _).

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
