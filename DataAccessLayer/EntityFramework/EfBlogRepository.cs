using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        //Blog üzerinde Abstarct içerisinde tanımlanan GenericRepository<Blog> sınıfının bir örneğini oluşturuyoruz. Sadece Blog için özellişmiş kullanım.
        public List<Blog> GetListWithCategory()
        {
            using(var c = new Context())
            {
                //Include -> EntityFrameworkCore kütüphanesi içerisinde geliyor.Category Id ile eşleyerek Category Adını döndürüyoruz.
                return c.Blogs.Include(x=>x.Category).ToList();
            }
        }
    }
}
