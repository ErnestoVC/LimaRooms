using System.Collections.Generic;
using Entity;
using Repository.ViewModel;

namespace Service
{
    public interface IReciboService : IService<Recibo>
    {
        IEnumerable<ReciboViewModel> GetAllRecibos();
        IEnumerable<DetalleReciboViewModel> ListarDetalles (int reciboId);
    }
}