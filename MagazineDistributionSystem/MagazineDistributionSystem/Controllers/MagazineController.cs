using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer.Database.Models;
using DataAccessLayer.Database.Services;

namespace MagazineDistributionSystem.Controllers
{
    public class MagazineController : ApiController
    {
        [HttpGet]
        public MagazineDTO Get()
        {
            try
            {
                using (MagazineService service = new MagazineService())
                {
                    return service.GetAll().Where(x => x.MagazineID == "MAG001").ToArray()[0];
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
