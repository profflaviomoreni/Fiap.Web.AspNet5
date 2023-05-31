using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext context)
        {
            dataContext = context;
        }

        public IList<ProdutoModel> FindAll()
        {
            return dataContext.Produtos.ToList();
        }

        public ProdutoModel? FindById(int id)
        {
            return dataContext
                    .Produtos
                        .Include(p => p.ProdutosLojas) // inner join PRODUTO LOJA
                            .ThenInclude(l => l.Loja)  // inner joing LOJA
                        .SingleOrDefault(p => p.ProdutoId == id);
        }
    }
}
