using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;

namespace FamilyFinancial.Domain.Repositories
{
    public interface IAccountRepository:IRepository<Account,int>
    {
    }
}
