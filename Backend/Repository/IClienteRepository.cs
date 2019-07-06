using System.Collections;
using System.Collections.Generic;
using Entity;

namespace Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
         IEnumerable fetchClienteByDni(string dni);
         IEnumerable fetchClienteByNombre(string nombre);
    }
}