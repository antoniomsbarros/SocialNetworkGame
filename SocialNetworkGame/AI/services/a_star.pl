% Algoritmo A Star Max

:-dynamic connectionsVisisted/2.
:-dynamic connectionSt/1.

aStar(Orig, Dest, Path, Cost, N):- 
    get_cost_ordered_list(Orig, N, ConnectionStrengths),
    aStar2(Dest, [(_,0,[Orig])], Path, Cost, N, 0, ConnectionStrengths).

aStar2(Dest,[(_, Cost, [Dest|T])|_], Path, Cost, _, _, _):-
    !, 
    reverse([Dest|T], Path).

aStar2(Dest, [(_,CostA,LA)| Others], Path, Cost, N, M, ConnectionStrengths):-
    LA=[Act|_],
    findall((CEX, CostAX, [X|LA]),
        (Dest\==Act,
        no(NAct,Act,_),no(NX,X,_),
        (connection(NAct, NX, StrengthX, _, _, _);connection(NX, NAct, _, StrengthX, _, _)),
        \+ member(X, LA),
        CostAX is StrengthX + CostA,
        costList(LA, CustosLA),
    delete_list(CustosLA, ConnectionStrengths, ForcasSC),
    estimate_strength(M, N, ForcasSC, EstX),
    CEX is CostAX + EstX), New),
    append(Others, New, Total),
    sort(Total, TotalAllSorted),
    reverse(TotalAllSorted, NewTotal),
    length(LA, M1),                                      
    M1 =< N,
    aStar2(Dest, NewTotal, Path, Cost, N, M1, ConnectionStrengths).
 
estimate_strength(M, M, _, 0):- !.

estimate_strength(M,N,[Forcash|Forcast], EstimateStrength):-
    M < N,
    M1 is M + 1,
    estimate_strength(M1, N, Forcast, EstimateStrength1),
    EstimateStrength is EstimateStrength1 + Forcash.    
    
costList(Path, Result):-
    reverse(Path, PathOrd),
    costListAux(PathOrd, Result).
    
costListAux([_|[]], []):- !.

costListAux([PathH, PathHH|PathT], Result):-
    no(IDA, PathH, _),
    no(IDB, PathHH, _),
    (connection(IDA, IDB, Cost, _, _, _),!;connection(IDB, IDA, _, Cost, _, _)),
    costListAux([PathHH|PathT], Result1),
    union([Cost], Result1, Result).

get_cost_ordered_list(Orig, Level, L):-
    retractall(connectionsVisisted(_, _)),
    retractall(connectionSt(_)),
    findall(Orig, dfs(Orig,Level), _),
    bagof(Con, connectionSt(Con), T),
    sort(0, @>=, T, L),
    retractall(connectionsVisisted(_, _)),
    retractall(connectionSt(_)).
    
dfs(Orig,Level):-
    dfs2(Orig, Level, [Orig]).

dfs2(Act, Level, LA):-
    Level > 0,
    no(Actid,Act,_),
    (connection(Actid,Xid,C,D,_,_); connection(Xid,Actid,D,C,_,_)),
    no(Xid, X,_),  
    \+ (connectionsVisisted(Act, X);connectionsVisisted(X, Act)),
    \+ member(X,LA),
    Level1 is Level-1,
    asserta(connectionsVisisted(Act, X)),
    asserta(connectionSt(C)),
    asserta(connectionSt(D)),
    dfs2(X,Level1,[X|LA]).

dfs2(_,_,_):- !.

delete_list([], Clean, Clean):- !.

delete_list([DeleteH|DeleteT], List, R):-
    delete_one(DeleteH, List, Clean),
    delete_list(DeleteT, Clean, R).

delete_one(_, [], []).

delete_one(Term, [Term|Tail], Tail):-!.

delete_one(Term, [Head|Tail], [Head|Result]) :-
  delete_one(Term, Tail, Result).
  