%======== Shortest Path ========%

% HTTP Request
:- http_handler('/api/network/shortestpath', compute_shortest_path, []).

dfs(Orig, Dest, Path) :-
    dfs2(Orig, Dest, [Orig], Path).

dfs2(Dest, Dest, LA, Path) :-
    !,
    reverse(LA, Path).

dfs2(Orig, Dest, LA, Path) :-
    (connection(Orig, NX,_,_);connection(NX, Orig,_,_)),
    \+ member(NX, LA),
    dfs2(NX, Dest, [NX|LA], Path).

compute_shortest_path(Request):-
    cors_enable(Request, [methods([get])]),
    http_parameters(Request, [depth(Depth, [number]), orig(Orig, [string]), dest(Dest, [string])]),
    get_player_social_network(Orig, Depth),
    (shortest_path(Orig ,Dest); true),
    retract(best_shortest_path(ShortestPath,_)),
    retract(total_solutions(N)),
    reply_json(json([path=ShortestPath, total_solutions=N])).

shortest_path(Orig, Dest):-
    asserta(best_shortest_path(_, 10000)),
    asserta(total_solutions(0)),
    dfs(Orig, Dest, LPath),
    update_shortest_path(LPath),
    fail.

update_shortest_path(LPath):-
    retract(total_solutions(NS)),
    NS1 is NS+1,
    asserta(total_solutions(NS1)),
    best_shortest_path(_,N),
    length(LPath, C),
    C < N,
    retract(best_shortest_path(_,_)),
    asserta(best_shortest_path(LPath, C)).
