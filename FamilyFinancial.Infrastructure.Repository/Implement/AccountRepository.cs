using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Domain.Repositories;

namespace FamilyFinancial.Infrastructure.Repository.Implement
{
    public class AccountRepository : EntiryframeworkRepository<Account,int>, IAccountRepository
    {
        public AccountRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}
