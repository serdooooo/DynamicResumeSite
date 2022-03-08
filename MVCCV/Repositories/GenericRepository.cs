using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MVCCV.Models.Entity;


namespace MVCCV.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        DbCVEntities db = new DbCVEntities();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }
        public void TDelete(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T t)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}