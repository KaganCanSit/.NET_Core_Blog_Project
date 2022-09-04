using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        //Abstract içerisinde Generix Repository dışında Blog için özel olarak tanımladığımız ve içerisini EntityFremework içerisinde dolduarark oluşturduğumuz methodu burada çağırıyoruz.
        List<Blog> GetBlockListWithCategory();

        List<Blog> GetBlogListByWriter(int id);
    }
}
