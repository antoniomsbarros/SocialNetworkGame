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
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public async Task<bool> Authenticate(Username username, Password password)
        {
            var systemUser = await _repo.GetByIdAsync(username);
            return systemUser.Password.Equals(password);
        }

        public async Task<SystemUserCreatedDto> AddAsync(SystemUserDto systemUserDto,
            PlayerPasswordPolicy passwordPolicy)
        {
            var user = CreateSystemUser(systemUserDto, passwordPolicy);
            await _repo.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return new SystemUserCreatedDto(user.Id.Value);
        }

        public async Task<SystemUserCreatedDto> AddAsyncWithoutSave(SystemUserDto systemUserDto,
            PlayerPasswordPolicy passwordPolicy)
        {
            var user = CreateSystemUser(systemUserDto, passwordPolicy);
            await _repo.AddAsync(user);
            return new SystemUserCreatedDto(user.Id.Value);
        }

        private static SystemUser CreateSystemUser(SystemUserDto systemUserDto,
            PlayerPasswordPolicy passwordPolicy)
        {
            return new SystemUser(new Username(systemUserDto.username),
                Password.ValueOf(systemUserDto.password, passwordPolicy));
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

        public async Task SaveChanges()
        {
            await _unitOfWork.CommitAsync();
        }
    }
}