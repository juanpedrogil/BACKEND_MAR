using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Models
{
    public class Articulo
    {
        [Key]
        public int ID_ARTICULO { get; set; }

        public string DESC_ARTICULO { get; set; }
        public string DESC_CORTA_ARTICULO { get; set; }
        public string UPC_CVE { get; set; }
        public int ESTATUS { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public DateTime LOADDATE { get; set; }
    }
}
