% Algoritmo A Star Max com multicritério

aStarM(Orig, Dest, Path, Cost):- 
    aStarM2(Dest, [(_,0,[Orig])], Path, Cost),
    !. 

aStarM2(Dest,[(_,Cost,[Dest|T])|_], Path, Cost):-
    !, 
    reverse([Dest|T], Path).

aStarM2(Dest, [(_,Ca,LA)| Others], Path, Cost):-
    LA=[Act|_],
    findall((CEX, CostAX, [X|LA]),
        (Dest \== Act,
        no(NAct,Act,_),no(NX,X,_),
        (connection(NAct, NX, Cost1, _, Cost2, _);connection(NX, NAct, _, Cost1, _, Cost2)), % Cost1 -> Força de ligação Cost2 -> Likes
        CostX is Cost1+ Cost2,
        \+ member(X,LA),
        CostAX is CostX + Ca, 
        multicriteria(Cost1, Cost2, EstX), % Função multicritério
        CEX is EstX), New),
    append(Others, New, Total),
    sort(Total, TotalAllSorted),
    reverse(TotalAllSorted, NewTotal),
    aStarM2(Dest, NewTotal, Path, EstX).
