using System.Collections.Generic;
using Entity;
using Repository;
using Repository.ViewModel;

namespace Service.Implementacion
{
    public class ReciboService : IReciboService
    {
        public IReciboRepository recRep;
        public ReciboService(IReciboRepository recRep)
        {
            this.recRep = recRep;
        }

        public bool Delete(int id)
        {
            return recRep.Delete(id);
        }

        public Recibo Get(int id)
        {
            return recRep.Get(id);
        }

        public IEnumerable<Recibo> GetAll()
        {
            return recRep.GetAll();
        }

        public IEnumerable<ReciboViewModel> GetAllRecibos()
        {
            return recRep.GetAllRecibos();
        }

        public IEnumerable<DetalleReciboViewModel> ListarDetalles(int reciboId)
        {
            return recRep.ListarDetalles(reciboId);
        }

        public bool Save(Recibo e)
        {
            return recRep.Save(e);
        }

        public bool Update(Recibo e)
        {
            return recRep.Update(e);
        }
    }
}