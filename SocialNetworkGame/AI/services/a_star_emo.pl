% Algoritmo A Star Max com emoções

aStarEmo(Orig, Dest, Path, Cost, N, EmotionalStatus):- 
    get_cost_ordered_list(Orig, N, ConnectionStrengths),
    aStarEmo2(Dest, [(_,0,[Orig])], Path, Cost, N, 0, ConnectionStrengths, EmotionalStatus).

aStarEmo2(Dest,[(_, Cost, [Dest|T])|_], Path, Cost, _, _, _, _):-
    !, 
    reverse([Dest|T], Path).

aStarEmo2(Dest, [(_,CostA,LA)| Others], Path, Cost, N, M, ConnectionStrengths, EmotionalStatus):-
    LA=[Act|_],
    findall((CEX, CostAX, [X|LA]),
        (Dest\==Act,
        no(NAct,Act,_,_,An,_,Me,_,De,_,Re,_,Ra),no(NX,X,_,_,An1,_,Me1,_,De1,_,Re1,_,Ra1),
        (connection(NAct, NX, StrengthX, _, _, _);connection(NX, NAct, _, StrengthX, _, _)),
        (An < EmotionalStatus, Me < EmotionalStatus, De < EmotionalStatus, Re < EmotionalStatus, Ra < EmotionalStatus, 
        An1 < EmotionalStatus, Me1 < EmotionalStatus, De1 < EmotionalStatus, Re1 < EmotionalStatus, Ra1 < EmotionalStatus),
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
    aStar2(Dest, NewTotal, Path, Cost, N, M1, ConnectionStrengths, EmotionalStatus).

