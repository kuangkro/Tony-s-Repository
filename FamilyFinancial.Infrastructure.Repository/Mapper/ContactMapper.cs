using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.ValueObject;

namespace FamilyFinancial.Infrastructure.Repository.Mapper
{
    class ContactMapper : ComplexTypeConfiguration<Contact>,IEntityMapper
    {
        public ContactMapper()
        {
            this.Property(p => p.Email).HasColumnName("ContactEmail").HasMaxLength(50);
            this.Property(p => p.MobileNumber).HasColumnName("ContactMobile").HasMaxLength(50);
            this.Property(p => p.QQ).HasColumnName("ContactQQ").HasMaxLength(50);
            this.Property(p => p.Skype).HasMaxLength(50).HasColumnName("ContactSkype");
        }

        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
