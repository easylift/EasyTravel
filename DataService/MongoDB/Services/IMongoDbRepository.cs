using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataService.MongoDB.Services
{
   public  interface IMongoDbRepository<T> where T:class 
    {
        bool Insert(T entity);
       
        bool Update(T entity);
     
        bool Delete(T entity);
        
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        
        IEnumerable<T> GetAll();
       
        T GetById(Guid id);
    }
}
