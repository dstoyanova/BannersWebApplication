using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannersWebApplication
{
    public interface IBannerContext
    {
        IMongoCollection<Banner> Banners { get; }
    }
}
