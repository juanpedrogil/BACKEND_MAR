using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Models
{
    public class Perfil
    {
        [Key]
        public int ID_PERFIL { get; set; }

        public string DESC_PERFIL { get; set; }
        public string DESC_CORTA_PERFIL { get; set; }
        public int ESTATUS { get; set; }
        public DateTime UPDATEDATE { get; set; }
        public DateTime LOADDATE { get; set; }
    }
}
