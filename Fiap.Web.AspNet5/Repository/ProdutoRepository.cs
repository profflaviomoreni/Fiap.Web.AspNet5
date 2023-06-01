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

        public void Delete(int id)
        {
            var produto = new ProdutoModel()
            { 
                ProdutoId = id 
            };

            dataContext.Produtos.Remove(produto);
            dataContext.SaveChanges();
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

        public int Insert(ProdutoModel model)
        {
            dataContext.Produtos.Add(model);
            dataContext.SaveChanges();
            return model.ProdutoId;
        }

        public void Update(ProdutoModel model)
        {
            var lojas = dataContext.ProdutosLojas.Where(l => l.ProdutoId == model.ProdutoId).ToList();
            dataContext.ProdutosLojas.RemoveRange(lojas);

            dataContext.Produtos.Update(model);
            dataContext.SaveChanges();
        }
    }
}
