using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository.Interface;

namespace Fiap.Web.AspNet5.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {

        private readonly DataContext dataContext;

        public FornecedorRepository(DataContext ctx)
        {
            this.dataContext = ctx;
        }


        public IList<FornecedorModel> FindAll()
        {
            var lista = dataContext.Fornecedores.ToList();
            return lista;
        }


        //FindById (READ)
        public FornecedorModel? FindById(int id)
        {
            return dataContext.Fornecedores.Find(id);
        }


        //Insert (CREATE)
        public int Insert(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Add(fornecedorModel);
            dataContext.SaveChanges();

            return fornecedorModel.FornecedorId;
        }


        //Update
        public void Update(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Update(fornecedorModel);
            dataContext.SaveChanges();
        }



        //Delete
        public void Delete(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Remove(fornecedorModel);
            dataContext.SaveChanges();
        }

        //Delete
        public void Delete(int id)
        {
            var model = new FornecedorModel()
            {
                FornecedorId = id
            };

            Delete(model);
        }

    }
}
