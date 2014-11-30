using System;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Domain.ValueObject;

namespace FamilyFinancial.Domain.Entities
{
    public class IncomeItem:ChangeTrackedEntity
    {
        private IncomeItem(){}
        public IncomeItem(double money,Member createBy,MonthIncome monthIncome):this(money,createBy,IncomeType.Salary,monthIncome)
        {
        }

        public IncomeItem(double money, Member createBy, IncomeType incomeType, MonthIncome monthIncome)
        {
            if (money <= 0)
                throw new Exception("money should be more than zero");
            if (createBy == null)
                throw new Exception("createBy can't be null");

            if (monthIncome == null)
                throw new Exception("monthIncome can't be null");

            this.Money = money;
            this.CreateBy = createBy;
            this.IncomeType = incomeType;
            this.MonthIncome = monthIncome;
        }

        public int Id { get; set; }
        public double Money { get; private set; }
        public IncomeType IncomeType { get; private set; }
        public virtual Member CreateBy { get; private set; }
        public virtual MonthIncome MonthIncome { get; private set; }
    }
}
