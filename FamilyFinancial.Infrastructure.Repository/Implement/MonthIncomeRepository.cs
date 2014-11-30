using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Domain.Repositories;

namespace FamilyFinancial.Infrastructure.Repository.Implement
{
    public class MonthIncomeRepository : EntiryframeworkRepository<MonthIncome,Guid>,IMonthIncomeRepository
    {
        public MonthIncomeRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}
