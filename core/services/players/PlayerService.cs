using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.services.players
{
    public class PlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _repo;

        public PlayerService(IUnitOfWork unitOfWork, IPlayerRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
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

        // To continue

        /*
        public async Task<PlayerDto> AddPlayer(PlayerDto player)
        {
            
            
            
            this._repo.AddAsync()
        }
        */
    }
}