using System.Collections.Generic;
namespace Entity
{
    public class Recibo
    {
        public int Id {get;set;}
        public string NroRecibo {get;set;}
        public double Total {get; set;}
        public int ClienteId {get;set;}
        public Cliente Cliente {get;set;}
        public IEnumerable<DetalleRecibo> DetalleRecibo {get;set;}
    }
}