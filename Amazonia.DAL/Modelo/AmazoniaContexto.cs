using Microsoft.EntityFrameworkCore;

namespace Amazonia.DAL.Modelo
{
    public class AmazoniaContexto : DbContext
    {
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
