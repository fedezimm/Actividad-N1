using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhibernateg7
{
  public  class PersonMapping: ClassMapping<Person>
    {
        public PersonMapping()
        {
            Id(s => s.ID, im => im.Generator(Generators.Identity));  // primary key mapping
            Property(s => s.FirstName, pm => pm.NotNullable(true));
            Property(s => s.LastName, pm => pm.NotNullable(true));
            ManyToOne(s => s.Car, mom => mom.Cascade(Cascade.Persist));
        }
    }
}
