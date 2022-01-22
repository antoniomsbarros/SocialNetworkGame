
% Algoritmo A Star Max

:-dynamic conVisited/2.
:-dynamic conSt/1.

aStar(Orig,Dest,Cam,Custo,N):- 
                        get_orderedList(Orig, N, Forcas),
                        aStar2(Dest,[(_,0,[Orig])],Cam,Custo,N, 0, Forcas).

aStar2(Dest,[(_,Custo,[Dest|T])|_],Cam,Custo,_,_,_):-!, reverse([Dest|T],Cam).

aStar2(Dest,[(_,Ca,LA)|Outros],Cam,Custo,N,M,Forcas):-
                                        LA=[Act|_],
                                        findall((CEX,CaX,[X|LA]),
                                        (Dest\==Act,
                                        no(NAct,Act,_),no(NX,X,_),
                                        (ligacao(NAct,NX,ForcaX,_,_,_);
                                        ligacao(NX,NAct,_,ForcaX,_,_)),
                                        \+ member(X,LA),
                                        CaX is ForcaX + Ca,
										listaCustos(LA, CustosLA),
										delete_list(CustosLA, Forcas, ForcasSC),
										estimativa(M,N,ForcasSC,EstX),
                                        CEX is CaX + EstX),Novos),
                                        append(Outros,Novos,Todos),
                                        sort(Todos,AllSorted),
                                        reverse(AllSorted,TodosNovos),
                                        length(LA, M1),                                      
                                        M1 =<N,
                                        aStar2(Dest,TodosNovos,Cam,Custo,N,M1,Forcas).

estimativa(M,M,_,0):-!.
estimativa(M,N,[Forcash|Forcast],Estimativa):-
    M < N,
    M1 is M + 1,
    estimativa(M1, N, Forcast, Estimativa1),
    Estimativa is Estimativa1 + Forcash.    
	

listaCustos(Caminho, Resultado):-
	reverse(Caminho, CaminhoOrd),
	listaCustosaux(CaminhoOrd, Resultado).
	
listaCustosaux([_|[]], []):-!.
listaCustosaux([CaminhoH, CaminhoHH|CaminhoT], Resultado):-
	no(IDA, CaminhoH, _),
	no(IDB, CaminhoHH, _),
	(ligacao(IDA, IDB, CustoA, _, _, _),!;
	ligacao(IDB, IDA, _, CustoA, _, _)),
	listaCustosaux([CaminhoHH|CaminhoT], Resultado1),
	union([CustoA], Resultado1, Resultado).


get_orderedList(Orig,Level,L):-
    retractall(conVisited(_,_)),
    retractall(conSt(_)),
    findall(Orig,dfs(Orig,Level),_),
    bagof(Con,conSt(Con), T),
    sort(0, @>=, T, L),
    retractall(conVisited(_,_)),
    retractall(conSt(_)).
    
dfs(Orig,Level):-
    dfs2(Orig,Level,[Orig]).

dfs2(Act,Level,LA):-
    Level > 0,
    no(Actid,Act,_),
    (ligacao(Actid,Xid,C,D,_,_);
    ligacao(Xid,Actid,D,C,_,_)),
    no(Xid, X,_),  
    \+ (conVisited(Act, X);conVisited(X, Act)),
    \+ member(X,LA),
    Level1 is Level-1,
    asserta(conVisited(Act, X)),
    asserta(conSt(C)),
	asserta(conSt(D)),
    dfs2(X,Level1,[X|LA]).

dfs2(_,_,_):-!.

delete_list([], Clean, Clean):-!.
delete_list([DeleteH|DeleteT], List, R):-
	delete_one(DeleteH, List, Clean),
	delete_list(DeleteT, Clean, R).

delete_one(_, [], []).
delete_one(Term, [Term|Tail], Tail):-!.
delete_one(Term, [Head|Tail], [Head|Result]) :-
  delete_one(Term, Tail, Result).