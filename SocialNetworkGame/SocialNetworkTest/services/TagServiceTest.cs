using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.model.tags.dto;
using SocialNetwork.core.model.tags.repository;
using SocialNetwork.core.services.tags;

namespace SocialNetworkTest.services
{
    [TestClass]
    public class TagServiceTest
    {
        private class UnitOfWorkMockMock : IUnitOfWork
        {
            public Task<int> CommitAsync()
            {
                return new Task<int>(() => 1);
            }
        }

        private class TagsServiceRepositoryMock : ITagRepository
        {
            public Task<List<Tag>> GetAllAsync()
            {
                throw new System.NotImplementedException();
            }

            public Task<Tag> GetByIdAsync(TagId id)
            {
                throw new System.NotImplementedException();
            }

            public Task<List<Tag>> GetByIdsAsync(List<TagId> ids)
            {
                throw new System.NotImplementedException();
            }

            public Task<Tag> AddAsync(Tag obj)
            {
                throw new System.NotImplementedException();
            }

            public void Remove(Tag obj)
            {
                throw new System.NotImplementedException();
            }

            public Task<Tag> GetByNameAsync(TagName name)
            {
                throw new System.NotImplementedException();
            }
        }

        [TestMethod]
        public void CreateTag()
        {
            var tagService = new TagsService(new UnitOfWorkMockMock(), new TagsServiceRepositoryMock());

            var dto = new CreateTagDto
            {
                tagName = "new tag"
            };

            Assert.IsNotNull(tagService.AddAsync(dto));
        }
    }
}