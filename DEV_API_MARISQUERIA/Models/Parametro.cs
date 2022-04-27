using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Models
{
    public class Parametro
    {
        [Key]
        public int ID_PARAMETRO { get; set; }

        public string DESC_PARAMETRO { get; set; }
        public string DEFINICION { get; set; }
        public int ESTATUS { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public DateTime LOADDATE { get; set; }
    }
}
