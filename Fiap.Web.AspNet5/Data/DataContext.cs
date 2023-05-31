using Fiap.Web.AspNet5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Data
{
    public class DataContext : DbContext
    {

        public DbSet<RepresentanteModel> Representantes { get; set; }

        public DbSet<FornecedorModel> Fornecedores { get; set; }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<LojaModel> Lojas { get; set; }

        public DbSet<ProdutoLojaModel> ProdutosLojas { get; set; }



        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
