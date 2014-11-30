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
    class MemberMapper:EntityTypeConfiguration<Member>,IEntityMapper
    {
        public MemberMapper()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Name).IsRequired();
            this.Property(p => p.Age).IsRequired();
            //无需显示映射Complex属性
            //this.HasOptional(p => p.Contact);
            this.HasRequired(p => p.Account).WithOptional().Map(key => key.MapKey("AccountId"));
        }


        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
