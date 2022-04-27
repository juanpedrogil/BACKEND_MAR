using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Models
{
    public class Ticket
    {
        [Key]
        public int ID_TICKET { get; set; }

        public int ID_ARTICULO { get; set; }
        public int CANTIDAD { get; set; }
        public int SECUENCIA { get; set; }
        public float VENTA_NETA { get; set; }
        public float VENTA_BRUTA { get; set; }
        public DateTime FECHA_TRANSACCION { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_MESA { get; set; } 
        public int ID_FECHA { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public DateTime LOADDATE { get; set; }
    }
}
