﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }
        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }

        //Set; var olan nesne içeriğine ulaşmak veya içeriğini yazdırmak için eşleme yapabilmemizi sağlıyor.
        public List<T> GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }
    }
}
