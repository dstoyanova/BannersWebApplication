using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannersWebApplication
{
    public class BannerContext : IBannerContext
    {
        private readonly IMongoDatabase _db;

        public BannerContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Banner> Banners => _db.GetCollection<Banner>("dummy_collection");
    }
}
