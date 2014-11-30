using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.ValueObject;

namespace FamilyFinancial.Infrastructure.Repository.Mapper
{
    class ChangeTrackingMapper : ComplexTypeConfiguration<ChangeTracking>
    {
        public ChangeTrackingMapper()
        {
            this.Property(p => p.CreatedTime).HasColumnName("CreateTime");
            this.Property(p => p.ModifiedTime).HasColumnName("ModifiedTime");
        }

        public static void BeforeSaveChanges(DbEntityEntry<ChangeTrackedEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.ChangeTracking.ModifiedTime = DateTime.Now;
            }


            entityEntry.Entity.ChangeTracking.CreatedTime = DateTime.Now;
        }
    }
}
