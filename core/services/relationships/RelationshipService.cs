using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.DTO;
using SocialNetwork.infrastructure.relationships;

namespace SocialNetwork.core.services.relationships
{
    public class RelationshipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelationshipRepository _repo;

        public RelationshipService(IUnitOfWork unitOfWork, IRelationshipRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<RelationshipDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            var listDto = new List<RelationshipDto>();
            list.ForEach(r => listDto.Add(r.toDTO()));
            return listDto;
        }

        public async Task<RelationshipDto> GetByIdAsync(RelationshipId id)
        {
            var cat = await this._repo.GetByIdAsync(id);

            if (cat == null)
                return null;

            return cat.toDTO();
        }

        public async Task<RelationshipDto> AddAsync(RelationshipPostDto dto)
        {
            Guid guid = Guid.NewGuid();
            PlayerId playerDest = new PlayerId(dto.playerDest);
            PlayerId playerOrig = new PlayerId(dto.playerOrig);
            ConnectionStrenght connectionStrenght = new ConnectionStrenght(dto.connection);
            List<Tag> tagList = new List<Tag>();
            dto.tags.ForEach(tag => tagList.Add(new Tag(tag)));
            var Relationship = new Relationship(playerDest, playerOrig, connectionStrenght, tagList);

            await this._repo.AddAsync(Relationship);

            await this._unitOfWork.CommitAsync();

            return Relationship.toDTO();
        }

        public async Task<RelationshipDto> UpdateAsync(RelationshipDto dto)
        {
            var Relationship = await this._repo.GetByIdAsync(new RelationshipId(dto.id));

            if (Relationship == null)
                return null;

            Relationship.ChangePlayerDest(dto.playerDest);
            Relationship.ChangePlayerOrig(dto.playerOrig);
            Relationship.ChangeConnectionStrenght(dto.connection);
            Relationship.ChangeTags(dto.tags);

            await this._unitOfWork.CommitAsync();

            return Relationship.toDTO();
        }

        public async Task<RelationshipDto> InactivateAsync(RelationshipId id)
        {
            var Relationship = await this._repo.GetByIdAsync(id);

            if (Relationship == null)
                return null;

            // change all fields
            //TODO inactive if necessary
            //Relationship.MarkAsInative();

            await this._unitOfWork.CommitAsync();

            return Relationship.toDTO();
        }

        public async Task<RelationshipDto> DeleteAsync(RelationshipId id)
        {
            var Relationship = await this._repo.GetByIdAsync(id);

            if (Relationship == null)
                return null;

            this._repo.Remove(Relationship);
            await this._unitOfWork.CommitAsync();

            return Relationship.toDTO();
        }
    }
}