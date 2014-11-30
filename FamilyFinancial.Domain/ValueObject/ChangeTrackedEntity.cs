using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyFinancial.Domain.ValueObject
{
    public class ChangeTrackedEntity
    {
        public ChangeTrackedEntity()
        {
            ChangeTracking = new ChangeTracking();
        }

        public ChangeTracking ChangeTracking { get; set; }
    }
}
