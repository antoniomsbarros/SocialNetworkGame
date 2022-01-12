%======== Shortest Path Between Two Users ========%



% HTTP Request
:- http_handler('/shortestPath', shortestPathRoute, []).

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