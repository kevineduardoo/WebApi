using Microsoft.EntityFrameworkCore;
using Webapi.Models;

namespace Webapi.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        { 
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
       
    }
}
