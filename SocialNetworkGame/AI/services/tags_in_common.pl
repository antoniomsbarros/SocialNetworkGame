%======== User with X tags in common ========%

% Secundary knowledge base
:- dynamic users_combination/2.

% HTTP Request
:- http_handler('/api/tagsincommon', computePlayerWithXTagsInCommon, []).

computePlayerWithXTagsInCommon(Request) :-
    getPlayerWithXTagsInCommon(Request, Result),
    reply_json(Result).

getPlayerWithXTagsInCommon(Request, Result) :-
    http_parameters(Request, [combinations(X, [number])]),
    getSocialNetworkHostPort(Host, Port),
    http_open([host(Host), port(Port), path('/api/Players')], Stream, [cert_verify_hook(cert_accept_any)]),
    json_read_dict(Stream, Data),
    close(Stream),
    createPlayersWithTags(Data),
    find_users_with_X_common_tags(X, Result),
    retractall(player_tags(_,_)). % Delete all terms generated from here

createPlayersWithTags([PlayerX|OtherPlayers]):-
    createPlayersWithTags(OtherPlayers),
    asserta(player_tags(PlayerX.email, PlayerX.tags)).

createPlayersWithTags([]).     

%sinonimos("cinema","filme").
%sinonimos("csharp","c#").
%sinonimos("musica","cancao").

find_users_with_X_common_tags(X,List_Result):-
    all_tags(Todas_Tags),
    findall(Combinacao,generate_combinations(X,Todas_Tags,Combinacao),Combinacoes),
    findall(User,player_tags(User,_),Users),
    commum_tags_combination(X,Users,Combinacoes),
    findall([Comb,ListUsers],users_combination(Comb,ListUsers),List_Result),
    retractall(users_combination(_,_)).

commum_tags_combination(_,_,[]).
commum_tags_combination(X,Users,[Combinacao|Combinacoes]):-
    users_with_X_commun_tags2(X,Combinacao,Users,Users_Com_Tags),
    commum_tags_combination(X,Users,Combinacoes),
    !,
    get_combination_synonyms(Combinacao, CombinacaoComSinonimos),
    asserta(users_combination(CombinacaoComSinonimos,Users_Com_Tags)).

users_with_X_commun_tags2(_,_,[],[]):-!.
users_with_X_commun_tags2(X,Tags,[U|Users],Result):-
    player_tags(U,User_Tags),
    intersection_with_synonyms(Tags, User_Tags, Commun),
    length(Commun, Size),
    Size >= X, !,
    users_with_X_commun_tags2(X,Tags,Users,Result1),
    append([U], Result1, Result).
users_with_X_commun_tags2(X,Tags,[_|Users],Result):-
    !,
    users_with_X_commun_tags2(X,Tags,Users,Result).


get_tag_synonyms(Tag, LS2):-
    findall(S, (sinonimos(Tag,S);sinonimos(S,Tag)), LS),
    LS1 = [Tag|LS],
    sort(LS1, LS2).


get_combination_synonyms([], []):-!. 
get_combination_synonyms([Tag|Tags], [LS|Combinacao]):-
    get_combination_synonyms(Tags, Combinacao),
    get_tag_synonyms(Tag, LS).


intersection_with_synonyms([], _, []):-!.
intersection_with_synonyms([Tag|Tags], User_Tags, [LC2|Commun]):-
    intersection_with_synonyms(Tags, User_Tags, Commun),
    get_tag_synonyms(Tag, LS),
    intersection(LS, User_Tags, LC), LC\==[],
    !,
    LC1 = [Tag|LC],
    sort(LC1, LC2).
intersection_with_synonyms([_|Tags], User_Tags, Commun):-
    intersection_with_synonyms(Tags, User_Tags, Commun).

all_tags(Tags):-
    findall(User_Tags,player_tags(_,User_Tags),Todas_Tags),
    remove_equal_tags(Todas_Tags,Tags).

remove_equal_tags([],[]).
remove_equal_tags([Lista|Todas_Tags],Tags):-
    remove_equal_tags(Todas_Tags,Tags1),!,
    union(Lista,Tags1,Tags).

generate_combinations(0,_,[]).
generate_combinations(N,[X|T],[X|Comb]):-N>0,N1 is N-1,generate_combinations(N1,T,Comb).
generate_combinations(N,[_|T],Comb):-N>0,generate_combinations(N,T,Comb).
