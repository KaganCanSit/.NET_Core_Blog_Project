using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Tüm nesneler içni tek tek Interface tanımlamaktansa bir class atamasıyla methodları oluşturarak, ortak kullanabilirim. Bu durum güncelleme ve değiştirme için kolaylık sağlar. (DRY ilkesi)
    // T Class parametresi var olan sınıfa ait verilmesi yeterli.
    public  interface IGenericDal<T> where T:class 
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);

        //Dışarında parametre almadan tüm veriyi getirecek fonksiyon.
        List<T> GetListAll();
        
        //ID değerine göre içerik getirmek için method.
        T GetById(int id);

        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
