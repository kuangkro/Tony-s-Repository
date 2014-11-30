using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyFinancial.Domain.ValueObject
{
    public class ChangeTracking
    {

        /// <summary>
        /// Gets or sets the time (in UTC) when the entity was created.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the time (in UTC) when the entity was last modified.
        /// </summary>
        public DateTime ModifiedTime { get; set; }
    }
}
