using LEI_21s5_3dg_41.Domain.Products;
using LEI_21s5_3dg_41.Infrastructure.Shared;

namespace LEI_21s5_3dg_41.Infrastructure.Products
{
    public class ProductRepository : BaseRepository<Product, ProductId>,IProductRepository
    {
        public ProductRepository(LEI_21s5_3dg_41DbContext context):base(context.Products)
        {
           
        }
    }
}