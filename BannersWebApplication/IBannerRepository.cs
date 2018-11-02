using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannersWebApplication
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> GetAllBanners();
        Task<Banner> GetBanner(int id);
        Task Create(Banner banner);
        Task<bool> Update(Banner banner);
        Task<bool> Delete(int id);
    }
}
