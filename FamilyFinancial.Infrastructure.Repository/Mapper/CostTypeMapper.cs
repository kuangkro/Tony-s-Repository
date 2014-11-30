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
    class CostTypeMapper : EntityTypeConfiguration<CostType>, IEntityMapper
    {
        public CostTypeMapper()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Name).IsRequired();
            //TODO:生成的外键存在于表？？
            this.HasOptional(p => p.ParentType).WithMany().Map(key => key.MapKey("ParentId"));
            //TODO:生成的外键存在于表？？
            this.HasMany(p => p.ChildTypes).WithOptional(p => p.ParentType);
        }


        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
