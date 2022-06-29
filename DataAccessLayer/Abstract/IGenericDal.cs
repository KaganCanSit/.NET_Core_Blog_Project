using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Tüm nesneler içni tek tek Interface tanımlamaktansa bir class atamasıyla yanı methodları oluşturarak, ortak kullanabilirim. (DRY ilkesi)
    // T Class parametresi var olan 
    public  interface IGenericDal<T> where T:class 
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);

        //Dışarında parametre almadan tüm veriyi getirecek fonksiyon.
        List<T> GetListAll();
        
        //ID değerine göre içerik getirmek için method.
        T GetById(int id);
    }
}
