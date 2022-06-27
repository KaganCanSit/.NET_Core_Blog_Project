using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        /*
         * Context c= new Context ifadesi Class genelinde tanımlanır ve tüm class içerisinde kullanılır. 
         * using var = new Context ifadesi ise sadece yazılı olan method içerisinde kullanılır ve her method için tanımlanmak zorundadır.
         * 
         * Ado Net de SaveChanges'in karşılığı nedir?
         * ExecuteNonQuery()
         */

        Context c = new Context();
        
        public void AddCategory(Category category)
        {
            c.Add(category);
            c.SaveChanges(); //Değişikliklerin kayıt edilmesi için gerekli
        }

        public void DeleteCategory(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public List<Category> ListAllCategory()
        {
            return c.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            c.Update(category);
            c.SaveChanges();
        }
    }
}
