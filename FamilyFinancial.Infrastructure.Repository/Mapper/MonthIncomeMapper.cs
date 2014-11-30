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
    class MonthIncomeMapper:EntityTypeConfiguration<MonthIncome>,IEntityMapper
    {
        public MonthIncomeMapper()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //无需映射到数据库
            //this.Property(p => p.MonthTotalMoney).IsRequired();
            this.HasMany(p => p.Items).WithRequired(p => p.MonthIncome);
        }


        public void RegistTo(System.Data.Entity.ModelConfiguration.Configuration.ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}
