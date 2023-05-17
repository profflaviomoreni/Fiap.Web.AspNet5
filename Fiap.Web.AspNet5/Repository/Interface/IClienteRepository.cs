﻿using Fiap.Web.AspNet5.Models;

namespace Fiap.Web.AspNet5.Repository.Interface
{
    public interface IClienteRepository
    {
        public IList<ClienteModel> FindAll();
        public IList<ClienteModel> FindAllWithRepresentante();
        public IList<ClienteModel> FindAllOrderByNome();
        public IList<ClienteModel> FindAllOrderByNomeDesc();
        public IList<ClienteModel> FindByNome(string nome);
        public IList<ClienteModel> FindByNomeAndEmail(string nome, string email);
        public IList<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int repreId);
        public ClienteModel? FindById(int id);
        public ClienteModel? FindByIdWithRepresentante(int id);
        public void Insert(ClienteModel clienteModel);
        public void Update(ClienteModel clienteModel);
        public void Delete(ClienteModel clienteModel);
        public void Delete(int id);

    }
}
