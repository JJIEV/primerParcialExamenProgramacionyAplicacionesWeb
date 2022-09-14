using api.examenparcial1.Models;
using Microsoft.EntityFrameworkCore;

namespace api.examenparcial1.Data
{
    
    public class PrimerParcialApp : DbContext
    {
        public PrimerParcialApp(DbContextOptions<PrimerParcialApp> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente => Set<Cliente>();

        public DbSet<Ciudad> Ciudad => Set<Ciudad>();
    }


}
