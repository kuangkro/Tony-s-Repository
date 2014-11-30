using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Domain.Repositories;

namespace FamilyFinancial.Infrastructure.Repository.Implement
{
    public class ExpandRepository : EntiryframeworkRepository<Expand, Guid>, IExpandRepository
    {
        public ExpandRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}
