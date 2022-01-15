using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.model.relationships.repository;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.services.relationships
{
    public class RelationshipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelationshipRepository _repo;
        private readonly PlayerService _playerService;
        private readonly TagsService _tagsService;

        public RelationshipService(IUnitOfWork unitOfWork, IRelationshipRepository repo, PlayerService playerService,
            TagsService service)
        {
            _tagsService = service;
            _unitOfWork = unitOfWork;
            _repo = repo;
            _playerService = playerService;
        }

        public async Task<List<RelationshipDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            var listDto = new List<RelationshipDto>();
            list.ForEach(r => listDto.Add(r.ToDto()));
            return listDto;
        }

        public async Task<RelationshipDto> GetByIdAsync(RelationshipId id)
        {
            var cat = await this._repo.GetByIdAsync(id);

            if (cat == null)
                return null;

            return cat.ToDto();
        }

        public async Task<PlayersRelationshipDto> GetRelationshipBetweenTwoPlayers(Email playerOrig, Email playerDest)
        {
            var result = new PlayersRelationshipDto();

            var playerFrom = await _playerService.GetByEmailAsync(playerOrig);
            var playerTo = await _playerService.GetByEmailAsync(playerDest);

            var relationshipOrig =
                await _repo.GetRelationshipBetweenPlayers(new PlayerId(playerFrom.id), new PlayerId(playerTo.id));

            if (relationshipOrig == null)
                return null;
            else
                result.relationshipFromOrig = relationshipOrig.ToDto();

            var relationshipDest =
                await _repo.GetRelationshipBetweenPlayers(new PlayerId(playerTo.id), new PlayerId(playerFrom.id));

            if (relationshipDest == null)
                return null;
            else
                result.relationshipFromDest = relationshipDest.ToDto();

            return result;
        }

        public async Task<List<PlayerEmailDto>> GetRelationByEmail(string email)
        {
            var player = await _playerService.GetByEmailAsync(new Email(email));

            var relationships = await _repo.GetRelationshipsFromPlayerById(new PlayerId(player.id));

            List<PlayerId> friends = new List<PlayerId>();

            relationships.ForEach(r => friends.Add(r.PlayerDest));

            List<PlayerEmailDto> listToReturnFriends = new List<PlayerEmailDto>();

            foreach (var f in friends)
            {
                var friendsAux = await _playerService.GetByIdAsync(f);
                listToReturnFriends.Add(new PlayerEmailDto(friendsAux.email, friendsAux.fullName));
            }

            return listToReturnFriends;
        }

        public async Task<ActionResult<NetworkFromPlayerPerspectiveDto>> GetNetworkAtDepthByEmail(Email email,
            int depth)
        {
            var player = await _playerService.GetByEmailAsync(email);

            if (player == null)
                return null;

            NetworkFromPlayerPerspectiveDto network = new()
            {
                PlayerId = player.id,

                PlayerName = player.fullName,
                emotionalStatus = player.emotionalStatus,
                PlayerEmail = player.email,
                Relationships = new()
            };

            List<NetworkFromPlayerPerspectiveDto> notVisitedPlayers = new(), nextDepthPlayers = new();

            List<Relationship> visitedRelationships = new();
            notVisitedPlayers.Add(network);
            var listrelaction = GetAllAsync().Result;
            for (var currentDepth = 1; currentDepth <= depth; currentDepth++)
            {
                if (nextDepthPlayers.Count != 0)
                {
                    notVisitedPlayers.AddRange(nextDepthPlayers);
                    nextDepthPlayers.Clear();
                }
                else if (notVisitedPlayers.Count == 0)
                    break;

                while (notVisitedPlayers.Count != 0)
                {
                    NetworkFromPlayerPerspectiveDto nextPlayer = notVisitedPlayers[0];

                    foreach (var relationship in await _repo.GetRelationshipsFromPlayerById(
                                 new PlayerId(nextPlayer.PlayerId)))
                    {
                        if (visitedRelationships.Contains(relationship) ||
                            relationship.PlayerDest.Value.Equals(player.id)) // ?????
                            continue;

                        visitedRelationships.Add(relationship);

                        var playerTo = await _playerService.GetByIdAsync(relationship.PlayerDest);

                        var playerToNetwork = new NetworkFromPlayerPerspectiveDto
                        {
                            PlayerId = playerTo.id,

                            PlayerName = playerTo.fullName,
                            emotionalStatus = playerTo.emotionalStatus,
                            //RelationshipStrengthOrig = relationship.ConnectionStrength.Strength,
                            RelationshipStrengthOrig = listrelaction.Find(x=>
                                (x.playerOrig.Equals(relationship.PlayerDest.Value) && 
                                 (x.playerDest.Equals(relationship.PlayerOrig.Value)))).connectionStrength, 
                            RelationshipStrengthDest = relationship.ConnectionStrength.Strength,
                            PlayerEmail = playerTo.email,
                            Relationships = new()
                        };

                        nextPlayer.Relationships ??= new();
                        nextPlayer.Relationships.Add(playerToNetwork);
                        
                        if (nextPlayer.PlayerId.Equals(player.id))
                        {
                            
                            playerToNetwork.RelationshipStrengthOrig = listrelaction.Find(x=>
                                (x.playerOrig.Equals(relationship.PlayerDest.Value) && 
                                 (x.playerDest.Equals(relationship.PlayerOrig.Value)))).connectionStrength; 
                            playerToNetwork.RelationshipStrengthDest = relationship.ConnectionStrength.Strength;
                        }
                        else
                            playerToNetwork.RelationshipStrengthOrig = listrelaction.Find(x=>
                                (x.playerOrig.Equals(relationship.PlayerDest.Value) && 
                                 (x.playerDest.Equals(relationship.PlayerOrig.Value)))).connectionStrength;;

                        if (!nextDepthPlayers.Contains(playerToNetwork))
                            nextDepthPlayers.Add(playerToNetwork);
                    }

                    notVisitedPlayers.RemoveAt(0);
                }
            }

            return network;
        }

        public async Task<RelationshipDto> AddAsync(RelationshipPostDto dto)
        {
            var playerOrig = await _playerService.GetByEmailAsync(new Email(dto.playerOrig));
            var playerDest = await _playerService.GetByEmailAsync(new Email(dto.playerDest));
            var relationship = new Relationship(new PlayerId(playerDest.id), new PlayerId(playerOrig.id),
                ConnectionStrength.ValueOf(dto.connection), dto.tags.ConvertAll(tag => new TagId(tag)));

            await _repo.AddAsync(relationship);

            await _unitOfWork.CommitAsync();

            return relationship.ToDto();
        }

        public async Task<RelationshipDto> UpdateAsync(RelationshipDto dto)
        {
            var relationship = await _repo.GetByIdAsync(new RelationshipId(dto.id));

            if (relationship == null)
                return null;

            relationship.ChangePlayerDest(dto.playerDest);
            relationship.ChangePlayerOrig(dto.playerOrig);
            relationship.ChangeConnectionStrength(dto.connectionStrength);
            relationship.ChangeTags(dto.tags.ConvertAll(tag => new TagId(tag)));

            await _unitOfWork.CommitAsync();

            return relationship.ToDto();
        }

        public async Task<RelationshipDto> DeleteAsync(RelationshipId id)
        {
            var relationship = await _repo.GetByIdAsync(id);

            if (relationship == null)
                return null;

            _repo.Remove(relationship);
            await _unitOfWork.CommitAsync();

            return relationship.ToDto();
        }

        public async Task<RelationshipDto> ChangeRelationshipTagConnectionStrength(RelationshipDto dto)
        {
            var relationship =
                await _repo.GetRelationshipBetweenPlayers(new PlayerId(dto.playerOrig),
                    new PlayerId(dto.playerDest));

            if (relationship == null)
            {
                return null;
            }

            relationship.ChangeConnectionStrength(dto.connectionStrength);
            relationship.ChangeTags(dto.tags.ConvertAll(tag => new TagId(tag)));

            await _unitOfWork.CommitAsync();

            var tag = new List<String>();

            foreach (var e in relationship.TagsList)
            {
                tag.Add(e.ToString());
            }

            return new RelationshipDto(relationship.Id.Value, relationship.PlayerDest.Value,
                relationship.PlayerOrig.Value, relationship.ConnectionStrength.Strength, tag);
        }
        public async Task<ActionResult<List<NetworkFromPLayerDTO>>> getNetworkFromPlayer(Email email)
        {
            //throw new NotImplementedException();

            List<Relationship> relationshipDtos = _repo.GetAllAsync().Result;
            List<NetworkFromPLayerDTO> final = new List<NetworkFromPLayerDTO>();
            List<Relationship> temp = new List<Relationship>();
            List<Email> playerIds = new List<Email>();

            playerIds.Add(email);
            while (relationshipDtos.Count != 0)
            {
                if (playerIds.Count != 0)
                {
                    PlayerDto playerDto = _playerService.GetByEmailAsync(playerIds[0]).Result;
                    playerIds.RemoveAt(0);
                    temp = relationshipDtos.FindAll(x =>
                        x.PlayerOrig.Value.Equals(playerDto.id) || x.PlayerDest.Value.Equals(playerDto.id));
                    foreach (var VARIABLE in temp)
                    {
                        relationshipDtos.Remove(VARIABLE);
                    }

                    while (temp.Count != 0)
                    {
                        Relationship relationshipstart = temp[0];
                        Relationship relationshipend = temp.Find(x =>
                            x.PlayerDest.Equals(relationshipstart.PlayerOrig) &&
                            x.PlayerOrig.Equals(relationshipstart.PlayerDest));
                        temp.Remove(relationshipstart);
                        temp.Remove(relationshipend);

                        NetworkFromPLayerDTO temp1 = new NetworkFromPLayerDTO();

                        temp1.Relationships = new List<NetworkFromPLayerDTO>();
                        temp1.playerOriginEmail =
                            _playerService.GetByIdAsync(relationshipstart.PlayerOrig).Result.email;
                        temp1.playerDestEmail = _playerService.GetByIdAsync(relationshipstart.PlayerDest).Result.email;
                        temp1.RelationshipStrengthOrigin = relationshipstart.ConnectionStrength.Strength;
                        temp1.RelationshipStrengthDest = relationshipend.ConnectionStrength.Strength;
                        List<String> tagsstart = new List<string>();
                        for (int i = 0; i < relationshipstart.TagsList.Count; i++)
                        {
                            tagsstart.Add(_tagsService.GetByIdAsync(relationshipstart.TagsList[i]).Result.name);
                        }

                        temp1.RelationshipTagsOrigin = tagsstart;
                        List<String> tagsend = new List<string>();
                        for (int i = 0; i < relationshipend.TagsList.Count; i++)
                        {
                            tagsend.Add(_tagsService.GetByIdAsync(relationshipend.TagsList[i]).Result.name);
                        }

                        temp1.PlayerTagsDest = tagsend;
                        final.Add(temp1);
                        playerIds.Add(new Email(temp1.playerDestEmail));
                    }
                }
            }

            return final;
        }

        public async  Task<List<RelationshipDto>> getRelactionOrigin(string email)
        {
            var player=_playerService.GetByEmailAsync(new Email(email)).Result;
            var list = _repo.GetRelationshipsFromPlayerById(new PlayerId(player.id)).Result;
            var listDTOs = new List<RelationshipDto>();
            foreach (var VARIABLE in list)
            {
                listDTOs.Add(VARIABLE.ToDto());
            }
            return listDTOs;
        }

        public async Task<ActionResult<List<PlayerFriendsDTO>>> Getfriends(Email email)
        {
            var orig=await _playerService.GetByEmailAsync(email);
            var list =await _repo.GetRelationshipsFromPlayerById(new PlayerId(orig.id));
            List<PlayerFriendsDTO> result = new List<PlayerFriendsDTO>();
            PlayerDto temp;
            for (int i = 0; i < list.Count; i++)
            {
                temp = await _playerService.GetByIdAsync(list[i].PlayerDest);
                result.Add(new PlayerFriendsDTO(temp.shortName,temp.email, temp.facebookProfile,temp.linkedinProfile, temp.emotionalStatus, temp.phoneNumber));
            }

            return result;
        }
    }
}