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


        public IList<ClienteModel> FindAllOrderByNome()
        {
            var lista = dataContext
                .Clientes // SELECT * FROM Clientes
                    .Include(r => r.Representante) // INNER JOIN
                    .OrderBy(c => c.Nome)
                        .ToList();

            return lista == null ? new List<ClienteModel>() : lista ;
        }


        public IList<ClienteModel> FindAllOrderByNomeDesc()
        {
            var lista = dataContext
                .Clientes // SELECT * FROM Clientes
                    .Include(r => r.Representante) // INNER JOIN
                    .OrderByDescending(c => c.Nome)
                        .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
        }

        public IList<ClienteModel> FindByNome(string nome)
        {
            var lista = dataContext
                .Clientes // SELECT * FROM Clientes
                    .Include(r => r.Representante) // INNER JOIN
                    .Where( c => c.Nome.ToLower().Contains(nome.ToLower()) )  // WHERE Contans = LIKE
                    .OrderBy(c => c.Nome)          // ORDER BY
                        .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
        }


        public IList<ClienteModel> FindByNomeAndEmail(string nome, string email)
        {
            var lista = dataContext
                .Clientes // SELECT * FROM Clientes
                    .Include(r => r.Representante) // INNER JOIN
                    .Where(
                            c => c.Nome.ToLower().Contains(nome.ToLower()) && 
                                 c.Email.ToLower().Contains(email.ToLower())
                          )                                                 // WHERE Contans = LIKE
                    .OrderBy(c => c.Nome)          // ORDER BY
                        .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
        }


        public IList<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int repreId)
        {
            var lista = dataContext
                .Clientes // SELECT * FROM Clientes
                    .Include(r => r.Representante) // INNER JOIN
                    .Where(
                            c => ( string.IsNullOrEmpty(nome)   || c.Nome.ToLower().Contains(nome.ToLower())  ) &&
                                 ( string.IsNullOrEmpty(email)  || c.Email.ToLower().Contains(email.ToLower()) ) &&
                                 ( repreId == 0                 || c.RepresentanteId == repreId )
                          )                                                 // WHERE Contans = LIKE
                    .OrderBy(c => c.Nome)          // ORDER BY
                        .ToList();

            return lista == null ? new List<ClienteModel>() : lista;
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
