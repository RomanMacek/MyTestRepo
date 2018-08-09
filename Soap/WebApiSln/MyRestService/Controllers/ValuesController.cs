using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MyRestService.Business;
using MyRestService.Business.Interfaces;

namespace MyRestService.Controllers
{
    public class ValuesController : ApiController
    {
        private IUserBusiness _userBusiness;
        public ValuesController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // GET api/values
        [System.Web.Http.HttpGet]
        public IEnumerable<string> Get()
        {
            return _userBusiness.GetAllValues();

        }

        // GET api/values/5
        [System.Web.Http.HttpGet]
        [ValidateAntiForgeryToken]
        public IHttpActionResult Get(int id)
        {
            var result = _userBusiness.GetOneValue(id);
            if (result == null)
            {
                
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [System.Web.Http.HttpPost]
        public void ProdessOrder(Order order)
        {
            // https://www.wug.cz/zaznamy/224-ASP-NET-Web-API-od-A-do-Z
            // cca 28 min

            // protoze tomu posilam nejaky objekt "Order", tak to namapuji na metodu post [HttpPost]
            // ted musim jeste nejak zadat MapHttpRoutte
            //      zatim mam v HttpRoute definovano jen
            //                  config.Routes.MapHttpRoute(
            //name: "DefaultApi",
            //routeTemplate: "api/{controller}/{id}",
            //defaults: new { id = RouteParameter.Optional }
            //      kde vlastne rikam, ze parametr ID je nepovinny
            //pokud chci do URL predat objekt, tak to muzu 
            //          1] predavat parametry primo v URL, ale pokud by jich bylo hodne, tak uz by byla URL necitelna a celkove bluaa
            //          2]
        }
    }
}
