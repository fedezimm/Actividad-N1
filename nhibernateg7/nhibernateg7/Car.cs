using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhibernateg7
{
   public  class Car
    {
        public virtual int ID { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual string Year { get; set; }
    }
}
