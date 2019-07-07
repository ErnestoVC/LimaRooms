using System.Collections.Generic;
namespace Repository.ViewModel
{
    public class ReciboViewModel
    {
        public int Id {get;set;}
        public string NroRecibo {get;set;}
        public double Total {get;set;}
        public int ClienteId {get;set;}
        public string NombreCliente {get;set;}
        public IEnumerable<DetalleReciboViewModel> DetalleRecibo {get;set;}
    }
}