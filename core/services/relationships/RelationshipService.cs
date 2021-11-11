using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.DTO;
using SocialNetwork.infrastructure.relationships;

namespace lapr5_3dg.Services
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
            var listDto =  new List<RelationshipDto>();
            list.ForEach(r => listDto.Add(r.toDTO()));
            return listDto;
        }

        public async Task<RelationshipDto> GetByIdAsync(RelationshipId id)
        {
            var cat = await this._repo.GetByIdAsync(id);

            if(cat == null)
                return null;

            return cat.toDTO();
        }

        public async Task<RelationshipDto> AddAsync(RelationshipDto dto)
        {
            Player player = new Player();
            ConnectionStrenght connectionStrenght = new ConnectionStrenght();
            List<Tag> tagList = new List<Tag>();
            dto.tags.ForEach(tag => tagList.Add(new Tag(tag)));
            var Relationship = new Relationship(player, connectionStrenght, tagList);

            await this._repo.AddAsync(Relationship);

            await this._unitOfWork.CommitAsync();

            return Relationship.toDTO();
        }

        public async Task<RelationshipDto> UpdateAsync(RelationshipDto dto)
        {
            var Relationship = await this._repo.GetByIdAsync(new RelationshipId(dto.id)); 

            if (Relationship == null)
                return null;   

            // change all field
            Relationship.ChangePlayer(dto.player);
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