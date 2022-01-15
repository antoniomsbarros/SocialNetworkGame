%======== Safer path route calculation =============%

% no(1,'Joao',[]).
% no(2,'Miguel',[]).
% no(3,'Francisco',[]).
% no(4,'Andre',[]).
% 
% relationship(1,2,9,1).
% relationship(1,3,4,5).
% relationship(2,4,9,9).
% relationship(3,4,7,6).

% Secundary knowledge base
:- dynamic best_solution_safe_path/3.

% HTTP Request
:- http_handler('/api/network/saferPath', saferPathRoute, []).

safest_path(Orig,Dest,Min_strength,LCaminho_forlig):-
    (find_safest_path(Orig,Dest,Min_strength);true),
    retract(best_solution_safe_path(LCaminho_forlig,S,M)),
    write('Sum of strengths: '),write(S),nl,
    write('Minimum strength: '),write(M),nl,
    write('Path: '),write(LCaminho_forlig),nl.

find_safest_path(Orig,Dest,Min_strength):-
    asserta(best_solution_safe_path(_,0,Min_strength)),
    dfs_safe(Orig,Dest,LCaminho,S,M),
    check_safe_path(LCaminho,S,M),
    fail.

check_safe_path(LCaminho,S,M):-
    best_solution_safe_path(_,N,OM),
    (M>OM;(M=OM,S>N)),
    retract(best_solution_safe_path(_,_,_)),
    asserta(best_solution_safe_path(LCaminho,S,M)).


%%% apenas sentido da travessia
dfs_safe_apenas_sentido_travessia(Orig,Dest,Cam,S,M):-
    dfs_safe_apenas_sentido_travessia_2(Orig,Dest,[Orig],Cam,S,M).

dfs_safe_apenas_sentido_travessia_2(Dest,Dest,LA,Cam,0,1000):-
    !,
    reverse(LA,Cam).

dfs_safe_apenas_sentido_travessia_2(Act,Dest,LA,Cam,S,M):-
    no(NAct,Act,_),
    ((relationship(NAct,NX,S1,S2),F is S1);(relationship(NX,NAct,S1,S2),F is S2)),
    no(NX,X,_),
    \+ member(X,LA),
    dfs_safe_apenas_sentido_travessia_2(X,Dest,[X|LA],Cam,SX, MX),
    S is (SX+F),
    M is min(MX,F).


%%% 2 sentidos
dfs_safe(Orig,Dest,Cam,S,M):-
    dfs_safe_2(Orig,Dest,[Orig],Cam,S,M).

dfs_safe_2(Dest,Dest,LA,Cam,0,1000):-
    !,
    reverse(LA,Cam).

dfs_safe_2(Act,Dest,LA,Cam,S,M):-
    no(NAct,Act,_),
    (relationship(NAct,NX,S1,S2);relationship(NX,NAct,S1,S2)),
    no(NX,X,_),
    \+ member(X,LA),
    F is min(S1,S2),
    dfs_safe_2(X,Dest,[X|LA],Cam,SX, MX),
    S is (SX+S1+S2),
    M is min(MX, F).