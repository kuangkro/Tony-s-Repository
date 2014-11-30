using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.Entities;

namespace FamilyFinancial.Domain.AggregateRoot
{
    /// <summary>
    /// 月收入
    /// </summary>
    public class MonthIncome:IAggregateRoot<Guid>
    {
        public MonthIncome()
        {
            this.Items = new Collection<IncomeItem>();
        }

        public Guid Id { get; set; }

        public double MonthTotalMoney
        {
            get
            {
                if (this.Items != null && this.Items.Count > 0)
                    return this.Items.Sum(m => m.Money);

                return 0.0;
            }
        }

        public virtual ICollection<IncomeItem> Items { get; private set; }

        public void AddItem(IncomeItem item)
        {
            if (item == null)
                throw new Exception("item can't be null");

            this.Items.Add(item);
        }

        public void AddItems(List<IncomeItem> items)
        {
            if (items == null)
                throw new Exception("item can't be null");

            items.ForEach(AddItem);
        }

        public void RemoveItems(IncomeItem item)
        {
            if (item == null)
                throw new Exception("item can't be null");

            this.Items.Remove(item);
        }
    }
}
