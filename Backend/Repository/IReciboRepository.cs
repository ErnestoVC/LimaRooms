using System.Collections.Generic;
using Entity;
using Repository.ViewModel;

namespace Repository
{
    public interface IReciboRepository : IRepository<Recibo>
    {
         IEnumerable<ReciboViewModel> GetAllRecibos();
         IEnumerable<DetalleReciboViewModel> ListarDetalles (int reciboId);
         
    }
}