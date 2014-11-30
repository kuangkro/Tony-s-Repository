using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FamilyFinancial.Domain;
using FamilyFinancial.Domain.Repositories;

namespace FamilyFinancial.Infrastructure.Repository.Implement
{
    public class EntiryframeworkRepository<AggregateRoot, TKey> : Repository<AggregateRoot, TKey>
        where AggregateRoot:class,IAggregateRoot<TKey>
    {
        private readonly EntityframeworkContext _context;
        public EntiryframeworkRepository(IRepositoryContext context)
            :base(context)
        {
            if (context is EntityframeworkContext)
                this._context = context as EntityframeworkContext;
        }

        protected override AggregateRoot DoFind(TKey key)
        {
            return _context.Context.Set<AggregateRoot>().Find(key);
        }

        protected override IEnumerable<AggregateRoot> DoFind(Expression<Func<AggregateRoot, bool>> exp)
        {
            return _context.Context.Set<AggregateRoot>().Where(exp).ToList();
        }
    }
}
