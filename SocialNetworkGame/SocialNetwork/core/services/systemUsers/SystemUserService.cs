using System.Threading.Tasks;
using SocialNetwork.core.model.players.application;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.systemUsers.domain;
using SocialNetwork.core.model.systemUsers.dto;
using SocialNetwork.core.model.systemUsers.repository;

namespace SocialNetwork.core.services.systemUsers
{
    public class SystemUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemUserRepository _repo;

        public SystemUserService(IUnitOfWork unitOfWork, ISystemUserRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<SystemUserCreatedDto> AddAsync(SystemUserDto systemUserDto,
            PlayerPasswordPolicy passwordPolicy)
        {
            SystemUser user = new SystemUser(new Username(systemUserDto.username),
                Password.ValueOf(systemUserDto.password, passwordPolicy));

            await this._repo.AddAsync(user);
            await this._unitOfWork.CommitAsync();

            return new SystemUserCreatedDto(user.Id.Value);
        }

        public async Task<SystemUserDto> DeleteAsync(Username username)
        {
            var user = await _repo.GetByIdAsync(username);

            if (user == null)
                return null;

            _repo.Remove(user);
            await _unitOfWork.CommitAsync();

            return user.ToDto();
        }
    }
}