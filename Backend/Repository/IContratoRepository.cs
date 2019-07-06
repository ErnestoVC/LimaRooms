using System;
using System.Collections;
using Entity;

namespace Repository
{
    public interface IContratoRepository : IRepository<Contrato>
    {
         IEnumerable fetchByDate (DateTime inicio, DateTime fin);
         IEnumerable fetchByExpirar ();
    }
}