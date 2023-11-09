using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_tecnica.Models
{
    public class GIROS
    {
        public int GIR_GIRO_ID { get; set; }
        public string GIR_RECIBO { get; set; }
        public int GIR_CIUDAD_ID { get; set; }

        public GIROS()
        {

        }

        public GIROS(int Id, string Gir_recibo, int Gir_ciudad_id)
        {
            GIR_GIRO_ID = Id;
            GIR_RECIBO = Gir_recibo;
            GIR_CIUDAD_ID = Gir_ciudad_id;


        }
        public GIROS(string Gir_recibo)
        {
            GIR_RECIBO = Gir_recibo;
        }

    }
}