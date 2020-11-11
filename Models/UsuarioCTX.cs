/*using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class UsuarioCTX:DbContext
    {
        public UsuarioCTX(DbContextOptions<UsuarioCTX> options):base (options)
        {

        }
        public DbSet<Usuario> Usuario {get;set}





    }
}*/
using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class UsuarioCTX:DbContext
    {
        public UsuarioCTX(DbContextOptions<UsuarioCTX> options):base (options)
        {

        }
        public DbSet<Usuario> Usuario {get;set;}




    }
}