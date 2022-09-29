using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Identity kutuphanesi ile hazir gelen tablolarin guncellenmesi icin asagıdaki sekilde miras alinmasi gerekiyor.
    public class AppUser :IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
}
