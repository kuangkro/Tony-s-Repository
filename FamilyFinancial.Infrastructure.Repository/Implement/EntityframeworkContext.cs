using System;
using System.Data.Entity;
using System.Threading;
using FamilyFinancial.Infrastructure.Repository.Interface;

namespace FamilyFinancial.Infrastructure.Repository.Implement
{
    public class EntityframeworkContext:IEntityframeworkContext
    {
        private readonly string _contextKey = Guid.NewGuid().ToString();
        private readonly ThreadLocal<FamilyFinancialContext> localCtx = new ThreadLocal<FamilyFinancialContext>(() => new FamilyFinancialContext());

        public DbContext Context
        {
            get { return localCtx.Value; }
        }

        public string ID
        {
            get { return _contextKey; }
        }

        public void RegisterNew<TAggregateRoot, TKey>(TAggregateRoot obj) where TAggregateRoot : class, Domain.IAggregateRoot<TKey>
        {
            localCtx.Value.Set<TAggregateRoot>().Add(obj);
        }

        public void RegisterModified<TAggregateRoot, TKey>(TAggregateRoot obj) where TAggregateRoot : class, Domain.IAggregateRoot<TKey>
        {
            localCtx.Value.Entry(obj).State = EntityState.Modified;
        }

        public void RegisterDeleted<TAggregateRoot, TKey>(TAggregateRoot obj) where TAggregateRoot : class, Domain.IAggregateRoot<TKey>
        {
            localCtx.Value.Set<TAggregateRoot>().Remove(obj);
        }

        public bool Commit()
        {
            if(!Commited)
            {
                if (localCtx.Value.SaveChanges() > 0)
                {
                    Commited = true;
                    return true;
                }
                else
                {
                    Commited = false;
                    return false;
                }
            }
            return false;
        }

        public bool Commited { get; set; }

        public void RollBack()
        {
            Commited = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDispose)
        {
            if (isDispose)
            {
                if (!Commited)
                    Commit();
                localCtx.Value.Dispose();
                localCtx.Dispose();
            }
        }
        ~EntityframeworkContext()
        {
            Dispose(false);
        }
    }
}
