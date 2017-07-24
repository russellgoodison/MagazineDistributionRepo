using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer.Database.Models;
using DataAccessLayer.Database.Controllers;

namespace MagazineDistributionSystem.Controllers
{
    public class MagazineController : ApiController
    {
        [HttpGet]
        public List<MagazineDTO> Get()
        {
            try
            {
                using (MagazineService service = new MagazineService())
                {
                    return service.GetAll();
                }
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
