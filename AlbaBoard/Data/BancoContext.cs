using AlbaBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbaBoard.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        { 
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
