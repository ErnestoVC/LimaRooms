namespace Entity
{
    public class DetalleRecibo
    {
        public int Id {get;set;}
        public int cantidad {get;set;}
        public double adicional {get;set;}
        public int ReciboId {get;set;}
        public Recibo Recibo {get;set;}
        public int InmobiliarioId {get;set;}
        public Inmobiliario Inmobiliario {get;set;}
        
    }
}