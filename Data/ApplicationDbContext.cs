using Microsoft.EntityFrameworkCore;
using InventarioSeguro.Models;

namespace InventarioSeguro.Data

{
    public class ApplicationDbContext : DbContext
    {
        public DbSet <Producto> Productos {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base (options)
        {
        }
    }
}