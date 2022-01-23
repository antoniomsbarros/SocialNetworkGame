strongest_path_unidirectional_emo(Orig,Dest,Result, EmotionalStatus):-
    get_time(Ti),
    (better_path_unidirectional_emo(Orig,Dest,EmotionalStatus);true),
    retract(best_solution_unidirectional(Result,Sum)),
    retract(counter(Counter)),
    get_time(Tf),
    T is Tf-Ti,
    write('Number of Solutions :'),write(Counter),nl,
    write('Solution generation time :'),write(T),nl,
    write('Solution binding strength :'),write(Sum),nl,
    write('Solution list :'),write(Result),nl.

better_path_unidirectional_emo(Orig,Dest,EmotionalStatus):-
    asserta(best_solution_unidirectional(_,0)),
    asserta(counter(0)),
    dfs_force_unidirectional_emo(Orig,Dest,LCaminho,Sum,EmotionalStatus),
    update_better_unidirectional(LCaminho,Sum),
    fail.

update_better_unidirectional(LCaminho,Sum):-
    retract(counter(NS)),
    NS1 is NS+1,
    asserta(counter(NS1)),
    best_solution_unidirectional(_,N),
    Sum>N,retract(best_solution_unidirectional(_,_)),
    asserta(best_solution_unidirectional(LCaminho,Sum)).

dfs_force_unidirectional_emo(Orig,Dest,Cam,Sum,EmotionalStatus):-
    dfs_force_unidirectional_emo(Orig,Dest,[Orig],Cam,Sum,EmotionalStatus).

dfs_force_unidirectional_emo(Dest,Dest,LA,Cam,0,_):-
    !,
    reverse(LA,Cam).

dfs_force_unidirectional_emo(Act,Dest,LA,Cam,Sum,EmotionalStatus):-
    no(NAct,Act,_,_,An1,_,Me1,_,De1,_,Re1,_,Ra1),
    (ligacao(NAct,NX,S1,_);ligacao(NX,NAct,_,S1)),
    no(NX,X,_,_,An,_,Me,_,De,_,Re,_,Ra),
    (An < EmotionalStatus, Me < EmotionalStatus, De < EmotionalStatus, Re < EmotionalStatus, Ra < EmotionalStatus, 
    An1 < EmotionalStatus, Me1 < EmotionalStatus, De1 < EmotionalStatus, Re1 < EmotionalStatus, Ra1 < EmotionalStatus),
    \+ member(X,LA),
    dfs2_force_unidirectional(X,Dest,[X|LA],Cam,SX),
    Sum is (SX+S1).

