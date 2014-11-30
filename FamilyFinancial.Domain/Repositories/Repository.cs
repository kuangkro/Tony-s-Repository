using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FamilyFinancial.Domain.Repositories
{
    public abstract class Repository<AggregateRoot,Tkey> : IRepository<AggregateRoot,Tkey>
        where AggregateRoot:class ,IAggregateRoot<Tkey>
    {
        private IRepositoryContext _context;
        protected Repository(IRepositoryContext context)
        {
            this._context = context;
        }

        public IRepositoryContext Context
        {
            get { return _context; }
        }

        #region 
        public void Add(AggregateRoot entity)
        {
            this._context.RegisterNew<AggregateRoot,Tkey>(entity);
        }

        public void Update(AggregateRoot entity)
        {
            this._context.RegisterModified<AggregateRoot, Tkey>(entity);
        }

        public void Remove(AggregateRoot entity)
        {
            this._context.RegisterDeleted<AggregateRoot, Tkey>(entity);
        }
        #endregion

        #region Query

        public AggregateRoot Find(Tkey key)
        {
            return this.DoFind(key);
        }

        public IEnumerable<AggregateRoot> GetAll(Expression<Func<AggregateRoot, bool>> exp)
        {
            return DoFind(exp);
        }

        #endregion

        #region abstract method

        protected abstract AggregateRoot DoFind(Tkey key);

        protected abstract IEnumerable<AggregateRoot> DoFind(Expression<Func<AggregateRoot, bool>> exp);

        #endregion
    }
}
