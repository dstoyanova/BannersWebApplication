using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BannersWebApplication.Controllers
{
    [Route("api/Banner")]
    public class BannerController : Controller
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        // GET: api/Banner
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _bannerRepository.GetAllBanners());
        }

        // GET: api/Banner/{id}
        [HttpGet("{id}", Name = "Get")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            var banner = await _bannerRepository.GetBanner(id);

            if (banner == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(banner);
        }

        // GET: api/Banner/{id}/Html
        [HttpGet("{id}/Html", Name = "GetHtml")]
        public async Task<IActionResult> GetHtml(int id)
        {
            var banner = await _bannerRepository.GetBanner(id);
            if (banner == null)
            {
                return NotFound();
            }
            var content = banner.Html;

            return new ContentResult
            {
                Content = content,
                ContentType = "text/html"
            };
        }

        // POST: api/Banner
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Banner banner)
        {
            await _bannerRepository.Create(banner);
            return new OkObjectResult(banner);
        }

        // PUT: api/Banner/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Banner banner)
        {
            var bannerFromDb = await _bannerRepository.GetBanner(id);

            if (bannerFromDb == null)
            {
                return new NotFoundResult();
            }

            banner.Id = bannerFromDb.Id;

            await _bannerRepository.Update(banner);

            return new OkObjectResult(banner);
        }

        // DELETE: api/ApiWithActions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bannerFromDb = await _bannerRepository.GetBanner(id);

            if (bannerFromDb == null)
            {
                return new NotFoundResult();
            }

            await _bannerRepository.Delete(id);

            return new OkResult();
        }
    }
}
