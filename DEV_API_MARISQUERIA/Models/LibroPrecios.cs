using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Models
{
    public class LibroPrecios
    {
        public int ID_ARTICULO { get; set; }
        public float AMT_COSTO { get; set; }
        public float AMT_COSTO_SINIVA { get; set; }
        public float AMT_PRECIO { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public DateTime LOADDATE { get; set; }
    }
}
