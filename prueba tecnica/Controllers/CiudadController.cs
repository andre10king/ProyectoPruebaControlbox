using prueba_tecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Web;

namespace prueba_tecnica.Controllers
{
    public class CiudadController : ApiController
    {
        // GET: api/Ciudad
        public IEnumerable<CIUDADES> Get()
        {
            GestorCiudad gCiudad = new GestorCiudad();
            return gCiudad.getCiudad();
        }

        // GET: api/Ciudad/5
        //public string Get(int id)
        //{
        //    return "value";


        // GET api/<controller>/5
        public CIUDADES Get(int id)
        {
            return GestorCiudad.Obtener(id);
        }















        [HttpGet]
        public IHttpActionResult GetArticlesByName(string nombre)
        {

            var articles = GestorCiudad.GetArticlesByName(nombre);

            if (articles == null || !articles.Any())
            {
                return NotFound();
            }

            return Ok(articles);
        }



        [HttpGet]
        public IHttpActionResult GetCiudadesById(int id_pais)
        {

            var articles = GestorCiudad.GetCiudadesById(id_pais);

            if (articles == null || !articles.Any())
            {
                return NotFound();
            }

            return Ok(articles);
        }





        // POST: api/Ciudad
        public bool Post([FromBody] CIUDADES ciudad)
        {
            GestorCiudad gCiudad = new GestorCiudad();
            bool res = gCiudad.addCiudad(ciudad);

            return res;
        }

        // PUT: api/Ciudad/5
        public bool Put(int id, [FromBody] CIUDADES ciudad)
        {
            GestorCiudad gCiudad = new GestorCiudad();
            bool res = gCiudad.updateCiudad(id, ciudad);

            return res;
        }

        // DELETE: api/Ciudad/5
        public bool Delete(int id)
        {
            GestorCiudad gCiudad = new GestorCiudad();
            bool res = gCiudad.deleteCiudad(id);

            return res;
        }
    }
}
