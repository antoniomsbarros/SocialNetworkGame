% Multicritério

multicriteria(F1, F2, FMC):- 
    ((F1 < 50, switchFL0(F1,F2,FMC)); 
     (F1 < 100, switchFL50(F1,F2,FMC)); 
     (F1 = 100, switchFL100(F1,F2,FMC))),!.

switchFL0(F1, F2, FMC):- 
    ((F2 =< -200, switchFL0FRLower(F1,F2,FMC));
     (F2 >= 200, switchFL0FRHigher(F1,F2,FMC));
     switchFL0FREqual(F1,F2,FMC)).

switchFL50(F1,F2,FMC):-
    ((F2 =< -200, switchFL50FRLower(F1,F2,FMC));
     (F2 >= 200, switchFL50FRHigher(F1,F2,FMC));
     switchFL50FREqual(F1,F2,FMC)).

switchFL100(F1,F2,FMC):-
    ((F2 =< -200, switchFL100FRLower(F1,F2,FMC));
     (F2 >= 200, switchFL100FRHigher(F1,F2,FMC));
     switchFL100FREqual(F1,F2,FMC)).

switchFL0FRLower(_,_,FMC):- 
    FMC is 0.

switchFL0FRHigher(_,_,FMC):- 
    FMC is 50.

switchFL0FREqual(_,_,FMC):- 
    FMC is 25.

switchFL50FRLower(_,_,FMC):- 
    FMC is 25.

switchFL50FRHigher(_,_,FMC):- 
    FMC is 75.

switchFL150FREqual(_,_,FMC):- 
    FMC is 50.

switchFL100FRLower(_,_,FMC):- 
    FMC is 50.

switchFL100FRHigher(_,_,FMC):- 
    FMC is 100.

switchFL100FREqual(_,_,FMC):- 
    FMC is 75.
    


