%======== Strongest Path Between Two Users ========%

% Secundary knowledge base
:- dynamic best_solution_bidirectional/2.
:- dynamic best_solution_unidirectional/2.


%===== Unidirectional =====%

strongest_path_unidirectional(Orig,Dest,Result):-
    get_time(Ti),
    (better_path_unidirectional(Orig,Dest);true),
    retract(best_solution_unidirectional(Result,Sum)),
    retract(counter(Counter)),
    get_time(Tf),
    T is Tf-Ti,
    write('Number of Solutions :'),write(Counter),nl,
    write('Solution generation time :'),write(T),nl,
    write('Solution binding strength :'),write(Sum),nl,
    write('Solution list :'),write(Result),nl.

strongest_path_unidirectionalServer(Orig,Dest,Result):-
    (better_path_unidirectional(Orig,Dest);true),
    retract(best_solution_unidirectional(Result,Sum)),
    retract(counter(Counter)).

better_path_unidirectional(Orig,Dest):-
    asserta(best_solution_unidirectional(_,0)),
    asserta(counter(0)),
    dfs_force_unidirectional(Orig,Dest,LCaminho,Sum),
    update_better_unidirectional(LCaminho,Sum),
    fail.

update_better_unidirectional(LCaminho,Sum):-
    retract(counter(NS)),
    NS1 is NS+1,
    asserta(counter(NS1)),
    best_solution_unidirectional(_,N),
    Sum>N,retract(best_solution_unidirectional(_,_)),
    asserta(best_solution_unidirectional(LCaminho,Sum)).

dfs_force_unidirectional(Orig,Dest,Cam,Sum):-
    dfs2_force_unidirectional(Orig,Dest,[Orig],Cam,Sum).

dfs2_force_unidirectional(Dest,Dest,LA,Cam,0):-
    !,
    reverse(LA,Cam).

dfs2_force_unidirectional(Act,Dest,LA,Cam,Sum):-
    no(NAct,Act,_),
    (ligacao(NAct,NX,S1,_);ligacao(NX,NAct,_,S1)),
    no(NX,X,_),
    \+ member(X,LA),
    dfs2_force_unidirectional(X,Dest,[X|LA],Cam,SX),
    Sum is (SX+S1).

%===== Bidirectional =====%

strongest_path_bidirectional(Orig,Dest,Result):-
    get_time(Ti),
    (best_path_bidirectional(Orig,Dest);true),
    retract(best_solution_bidirectional(Result,Sum)),
    retract(counter(Count)),
    get_time(Tf),
    T is Tf-Ti,
    write('Number of Solutions :'),write(Count),nl,
    write('Solution generation time :'),write(T),nl,
    write('Solution binding strength :'),write(Sum),nl,
    write('Solution list :'),write(Result),nl.

strongest_path_bidirectionalServer(Orig,Dest,Result):-
    (best_path_bidirectional(Orig,Dest);true),
    retract(best_solution_bidirectional(Result,Sum)),
    retract(counter(Count)).

best_path_bidirectional(Orig,Dest):-
    asserta(best_solution_bidirectional(_,-10000)),
    asserta(counter(0)),
    dfs_force_bidirectional(Orig,Dest,LCaminho,Sum),
    update_better_bidirectional(LCaminho,Sum),
    fail.

update_better_bidirectional(LCaminho,Sum):-
    retract(counter(NS)),
    NS1 is NS+1,
    asserta(counter(NS1)),
    best_solution_bidirectional(_,N),
    Sum>N,
    retract(best_solution_bidirectional(_,_)),
    asserta(best_solution_bidirectional(LCaminho,Sum)).

dfs_force_bidirectional(Orig,Dest,Cam,Sum):-
    dfs2_force_bidirectional(Orig,Dest,[Orig],Cam,Sum).

dfs2_force_bidirectional(Dest,Dest,LA,Cam,0):-
    !,
    reverse(LA,Cam).

dfs2_force_bidirectional(Act,Dest,LA,Cam,Sum):-
    no(NAct,Act,_),
    (ligacao(NAct,NX,S1,S2);ligacao(NX,NAct,S1,S2)),
    no(NX,X,_),
    \+ member(X,LA),
    dfs2_force_bidirectional(X,Dest,[X|LA],Cam,SX),
    Sum is (SX+S1+S2).

