suggestGroups(Player, Level, Result, MinCommonTags, TotalPlayers, Tags):-
    suggestGroups2(Player, Level, Connections, MinCommonTags),
    n_tags(Connections, Tags, LA, LA2),
    length(LA2, Players),
    ((Players < TotalPlayers, 
        !, 
        copy_list([],Result));copy_list(LA2,Result)),
    check_players(Result,PQ),
    remove_players(Result, PNQ),
    hope(USER, PQ, PNQ).

check_players([],T):-
    T is 0,
    !.

check_players([H|L], T):-
    (wanted_players(H), 
    check_players(L, T1),
    T is T1 + 1,!);check_players(L, T),
    !.

remove_players([],T):-T is 0,!.

remove_players([H|L], T):-
    (unwanted_players(H), 
    remove_players(L, T1), 
    T is T1 + 1,
    !);remove_players(L, T),!.

suggestGroups2(Player, Level, Connections, MinCommonTags):- 
    compute(Level, LTotal, [Player]),
    remove_duplicated(LTotal,L),
    remove_list_head(L, LUtil),
    !,
    groups_with_tags_in_common(Player, LUtil, LC, MinCommonTags),
    copy_list(LC, Connections),
    !.

groups_with_tags_in_common(_,[],_,_):-!.

groups_with_tags_in_common(Player, [X|LUtil], Connections, MinCommonTags):-
    no(_, Player, UTags,_,_,_,_,_,_,_,_,_,_),no(_, X, XTags,_,_,_,_,_,_,_,_,_,_),
    intersection(UTags, XTags, CommonTagsGroups),
    length(CommonTagsGroups, TotalCommonTags),
    (TotalCommonTags < MinCommonTags,
        !,groups_with_tags_in_common3(Player, [X|LUtil], Connections, MinCommonTags));groups_with_tags_in_common2(Player,[X|LUtil],Connections,MinCommonTags).

groups_with_tags_in_common2(_,[],_,_):-!.

groups_with_tags_in_common2(Player, [X|LUtil], [X|Connections], MinCommonTags):-
    groups_with_tags_in_common3(Player, LUtil, Connections, MinCommonTags).

groups_with_tags_in_common3(_,[],_,_):-!.

groups_with_tags_in_common3(Player, [X|LUtil], Connections, MinCommonTags):-
    no(_, Player, UTags,_,_,_,_,_,_,_,_,_,_),
    no(_, X, XTags,_,_,_,_,_,_,_,_,_,_),
    intersection(UTags, XTags, CommonTagsGroups),
    length(CommonTagsGroups, TotalCommonTags),
    (TotalCommonTags < MinCommonTags,!, groups_with_tags_in_common3(Player, LUtil, Connections, MinCommonTags));
    groups_with_tags_in_common2(Player,[X|LUtil], Connections, MinCommonTags).

n_tags([],_,LA,LA2):- copy_list(LA,LA2),!.

n_tags([X|Connections], Tags, LA, LA2):-
    no(_, X, XTags ,_,_,_,_,_,_,_,_,_,_),
    intersection(XTags, Tags, CommonTags),
    length(CommonTags, NCommonTags),
    length(Tags, NumeroTags),
    ((NCommonTags==NumeroTags,
        !,
        n_tags(Connections, Tags,[X|LA],LA2));n_tags(Connections,Tags,LA,LA2)).

