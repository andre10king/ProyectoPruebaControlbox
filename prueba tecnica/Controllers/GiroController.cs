using prueba_tecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace prueba_tecnica.Controllers
{
    public class GiroController : ApiController
    {
        // GET: api/Giro
        public IEnumerable<GIROS> Get()
        {
            GestorGiro gGiro = new GestorGiro();
            return gGiro.getGiro();
        }

        // GET: api/Giro/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Giro
        public bool Post([FromBody] GIROS giro)
        {
            GestorGiro gGiro = new GestorGiro();
            bool res = gGiro.addGiro(giro);

            return res;
        }

        // PUT: api/Giro/5
        public bool Put(int id, [FromBody] GIROS giro)
        {
            GestorGiro gGiro = new GestorGiro();
            bool res =gGiro.updateGiro(id, giro);

            return res;
        }

        // DELETE: api/Giro/5
        public bool Delete(int id)
        {
            GestorGiro gGiro = new GestorGiro();
            bool res = gGiro.deleteGiro(id);

            return res;
        }


        public IHttpActionResult GetGirosById(int GIR_CIUDAD_ID)
        {

            var articles = GestorGiro.GetGirosById(GIR_CIUDAD_ID);

            if (articles == null || !articles.Any())
            {
                return NotFound();
            }

            return Ok(articles);
        }
    }
}
