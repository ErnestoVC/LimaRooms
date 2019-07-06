using Entity;
using Microsoft.EntityFrameworkCore;
namespace Repository.dbcontext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Inmobiliario> Inmobiliarios {get;set;}
        public DbSet<Recibo> Recibos {get;set;}
        public DbSet<DetalleRecibo> DetealleRecibos {get;set;}
        public DbSet<Contrato> Contratos {get;set;}
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) {

        }
    }
}