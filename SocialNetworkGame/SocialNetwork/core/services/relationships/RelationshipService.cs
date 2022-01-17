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

        public async Task<PlayersRelationshipDto> GetRelationshipBetweenTwoPlayers(PlayerId playerOrig, PlayerId playerDest)
        {
            var result = new PlayersRelationshipDto();

            var playerFrom = await _playerService.GetByIdAsync(playerOrig);
            var playerTo = await _playerService.GetByIdAsync(playerDest);

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

        public async Task<ActionResult<List<PlayerFriendsDTO>>> GetFriends(Email email)
        {
            var orig = await _playerService.GetByEmailAsync(email);
            var list = await _repo.GetRelationshipsFromPlayerById(new PlayerId(orig.id));
            List<PlayerFriendsDTO> result = new List<PlayerFriendsDTO>();
            PlayerDto temp;
            for (int i = 0; i < list.Count; i++)
            {
                temp = await _playerService.GetByIdAsync(list[i].PlayerDest);
                result.Add(new PlayerFriendsDTO(temp.shortName, temp.email, temp.facebookProfile, temp.linkedinProfile,
                    temp.emotionalStatus, temp.phoneNumber));
            }

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
                PlayerName = player.shortName,
                PlayerEmail = player.email,
                EmotionalStatus = player.emotionalStatus,
                Relationships = new()
            };

            List<NetworkFromPlayerPerspectiveDto> notVisitedPlayers = new(), nextDepthPlayers = new();

            List<Relationship> visitedRelationships = new();
            notVisitedPlayers.Add(network);

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
                            PlayerName = playerTo.shortName,
                            PlayerEmail = playerTo.email,
                            EmotionalStatus = playerTo.emotionalStatus,
                            Relationships = new()
                        };

                        nextPlayer.Relationships ??= new();
                        nextPlayer.Relationships.Add(playerToNetwork);

                        playerToNetwork.RelationshipTags = relationship.TagsList.ConvertAll(t =>
                            _tagsService.GetByIdAsync(new TagId(t.Value)).Result.name);

                        playerToNetwork.RelationshipStrength = relationship.ConnectionStrength.Strength;

                        var oppositeRelationship =
                            await _repo.GetRelationshipBetweenPlayers(new PlayerId(playerTo.id),
                                new PlayerId(nextPlayer.PlayerId));

                        playerToNetwork.Relationships.Add(
                            new NetworkFromPlayerPerspectiveDto
                            {
                                PlayerId = nextPlayer.PlayerId,
                                PlayerEmail = nextPlayer.PlayerEmail,
                                Relationships = new(),
                                RelationshipStrength = oppositeRelationship.ConnectionStrength.Strength,
                                RelationshipTags = oppositeRelationship.TagsList.ConvertAll(t =>
                                    _tagsService.GetByIdAsync(new TagId(t.Value)).Result.name)
                            }
                        );

                        visitedRelationships.Add(oppositeRelationship);

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

       
    }
}