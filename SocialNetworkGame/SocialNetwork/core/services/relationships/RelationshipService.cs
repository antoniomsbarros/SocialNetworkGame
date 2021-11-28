using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.services.players;
using SocialNetwork.infrastructure.relationships;

namespace SocialNetwork.core.services.relationships
{
    public class RelationshipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelationshipRepository _repo;
        private readonly PlayerService _playerService;

        public RelationshipService(IUnitOfWork unitOfWork, IRelationshipRepository repo, PlayerService playerService)
        {
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

        public async Task<List<PlayerEmailDto>> GetRelationByEmail(string email)
        {
            var player = await _playerService.GetByEmailAsync(new Email(email));

            var relationships = await this._repo.GetRelationshipsFriendsById(new PlayerId(player.id));

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
            PlayerDto currentPlayerDto = await _playerService.GetByEmailAsync(email);
            if (currentPlayerDto == null)
                return null;

            NetworkFromPlayerPerspectiveDto network = new()
            {
                PlayerId = currentPlayerDto.id,
                PlayerName = currentPlayerDto.fullName,
                PlayerTags = currentPlayerDto.tags,
                Relationships = new()
            };

            List<NetworkFromPlayerPerspectiveDto> notVisitedPlayers = new(), nextDepthPlayers = new();

            List<Relationship> visitedRelationships = new();
            notVisitedPlayers.Add(network);

            for (int currentDepth = 1; currentDepth <= depth; currentDepth++)
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
                    foreach (var relationship in await _repo.GetRelationshipsFriendsById(
                        new PlayerId(nextPlayer.PlayerId)))
                    {
                        if (visitedRelationships.Contains(relationship) ||
                            relationship.PlayerDest.Value.Equals(currentPlayerDto.id))
                            continue;
                        visitedRelationships.Add(relationship);

                        var playerTo = await _playerService.GetByIdAsync(relationship.PlayerDest);
                        var playerToNetwork = new NetworkFromPlayerPerspectiveDto
                        {
                            PlayerId = playerTo.id,
                            PlayerName = playerTo.fullName,
                            RelationshipId = relationship.Id.Value,
                        };

                        nextPlayer.Relationships ??= new();
                        nextPlayer.Relationships.Add(playerToNetwork);

                        if (nextPlayer.PlayerId.Equals(currentPlayerDto.id))
                        {
                            playerToNetwork.RelationshipTags = relationship.TagsList.ConvertAll(t => t.Value);
                            playerToNetwork.PlayerTags = playerTo.tags;
                            playerToNetwork.RelationshipStrength = relationship.ConnectionStrength.Strength;
                        }
                        else
                            playerToNetwork.RelationshipStrength = null;

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
            var relationship = new Relationship(new PlayerId(dto.playerDest), new PlayerId(dto.playerOrig),
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
            relationship.ChangeConnectionStrength(dto.connection);
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
                await _repo.GetRelationshipOfPlayerFromTo(Email.ValueOf(dto.playerOrig),
                    Email.ValueOf(dto.playerDest));

            if (relationship == null)
            {
                return null;
            }

            relationship.ChangeConnectionStrength(dto.connection);
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