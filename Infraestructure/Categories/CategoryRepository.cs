using LEI_21s5_3dg_41.Domain.Categories;
using LEI_21s5_3dg_41.Infrastructure.Shared;

namespace LEI_21s5_3dg_41.Infrastructure.Categories
{
    public class CategoryRepository : BaseRepository<Category, CategoryId>, ICategoryRepository
    {
    
        public CategoryRepository(LEI_21s5_3dg_41DbContext context):base(context.Categories)
        {
           
        }


    }
}