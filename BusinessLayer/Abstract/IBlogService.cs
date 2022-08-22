using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void BlogAdd(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);

        List<Blog> GetList();
        Blog GetById(int id);

        //Abstract içerisinde Generix Repository dışında Blog için özel olarak tanımladığımız ve içerisini EntityFremework içerisinde dolduarark oluşturduğumuz methodu burada çağırıyoruz.
        List<Blog> GetBlockListWithCategory();

        List<Blog> GetBlogListByWriter(int id);
    }
}
