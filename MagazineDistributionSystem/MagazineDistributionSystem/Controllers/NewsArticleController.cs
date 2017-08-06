using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer.Database.Services;
using DataAccessLayer.Database.Models;

namespace MagazineDistributionSystem.Controllers
{
    public class NewsArticleController : ApiController
    {
        [HttpGet]
        public List<NewsArticleDTO> Get()
        {
            try
            {
                using (NewsArticleService service = new NewsArticleService())
                {
                    return service.GetAll();
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
