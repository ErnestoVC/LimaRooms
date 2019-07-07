using System;
using System.Collections;
using Entity;

namespace Service
{
    public interface IContratoService : IService<Contrato>
    {
         IEnumerable fetchByDate (DateTime inicio, DateTime fin);
         IEnumerable fetchByExpirar ();
    }
}