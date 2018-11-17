using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Uklon_WebApplication.Interfaces
{
   public  interface IRepository<T> where T : class
    {
        List<T> Entities { get; }
        T Create(T item);
        T Update(T item);
        T Edit(int id);
        T GetEntity(int id);
    }
}
