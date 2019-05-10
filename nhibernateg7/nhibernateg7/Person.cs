using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhibernateg7
{
    public class Person
    {
        public virtual int ID { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual Car Car { get; set; }
    }
}
