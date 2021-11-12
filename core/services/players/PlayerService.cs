using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.infrastructure.relationships;

namespace SocialNetwork.core.services.players
{
    public class PlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _repo;
        private readonly IRelationshipRepository _repoRela;

        public PlayerService(IUnitOfWork unitOfWork, IPlayerRepository repo, IRelationshipRepository repoRela)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
            _repoRela = repoRela;
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            return list.ConvertAll<PlayerDto>(player => player.ToDto());
        }

        public async Task<PlayerDto> GetByIdAsync(PlayerId id)
        {
            var player = await this._repo.GetByIdAsync(id);

            if (player == null)
                return null;

            return player.ToDto();
        }

        public PlayerDto GetByIdAsyncDaniel(PlayerId id)
        {
            var player =  this._repo.GetPlayerId(id);

            if (player == null)
                return null;

            return player.ToDto();
        }

        public async Task<List<PlayerEmailDto>> GetPlayerFriends(List<string> relationship)
        {

            List<Relationship> relations = new List<Relationship>();
            List<Player> friends = new List<Player>();
            List<PlayerEmailDto> friendsdto = new List<PlayerEmailDto>();

            foreach(var r in relationship)
            {
                relations.Add(_repoRela.GetByIdAsync(new RelationshipId(r)).Result);
            }

            foreach(var r in relations)
            {
                friends.Add(_repo.GetByIdAsync(r.PlayerDest).Result);
            }

            foreach(var r in friends)
            {
                friendsdto.Add(new PlayerEmailDto(r.Email.EmailAddress, r.Profile.Name.FullName));
            }

            return friendsdto;
        }

        // To continue

        /*
        public async Task<PlayerDto> AddPlayer(PlayerDto player)
        {
            
            
            
            this._repo.AddAsync()
        }
        */
    }
}