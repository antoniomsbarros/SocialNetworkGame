using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.core.model.players.application;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.systemUsers.application;
using SocialNetwork.core.model.systemUsers.domain;
using SocialNetwork.core.model.systemUsers.dto;
using SocialNetwork.core.model.systemUsers.repository;
using SocialNetwork.core.services.systemUsers;

namespace SocialNetworkTest.services
{
    [TestClass]
    public class SystemUserServiceTest
    {
        private class UnitOfWorkMockMock : IUnitOfWork
        {
            public Task<int> CommitAsync()
            {
                return new Task<int>(() => 1);
            }
        }

        private class PasswordPolicyMock : IPasswordPolicy
        {
            public bool IsValidPassword(string password)
            {
                return true;
            }

            public PasswordStrength GetPasswordStrength(string password)
            {
                return PasswordStrength.Strong;
            }

            public bool HasMinimumLength(string password, int minLength)
            {
                return true;
            }

            public bool HasMinimumUniqueChars(string password, int minUniqueChars)
            {
                return true;
            }

            public bool HasDigit(string password)
            {
                return true;
            }

            public bool HasSpecialChar(string password)
            {
                return true;
            }

            public bool HasUpperCaseLetter(string password)
            {
                return true;
            }

            public bool HasLowerCaseLetter(string password)
            {
                return true;
            }
        }

        private class SystemUserRepositoryMock : ISystemUserRepository
        {
            private readonly List<SystemUser> _users = new()
            {
                new SystemUser(new Username("username1"), Password.ValueOf("pass1", new PasswordPolicyMock())),
                new SystemUser(new Username("username2"), Password.ValueOf("pass2", new PasswordPolicyMock())),
                new SystemUser(new Username("username3"), Password.ValueOf("pass3", new PasswordPolicyMock())),
                new SystemUser(new Username("username4"), Password.ValueOf("pass4", new PasswordPolicyMock())),
                new SystemUser(new Username("username5"), Password.ValueOf("pass5", new PasswordPolicyMock())),
                new SystemUser(new Username("username6"), Password.ValueOf("pass6", new PasswordPolicyMock())),
                new SystemUser(new Username("username7"), Password.ValueOf("pass7", new PasswordPolicyMock())),
                new SystemUser(new Username("username8"), Password.ValueOf("pass8", new PasswordPolicyMock())),
            };

            public Task<List<SystemUser>> GetAllAsync()
            {
                return Task.FromResult(_users);
            }

            public Task<SystemUser> GetByIdAsync(Username id)
            {
                throw new System.NotImplementedException();
            }

            public Task<List<SystemUser>> GetByIdsAsync(List<Username> ids)
            {
                throw new System.NotImplementedException();
            }

            public Task<SystemUser> AddAsync(SystemUser obj)
            {
                return Task.FromResult<SystemUser>(obj);
            }

            public void Remove(SystemUser obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class PasswordPoliceMock : PlayerPasswordPolicy
        {
            public PasswordPoliceMock(IConfiguration configuration) : base(configuration)
            {
            }

            public bool IsValidPassword(string password)
            {
                return true;
            }
        }

        private class ConfigurationMock : IConfiguration
        {
            public IEnumerable<IConfigurationSection> GetChildren()
            {
                throw new System.NotImplementedException();
            }

            public IChangeToken GetReloadToken()
            {
                throw new System.NotImplementedException();
            }

            public IConfigurationSection GetSection(string key)
            {
                throw new System.NotImplementedException();
            }

            public string this[string key]
            {
                get => throw new System.NotImplementedException();
                set => throw new System.NotImplementedException();
            }
        }

        [TestMethod]
        public void CreateSystemUser()
        {
            var systemUserService = new SystemUserService(new UnitOfWorkMockMock(), new SystemUserRepositoryMock());

            var dto = new SystemUserDto
            {
                username = "username1",
                password = "pass1"
            };

            Assert.IsNotNull(systemUserService.AddAsync(dto, new PasswordPoliceMock(new ConfigurationMock()))
                .Exception);
        }
    }
}