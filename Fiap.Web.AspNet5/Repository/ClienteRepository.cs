using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet5.Repository
{
    public class ClienteRepository
    {

        private readonly DataContext dataContext;

        public ClienteRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        public IList<ClienteModel> FindAll()
        {
            var lista = dataContext.Clientes.ToList();
            return lista;
        }

        public IList<ClienteModel> FindAllWithRepresentante()
        {
            var lista = dataContext.
                Clientes.Include(r => r.Representante).ToList();

            return lista;
        }


        public ClienteModel? FindById(int id)
        {
            var clienteModel = dataContext.Clientes.Find(id);

            return clienteModel;
        }


        public ClienteModel? FindByIdWithRepresentante(int id)
        {
            var clienteModel = dataContext.Clientes
                    .Include(r => r.Representante)
                    .SingleOrDefault(c => c.ClienteId == id);

            return clienteModel;
        }

        public void Insert(ClienteModel clienteModel)
        {
            dataContext.Clientes.Add(clienteModel);
            dataContext.SaveChanges();
        }

    }
}
