% Algoritmo Best First Max

bestfs(Orig, Dest, Path, Cost):- 
    bestfs2(Dest,[[Orig]], Path, Cost).

bestfs2(Dest, [[Dest|T]|_], Path, Cost):- 
    reverse([Dest|T], Path), 
    compute_cost(Path, Cost).

bestfs2(Dest, [[Dest|_]|LLA2], Path , Cost):- 
    !,
    bestfs2(Dest, LLA2, Path, Cost).
    
bestfs2(Dest, LLA, Path, Cost):-
    member1(LA, LLA, LLA1),
    LA=[Act|_],
    ((Act==Dest,
        !,
        bestfs2(Dest,[LA|LLA1], Path, Cost)); 
    (findall((CX, [X|LA]),
    (no(NAct, Act, _),
        no(NX, X, _),
        (connection(NAct, NX ,S1, _, S2, _);connection(NX, NAct, _, S1, _, S2)),
        CX is S1 + S2,
        \+member(X, LA)), NewStrengths),
    NewStrengths \==[],
    !,
    sort(0, @>=, NewStrengths, NewStrengthsOrd),
    delete_costs(NewStrengthsOrd, NewStrengthsOrd1),
    append(NewStrengthsOrd1, LLA1, LLA2),
    bestfs2(Dest, LLA2, Path, Cost))).

member1(LA,[LA|LAA],LAA).

member1(LA,[_|LAA],LAA1):-
    member1(LA,LAA,LAA1).

delete_costs([],[]).

delete_costs([(_,LA)|L], [LA|L1]):-
    delete_costs(L, L1).

compute_cost([Act,X], C):-
    !,
    no(NAct, Act, _),
    no(NX, X, _),
    (connection(NAct, NX, S1,_,_,_);connection(NX,NAct,_,S1,_,_)),
    C is S1.

compute_cost([Act,X|L], P):-
    compute_cost([X|L], P1), 
    no(NAct,Act,_),no(NX, X, _),
    (connection(NAct, NX, S1, _, _, _);connection(NX, NAct, _, S1, _, _)),
    P is P1+S1.
