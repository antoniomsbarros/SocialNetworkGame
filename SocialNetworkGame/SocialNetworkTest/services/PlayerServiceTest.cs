using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.players;

namespace SocialNetworkTest.services
{
    [TestClass]
    public class PlayerServiceTest
    {
        private class UnitOfWorkMockMock : IUnitOfWork
        {
            public Task<int> CommitAsync()
            {
                return new Task<int>(() => 1);
            }
        }

        private class PlayerRepositoryMock : IPlayerRepository
        {
            private readonly List<Player> _players = new()
            {
                new Player(Email.ValueOf("player1@email.com"), PhoneNumber.ValueOf(("9111111111")),
                    DateOfBirth.ValueOf(new DateTime(1974, 10, 23))),
                new Player(Email.ValueOf("player2@email.com"), PhoneNumber.ValueOf(("9111111112")),
                    DateOfBirth.ValueOf(new DateTime(1975, 10, 23))),
                new Player(Email.ValueOf("player3@email.com"), PhoneNumber.ValueOf(("9111111113")),
                    DateOfBirth.ValueOf(new DateTime(1976, 10, 23))),
                new Player(Email.ValueOf("player4@email.com"), PhoneNumber.ValueOf(("9111111114")),
                    DateOfBirth.ValueOf(new DateTime(1977, 10, 23))),
                new Player(Email.ValueOf("player5@email.com"), PhoneNumber.ValueOf(("9111111115")),
                    DateOfBirth.ValueOf(new DateTime(1978, 10, 23))),
                new Player(Email.ValueOf("player6@email.com"), PhoneNumber.ValueOf(("9111111116")),
                    DateOfBirth.ValueOf(new DateTime(1979, 10, 23)))
            };

            public Task<List<Player>> GetAllAsync()
            {
                return Task.FromResult(_players);
            }

            public Task<Player> GetByIdAsync(PlayerId id)
            {
                throw new NotImplementedException();
            }

            public Task<List<Player>> GetByIdsAsync(List<PlayerId> ids)
            {
                throw new NotImplementedException();
            }

            public Task<Player> AddAsync(Player obj)
            {
                return Task.FromResult(obj);
            }

            public void Remove(Player obj)
            {
                throw new NotImplementedException();
            }

            public Task<Player> GetByEmailAsync(Email email)
            {
                throw new NotImplementedException();
            }

            public Task<int> getNumberofPlayers()
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void CreatePlayerTestEmail()
        {
            Assert.ThrowsException<BusinessRuleValidationException>(() => new Player(Email.ValueOf("invalidemail"),
                PhoneNumber.ValueOf(("9111111111")),
                DateOfBirth.ValueOf(DateTime.Now)));

            Assert.ThrowsException<BusinessRuleValidationException>(() => new Player(Email.ValueOf("invalidemail.com"),
                PhoneNumber.ValueOf(("9111111111")),
                DateOfBirth.ValueOf(DateTime.Now)));

            Assert.IsNotNull(new Player(Email.ValueOf("valid@email.com"), PhoneNumber.ValueOf(("9111111111")),
                DateOfBirth.ValueOf(new DateTime(1974, 10, 23))));
        }

        [TestMethod]
        public void CreatePlayerTestMinAge()
        {
            const int minAge = 16;

            Assert.ThrowsException<BusinessRuleValidationException>(() => new Player(Email.ValueOf("name@example.com"),
                PhoneNumber.ValueOf(("9111111111")),
                DateOfBirth.ValueOf(DateTime.Now)));

            Assert.ThrowsException<BusinessRuleValidationException>(() => new Player(Email.ValueOf("name@example.com"),
                PhoneNumber.ValueOf(("9111111111")),
                DateOfBirth.ValueOf(new DateTime(DateTime.Now.Year - minAge + 1, DateTime.Now.Month,
                    DateTime.Now.Day))));

            Assert.ThrowsException<BusinessRuleValidationException>(() => new Player(Email.ValueOf("name@example.com"),
                PhoneNumber.ValueOf(("9111111111")),
                DateOfBirth.ValueOf(new DateTime(DateTime.Now.Year + minAge, DateTime.Now.Month, DateTime.Now.Day))));

            Assert.IsNotNull(new Player(Email.ValueOf("name@example.com"),
                PhoneNumber.ValueOf(("9111111111")),
                DateOfBirth.ValueOf(new DateTime(DateTime.Now.Year - minAge, DateTime.Now.Month, DateTime.Now.Day))));
        }

        [TestMethod]
        public void CreatePlayer()
        {
            const int minAge = 16;

            var playerService = new PlayerService(new UnitOfWorkMockMock(), new PlayerRepositoryMock());

            var dto = new RegisterPlayerDto
            {
                email = "name@example.com",
                phoneNumber = "9111111111",
                dateOfBirth = new DateTime(DateTime.Now.Year - minAge, DateTime.Now.Month, DateTime.Now.Day),
                fullName = "Peter Michael John",
                shortName = "Peter John",
                emotionalStatus = EmotionalStatusEnum.Admiration
            };

            Assert.IsNull(playerService.AddAsync(dto).Exception);
            dto.email = "invalidemail.com";

            Assert.IsNotNull(playerService.AddAsync(dto).Exception);
        }

        [TestMethod]
        public void GetAllPlayers()
        {
            var playerService = new PlayerService(new UnitOfWorkMockMock(), new PlayerRepositoryMock());
            Assert.IsNotNull(playerService.GetAllAsync());
            Assert.AreEqual(6, playerService.GetAllAsync().Result.Count);
        }
    }
}