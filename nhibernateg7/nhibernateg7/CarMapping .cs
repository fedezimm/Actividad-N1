using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
namespace nhibernateg7
{
   public class CarMapping:ClassMapping<Car>
    {
        public CarMapping()
        {
            Id(s => s.ID, im => im.Generator(Generators.Identity));
            Property(s => s.Make, pm => pm.NotNullable(true));
            Property(s => s.Model, pm => pm.NotNullable(true));
            Property(s => s.Year, pm => pm.NotNullable(true));
        }
    }
}
