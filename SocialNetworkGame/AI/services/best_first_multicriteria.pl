% Algoritmo Best First Max com multicritério

bestfs_multicriteria(Orig,Dest, Path, Cost):-
    bestfs_multicriteria2(Dest, [[Orig]], Path, Cost).

bestfs_multicriteria2(Dest, [[Dest|T]|_], Path, Cost):-
    !,
    reverse([Dest|T], Path),
    compute_cost_multicriteria(Path, Cost).

bestfs_multicriteria2(Dest, [[Dest|_]|LLA2], Path, Cost):- 
    !,
    bestfs_multicriteria2(Dest, LLA2, Path, Cost).
    
bestfs_multicriteria2(Dest, LLA, Path, Cost):- 
    member1(LA, LLA, LLA1),
    LA=[Act|_],
    ((Act==Dest,
        !,
        bestfs_multicriteria2(Dest, [LA|LLA1], Path, Cost)); 
    (findall((CX,[X|LA]),(
        no(NAct,Act,_),
        no(NX,X,_),(
        connection(NAct, NX, S1, _, S2, _);connection(NX, NAct, _, S1, _, S2)),
        CX is S1 + S2,
        \+member(X,LA)), NewStrengths),
    NewStrengths\==[],!,
    sort(0,@>=, NewStrengths, NewStrengthsOrd),
    delete_costs(NewStrengthsOrd, NewStrengthsOrd1),
    append(NewStrengthsOrd1, LLA1, LLA2),
    bestfs_multicriteria2(Dest, LLA2, Path, Cost))).

compute_cost_multicriteria([Act, X], C):-
    !,
    no(NAct, Act, _),
    no(NX, X, _),
    (connection(NAct, NX, S1, _, S2, _);connection(NX, NAct, _, S1, _, S2)),
    multicriteria(S1, S2, C).

compute_cost_multicriteria([Act, X|L], P):-
    compute_cost_multicriteria([X|L], P1), 
    no(NAct,Act,_),no(NX, X, _),
    (connection(NAct, NX, S1, _, S2, _);connection(NX, NAct, _, S1, _, S2)),
    multicriteria(S1, S2, C),
    P is P1 + C.

