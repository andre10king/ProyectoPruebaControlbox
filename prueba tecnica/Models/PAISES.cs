using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_tecnica.Models
{
    public class PAISES
    {

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public PAISES()
        //{
        //    this.CIUDADEs = new HashSet<CIUDADES>();
        //}

        public int id_pais {get; set; }
        public string nombre { get; set; }
        //public virtual ICollection<CIUDADES> CIUDADEs { get; set; }
        public PAISES()
        {

        }



        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CIUDADES> CIUDADEs { get; set; }

        public PAISES(int Id_pais,string Nombre)
        {
            id_pais = Id_pais;
            nombre = Nombre;

        }

        public PAISES(string Nombre)
        {
            
            nombre = Nombre;

        }
    }
}