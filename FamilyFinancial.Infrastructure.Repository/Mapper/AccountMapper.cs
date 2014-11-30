using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;

namespace FamilyFinancial.Infrastructure.Repository.Mapper
{
    class AccountMapper : EntityTypeConfiguration<Account>, IEntityMapper
    {
        public AccountMapper()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.LoginName).IsRequired();
            this.Property(p => p.Password).IsRequired();
        }


        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
