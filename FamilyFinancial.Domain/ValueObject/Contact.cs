using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyFinancial.Domain.ValueObject
{
    public class Contact
    {
        public string MobileNumber { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
    }
}
