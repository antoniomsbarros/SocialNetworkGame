% Algoritmo Best First Max

bestfs1(Orig,Dest,Cam,Custo):- bestfs12(Dest,[[Orig]],Cam,Custo),! ,
                    write('Caminho='),write(Cam),nl.

bestfs12(Dest,[[Dest|T]|_],Cam,Custo):- reverse([Dest|T],Cam), calcula_custo(Cam,Custo).

bestfs12(Dest,[[Dest|_]|LLA2],Cam,Custo):- !,bestfs12(Dest,LLA2,Cam,Custo).
    
bestfs12(Dest,LLA,Cam,Custo):-    member1(LA,LLA,LLA1),LA=[Act|_],
                ((Act==Dest,!,bestfs12(Dest,[LA|LLA1],Cam,Custo)) ; (findall((CX,[X|LA]),
                (no(NAct,Act,_),no(NX,X,_),(ligacao(NAct,NX,S1,_,S2,_);ligacao(NX,NAct,_,S1,_,S2)),CX is S1+S2,
                \+member(X,LA)),Novos),
                Novos\==[],!,
                sort(0,@>=,Novos,NovosOrd),
                retira_custos(NovosOrd,NovosOrd1),
                append(NovosOrd1,LLA1,LLA2),
                %write('LLA2='),write(LLA2),nl,
                bestfs12(Dest,LLA2,Cam,Custo))).

member1(LA,[LA|LAA],LAA).
member1(LA,[_|LAA],LAA1):-member1(LA,LAA,LAA1).

retira_custos([],[]).
retira_custos([(_,LA)|L],[LA|L1]):-retira_custos(L,L1).

calcula_custo([Act,X],C):-!,no(NAct,Act,_),no(NX,X,_),
                    (ligacao(NAct,NX,S1,_,_,_);ligacao(NX,NAct,_,S1,_,_)),C is S1.
calcula_custo([Act,X|L],P):-calcula_custo([X|L],P1), 
                    no(NAct,Act,_),no(NX,X,_),
                    (ligacao(NAct,NX,S1,_,_,_);ligacao(NX,NAct,_,S1,_,_)),P is P1+S1.