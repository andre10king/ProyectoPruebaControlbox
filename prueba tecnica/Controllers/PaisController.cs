using prueba_tecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace prueba_tecnica.Controllers
{
    public class PaisController : ApiController
    {
        // GET: api/Pais
        public IEnumerable<PAISES> Get()
        {
            GestorPais gPais = new GestorPais();
            return gPais.getPais();
        }

        // GET: api/Pais/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pais
        public bool Post([FromBody]PAISES pais)
        {
            GestorPais gPais = new GestorPais();
            bool res = gPais.addPais(pais);

            return res;
        }

        // PUT: api/Pais/5
        public bool Put(int id, [FromBody] PAISES pais)
        {
            GestorPais gPais = new GestorPais();
            bool res = gPais.updatePais(id, pais);

            return res;
        }

        // DELETE: api/Pais/5
    
        public bool Delete(int id)
        {
            GestorPais gPais = new GestorPais();
            bool res = gPais.deletePais(id);

            return res;
        }
    }
}
