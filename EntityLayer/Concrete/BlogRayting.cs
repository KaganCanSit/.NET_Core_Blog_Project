using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRayting
    {
        public int BlogRaytingID { get; set; }

        public int BlogID { get; set; }

        public int BlogTotalScore { get; set; }

        public int BlogTotalRayting { get; set; }
    }
}
