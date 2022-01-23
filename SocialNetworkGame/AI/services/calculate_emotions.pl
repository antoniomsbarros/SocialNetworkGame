joy():- findall(USER, no(X,USER,TAGS,_,_,_,_,_,_,OR,RE,GR,RA),LISTA),joy(LISTA).
joy([H|T]):-joyAnguish(H), joy(T).
joy([]):-!.

joyAnguish(Name):- no(X,Name,_,AL,AN,V1,V2,V3,V4,V5,V6,V7,V8),
                    sumLikesDislikes(X,T, TOTAL),
                    ((TOTAL < 0,!,(R is (AL * (1 + (min(TOTAL,200)/200))), R2 is (1-R)));
                    (R3 is (AL+(1-AL)*(min(TOTAL,200)/200)), R4 is (1-R3))).

hope(Name,PQ,PNQ):- no(X,Name,_,V1,V2,ES,ME,AL,DE,V3,V4,V5,V6),
                    R is (PQ/3),((R < 0.5,!, (R1 is (ES * (1-R)), R2 is 1-R1));
                    (R1 is (ES + (1-ES)*R), R2 is 1-R1)),
                    R3 is (PNQ/3), ((R3 < 0.5,!, (R4 is (ME * (1-R3)), R5 is 1-R4));
                    (R4 is (ME + (1-ME)*R3), R5 is 1-R4)).

pride():- findall(USER, no(X,USER,TAGS,_,_,_,_,_,_,OR,RE,GR,RA),LISTA),emotion(LISTA).

emotion([]):-!.
emotion([H|LISTA]):-no(X,H,TAGS,N1,N2,N3,N4,N5,N6,OR,RE,GR,RA),
                        checkTags(TAGS, P, N),
                        ORG is (P/2),((ORG < 0.5,!, (R1 is (OR * (1-ORG)), R2 is 1-R1));
                        (R1 is (OR + (1-OR)*ORG), R2 is 1-R1)),
                        GRI is (N/2),((GR < 0.5,!, (R3 is (GR * (1-GR)), R4 is 1-R3));
                        (R3 is (GR + (1-GR)*GRI), R4 is 1-R3)),
                        emotion(LISTA).

checkTags([],P,N):-P is 0, N is 0,!.
checkTags([H|TAGS],P,N):-(goodTag(H),checkTags(TAGS,P1,N),P is P1+1);(badTag(H),checkTags(TAGS,P,N1),N is N1+1);checkTags(TAGS,P,N),!.

sumLikesDislikes(USER,LISTA,TOTAL):-findall(L,(connection(USER,_,_,_,_,L);connection(_,USER,_,_,L,_)),LISTA),sum_list(LISTA,TOTAL).

sum_list([], 0).
sum_list([H|T], Sum) :-
   sum_list(T, Rest),
   Sum is H + Rest.
   