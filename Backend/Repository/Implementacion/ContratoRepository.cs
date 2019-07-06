using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository.dbcontext;

namespace Repository
{
    public class ContratoRepository : IContratoRepository
    {
        private ApplicationDbContext context;

        public ContratoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable fetchByDate(DateTime inicio, DateTime fin)
        {
            var result = new List<Contrato>();
            try
            {
                result = context.Contratos.Where(x=>x.Fin > fin && x.Fin < inicio).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable fetchByExpirar()
        {
            DateTime expirar = DateTime.Now.AddDays(-5);
            var result = new List<Contrato>();
            try
            {
                result = context.Contratos.Where(x=>x.Fin > expirar).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public Contrato Get(int id)
        {
            var result = new Contrato();
            try
            {
                result = context.Contratos.Single(x=>x.Id == id);
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Contrato> GetAll()
        {
            var result = new List<Contrato>();
            try
            {
                result = context.Contratos.Include(c=>c.Inmobiliario).Include(x=>x.Cliente).ToList();
                result.Select(c=> new Contrato{
                    Id=c.Id,
                    Inicio = c.Inicio,
                    Fin = c.Fin,
                    tipoContrato = c.tipoContrato,
                    ClienteId = c.ClienteId,
                    InmobiliarioId = c.InmobiliarioId
                });
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Contrato e)
        {
            try{
                context.Add(e);
                context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Contrato e)
        {
            try
            {
                var orig = context.Contratos.Single(x=>x.Id == e.Id);

                orig.Id = e.Id;
                orig.Inicio = e.Inicio;
                orig.Fin = e.Fin;
                orig.tipoContrato = e.tipoContrato;
                orig.InmobiliarioId = e.InmobiliarioId;
                orig.ClienteId = e.ClienteId;

                context.Update(orig);
                context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}