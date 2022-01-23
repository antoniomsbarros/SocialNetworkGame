strongest_path_unidirectional_multicriteria(Orig,Dest,Result):-
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
    multicriteria(SX, S1, Sum).
    