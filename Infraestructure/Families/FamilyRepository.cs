using LEI_21s5_3dg_41.Domain.Families;
using LEI_21s5_3dg_41.Infrastructure.Shared;

namespace LEI_21s5_3dg_41.Infrastructure.Families
{
    public class FamilyRepository : BaseRepository<Family, FamilyId>, IFamilyRepository
    {
      
        public FamilyRepository(SocialNetworkDbContext context):base(context.Families)
        {
            
        }

    }
}