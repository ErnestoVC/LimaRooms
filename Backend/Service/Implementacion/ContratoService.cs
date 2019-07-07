using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using Repository;

namespace Service.Implementacion
{
    public class ContratoService : IContratoService
    {
        private IContratoRepository conRep;
        public ContratoService(IContratoRepository conRep)
        {
            this.conRep=conRep;
        }

        public bool Delete(int id)
        {
            return conRep.Delete(id);
        }

        public IEnumerable fetchByDate(DateTime inicio, DateTime fin)
        {
            return conRep.fetchByDate(inicio,fin);
        }

        public IEnumerable fetchByExpirar()
        {
            return conRep.fetchByExpirar();
        }

        public Contrato Get(int id)
        {
            return conRep.Get(id);
        }

        public IEnumerable<Contrato> GetAll()
        {
            return conRep.GetAll();
        }

        public bool Save(Contrato e)
        {
            return conRep.Save(e);
        }

        public bool Update(Contrato e)
        {
            return conRep.Update(e);
        }
    }
}