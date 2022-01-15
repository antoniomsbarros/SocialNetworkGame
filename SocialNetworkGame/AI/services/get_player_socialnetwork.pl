% Secundary knowledge base
:- dynamic relationship/4. % relationship(PlayerA, PlayerB, Strength, Tags)

getPlayerSocialNetwork(Email, Depth) :-
    getSocialNetworkHostPort(Host, Port),
    atom_concat('/api/Relationships/network/',Email,X),
    atom_concat(X, '/',Y),
    atom_concat(Y,Depth,Path),
    http_open([host(Host), port(Port), path(Path)], Stream, [cert_verify_hook(cert_accept_any)]),
    json_read_dict(Stream, Data),
    close(Stream),
    createSocialNetworkTerms(Data).

createSocialNetworkTerms(StartPlayer) :-
    setPlayerSocialNetworkTerms(StartPlayer, StartPlayer, StartPlayer.relationships).

setPlayerSocialNetworkTerms(CurrentPlayer, CurrentPlayer, []).

setPlayerSocialNetworkTerms(PreviousPlayer, CurrentPlayer, []) :-
    asserta(relationship(CurrentPlayer.playerEmail, PreviousPlayer.playerEmail, CurrentPlayer.relationshipStrength, CurrentPlayer.relationshipTags)).

setPlayerSocialNetworkTerms(PreviousPlayer, CurrentPlayer, [NextPlayer|Relationships]) :-
    setPlayerSocialNetworkTerms(CurrentPlayer, NextPlayer, NextPlayer.relationships),
    setPlayerSocialNetworkTerms(PreviousPlayer, CurrentPlayer, Relationships).

deletePlayerSocialNetwork :-
        retractall(relationship(_,_,_,_)). % Delete all relationships generated
        