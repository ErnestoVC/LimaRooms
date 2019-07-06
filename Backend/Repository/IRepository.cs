using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T>
    {
         bool  Save(T e);
        bool  Update(T e);
        bool  Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}