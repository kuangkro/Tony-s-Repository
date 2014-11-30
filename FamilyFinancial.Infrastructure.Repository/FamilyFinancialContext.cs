using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using FamilyFinancial.Common.Log;
using FamilyFinancial.Domain.ValueObject;
using FamilyFinancial.Infrastructure.Repository.Mapper;

namespace FamilyFinancial.Infrastructure.Repository
{
    class FamilyFinancialContext:DbContext
    {
        public FamilyFinancialContext():base("name=SqlConntection")
        {
            if(!this.Database.Exists())
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<FamilyFinancialContext>());
            }else
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FamilyFinancialContext>());
            }
            this.Configuration.LazyLoadingEnabled = true;
        }

        public ILog Log { get; private set; }

        public IEnumerable<IEntityMapper> EntityMappers
        {
            get
            {
                var lt = new List<IEntityMapper>();
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type[] types = assembly.GetTypes().Where(p => p.Namespace != null && p.Namespace.Contains("FamilyFinancial.Infrastructure.Repository.Mapper")).ToArray();
                foreach (var ele in types)
                {
                    if (ele.GetInterface("IEntityMapper") != null && !ele.IsAbstract)
                    {
                        lt.Add(Activator.CreateInstance(ele) as IEntityMapper);
                    }
                }
                return lt;
            }
        }

        /// <summary>
        /// 当模型在创建时候触发的事件
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            if (Configuration == null)
            {
                return;
            }
            foreach (var mapper in EntityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.Entries<ChangeTrackedEntity>()
                .Where(o => o.State == EntityState.Added || o.State == EntityState.Modified)
                .ToList().ForEach(ChangeTrackingMapper.BeforeSaveChanges);

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errors = string.Join(Environment.NewLine, ex.EntityValidationErrors.SelectMany(er => er.ValidationErrors.Select(eve => string.Format("Type:{0},Property:{1},Message:{2}", er.Entry.Entity.GetType().Name, eve.PropertyName, eve.ErrorMessage))));
                if (Log != null)
                    Log.Exception(errors);
                throw;
            }
        }
    }
}
