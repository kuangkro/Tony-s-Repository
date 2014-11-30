using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Domain.Entities;

namespace FamilyFinancial.Infrastructure.Repository.Mapper
{
    class IncomeItemMapper : EntityTypeConfiguration<IncomeItem>, IEntityMapper
    {
        public IncomeItemMapper()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Money).IsRequired();
            this.Property(p => p.IncomeType).IsRequired();
            //this.HasRequired(p => p.CreateBy).WithOptional().Map(key => key.MapKey("MemberId"));
            this.HasRequired(p => p.CreateBy).WithMany().Map(key => key.MapKey("MemberId"));
            this.HasRequired(p => p.MonthIncome).WithMany(p => p.Items).Map(key => key.MapKey("MonthIncomeId"));
        }


        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
