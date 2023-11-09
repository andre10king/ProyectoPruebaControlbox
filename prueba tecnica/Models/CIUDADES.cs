using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_tecnica.Models
{
    public class CIUDADES
    {
        public int id_ciudad { get; set; }
        public string nombre { get; set; }
        public int id_pais { get; set; }

        //public virtual PAISES PAISES { get; set; }

        public CIUDADES()
        {

        } 

        public CIUDADES(int Id_ciudad, string Nombre, int Id_pais)
        {
            id_ciudad = Id_ciudad;
            nombre = Nombre;
            id_pais = Id_pais;

        }

        public CIUDADES(string Nombre)
        {

            nombre = Nombre;

        }

    }
}