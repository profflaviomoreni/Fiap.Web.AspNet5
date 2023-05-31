using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly DataContext dataContext;

        public LojaRepository(DataContext context)
        {
            dataContext = context;
        }
        public IList<LojaModel> FindAll()
        {
            return dataContext.Lojas.ToList();
        }

        public LojaModel? FindById(int id)
        {
            return dataContext.Lojas
                     .Include(l => l.ProdutosLojas)
                        .ThenInclude(p => p.Produto)
                     .SingleOrDefault(l => l.LojaId == id);
        }
    }
}
