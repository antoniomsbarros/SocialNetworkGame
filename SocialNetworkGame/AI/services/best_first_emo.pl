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
    (no(NAct,Act,_,_,An,_,Me,_,De,_,Re,_,Ra),no(NX,X,_,_,An1,_,Me1,_,De1,_,Re1,_,Ra1),
        (connection(NAct, NX, StrengthX, _, _, _);connection(NX, NAct, _, StrengthX, _, _)),
        (An < EmotionalStatus, Me < EmotionalStatus, De < EmotionalStatus, Re < EmotionalStatus, Ra < EmotionalStatus, 
        An1 < EmotionalStatus, Me1 < EmotionalStatus, De1 < EmotionalStatus, Re1 < EmotionalStatus, Ra1 < EmotionalStatus),
        CX is S1 + S2,
        \+member(X, LA)), NewStrengths),
    NewStrengths \==[],
    !,
    sort(0, @>=, NewStrengths, NewStrengthsOrd),
    delete_costs(NewStrengthsOrd, NewStrengthsOrd1),
    append(NewStrengthsOrd1, LLA1, LLA2),
    bestfs2(Dest, LLA2, Path, Cost))).

    