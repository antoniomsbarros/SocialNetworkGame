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

        public async Task<PlayerDto> GetByEmailAsync(Email email)
        {
            var player = await this._repo.GetByEmailAsync(email);

            if (player == null)
                return null;

            return player.ToDto();
        }

        public async Task<PlayerDto> AddAsync(RegisterPlayerDto playerDto)
        {
            Player player = new Player(Email.ValueOf(playerDto.email), PhoneNumber.ValueOf(playerDto.phoneNumber),
                FacebookProfile.ValueOf(playerDto.facebookProfile), LinkedinProfile.ValueOf(playerDto.linkedinProfile),
                DateOfBirth.ValueOf(playerDto.dateOfBirth), Name.ValueOf(playerDto.shortName, playerDto.fullName),
                EmotionalStatus.ValueOf(playerDto.emotionalStatus));

            await this._repo.AddAsync(player);
            await this._unitOfWork.CommitAsync();

            return player.ToDto();
        }
    }
}