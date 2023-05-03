using Fiap.Web.AspNet5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Data
{
    public class DataContext : DbContext
    {

        

        public DbSet<FornecedorModel> Fornecedores { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
