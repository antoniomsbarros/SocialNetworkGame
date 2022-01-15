% Secundary knowledge base
:- dynamic relationship/4. % relationship(PlayerA, PlayerB, Strength, Tags)

get_player_social_network(Email, Depth) :-
    getSocialNetworkHostPort(Host, Port),
    atom_concat('/api/Relationships/network/',Email,X),
    atom_concat(X, '/',Y),
    atom_concat(Y,Depth,Path),
    http_open([host(Host), port(Port), path(Path)], Stream, [cert_verify_hook(cert_accept_any)]),
    json_read_dict(Stream, Data),
    close(Stream),
    create_social_network_terms(Data).

create_social_network_terms(StartPlayer) :-
    set_player_social_network_terms(StartPlayer, StartPlayer, StartPlayer.relationships).

set_player_social_network_terms(CurrentPlayer, CurrentPlayer, []).

set_player_social_network_terms(PreviousPlayer, CurrentPlayer, []) :-
    asserta(relationship(CurrentPlayer.playerEmail, PreviousPlayer.playerEmail, CurrentPlayer.relationshipStrength, CurrentPlayer.relationshipTags)).

set_player_social_network_terms(PreviousPlayer, CurrentPlayer, [NextPlayer|Relationships]) :-
    set_player_social_network_terms(CurrentPlayer, NextPlayer, NextPlayer.relationships),
    set_player_social_network_terms(PreviousPlayer, CurrentPlayer, Relationships).

delete_player_social_network :-
        retractall(relationship(_,_,_,_)). % Delete all relationships generated

connection(PlayerX, PlayerY, StrengthXY, StrengthYX) :-
    relationship(PlayerX, PlayerY, StrengthXY, _),
    relationship(PlayerY, PlayerX, StrengthYX, _).
    