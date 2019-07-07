using System.Collections;
using Entity;

namespace Service
{
    public interface IClienteService : IService<Cliente> 
    {
        IEnumerable fetchClienteByDni(string dni);
        IEnumerable fetchClienteByNombre(string nombre);
    }
}