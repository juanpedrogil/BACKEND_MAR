using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Models
{
    public class Mesa
    {
        [Key]
        public int ID_MESA { get; set; }

        public string DESC_MESA { get; set; }
        public string DESC_CORTA_MESA { get; set; }
        public int ESTATUS { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public DateTime LOADDATE { get; set; }
    }
}
