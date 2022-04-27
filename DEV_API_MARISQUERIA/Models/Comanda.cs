using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Models
{
    public class Comanda
    {
        [Key]
        public int ID_COMANDA { get; set; }

        public int ID_USUARIO { get; set; }
        public int ID_MESA { get; set; }
        public int ID_ARTICULO { get; set; }
        public int CANTIDAD { get; set; }
        public string COMENTARIOS { get; set; }
        public DateTime FECHA_TIEMPO { get; set; }
        public int ESTATUS { get; set; }
        public DateTime LOADDATE { get; set; }
    }
}
