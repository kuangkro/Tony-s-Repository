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
    class ExpandtMapper : EntityTypeConfiguration<Expand>, IEntityMapper
    {
        public ExpandtMapper()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(p => p.CostType ).WithOptional().Map(key => key.MapKey("CostTypeId"));
            this.Property(p => p.ExpendCost).IsRequired();
            //TODO:生成的外键存在于表？？
            this.HasRequired(p => p.CreateBy).WithOptional().Map(key => key.MapKey("MemberId"));
        }


        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
