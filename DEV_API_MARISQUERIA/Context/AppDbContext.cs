using DEV_API_MARISQUERIA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEV_API_MARISQUERIA.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<User> ADM_CAT_USER { get; set; }
        public DbSet<Articulo> ODS_CAT_ARTICULO { get; set; }
        public DbSet<Mesa> ODS_CAT_MESA { get; set; }
        public DbSet<Parametro> ODS_CAT_PARAMETRO { get; set; }
        public DbSet<Perfil> ODS_CAT_PERFIL { get; set; }
        public DbSet<LibroPrecios> ODS_CAT_LIBROPRECIOS { get; set; }
        public DbSet<Ticket> ODS_CAT_TICKET { get; set; }
        public DbSet<Comanda> ODS_TMP_COMANDA { get; set; }
    }
}
