using System.Collections.Generic;
using Entity;
using Repository;

namespace Service.Implementacion
{
    public class InmobiliarioService : IInmobiliarioService
    {
        private IInmobiliarioRepository inmRep;
        public InmobiliarioService(IInmobiliarioRepository inmRep)
        {
            this.inmRep=inmRep;
        }

        public bool Delete(int id)
        {
            return inmRep.Delete(id);
        }

        public Inmobiliario Get(int id)
        {
            return inmRep.Get(id);
        }

        public IEnumerable<Inmobiliario> GetAll()
        {
            return inmRep.GetAll();
        }

        public bool Save(Inmobiliario e)
        {
            return inmRep.Save(e);
        }

        public bool Update(Inmobiliario e)
        {
            return inmRep.Update(e);
        }
    }
}