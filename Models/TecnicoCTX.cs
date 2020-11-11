using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class TecnicoCTX:DbContext
    {
        public TecnicoCTX(DbContextOptions<TecnicoCTX> options):base (options)
        {

        }
        public DbSet<Tecnico> Tecnico {get;set;}




    }
}