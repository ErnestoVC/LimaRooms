using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Repository.dbcontext;

namespace Repository
{
    public class InmobiliarioRepository : IInmobiliarioRepository
    {
        private ApplicationDbContext context;

        public InmobiliarioRepository (ApplicationDbContext context){
            this.context=context;
        }

        public bool Delete(int id)
        {
            try
            {
                var result = new Inmobiliario();
                result = context.Inmobiliarios.Single(x=>x.Id == id);
                context.Remove(result);
                context.SaveChanges();
            }
            catch(Exception){
                return false;
            }
            return true;
        }

        public Inmobiliario Get(int id)
        {
            var result = new Inmobiliario();
            try
            {
                result = context.Inmobiliarios.Single(x=>x.Id == id);
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Inmobiliario> GetAll()
        {
            var result = new List<Inmobiliario>();
            try
            {
                result = context.Inmobiliarios.ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Inmobiliario e)
        {
            try
            {
                context.Add(e);
                context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Inmobiliario e)
        {
            try{
                var original = context.Inmobiliarios.Single(x=>x.Id == e.Id);

                original.Id = e.Id;
                original.nombre = e.nombre;
                original.direccion = e.direccion;
                original.tipoInmobiliario = e.tipoInmobiliario;
                original.precio = e.precio;

                context.Update(original);
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