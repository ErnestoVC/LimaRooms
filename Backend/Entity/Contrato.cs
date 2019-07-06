using System;
namespace Entity
{
    public class Contrato
    {
        public int Id {get;set;}
        public int ClienteId {get;set;}
        public Cliente Cliente {get;set;}
        public int InmobiliarioId {get;set;}
        public Inmobiliario Inmobiliario {get;set;}
        public DateTime Inicio {get;set;}
        public DateTime Fin {get;set;}
        public string tipoContrato {get;set;}
    }
}