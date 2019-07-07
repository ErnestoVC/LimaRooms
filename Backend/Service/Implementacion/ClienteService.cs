using System.Collections;
using System.Collections.Generic;
using Entity;
using Repository;

namespace Service.Implementacion
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository clRepos;

        public ClienteService(IClienteRepository clRepos)
        {
            this.clRepos=clRepos;
        }

        public bool Delete(int id)
        {
            return clRepos.Delete(id);
        }

        public IEnumerable fetchClienteByDni(string dni)
        {
            return clRepos.fetchClienteByDni(dni);
        }

        public IEnumerable fetchClienteByNombre(string nombre)
        {
            return clRepos.fetchClienteByNombre(nombre);
        }

        public Cliente Get(int id)
        {
            return clRepos.Get(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return clRepos.GetAll();
        }

        public bool Save(Cliente e)
        {
            return clRepos.Save(e);
        }

        public bool Update(Cliente e)
        {
            return clRepos.Update(e);
        }
    }
}