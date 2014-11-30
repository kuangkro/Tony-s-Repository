using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyFinancial.Domain.AggregateRoot
{
    public class Expand:IAggregateRoot<Guid>
    {
        private Expand(){}
        public Expand(CostType costType,double cost,Member createBy,string describtion)
        {
            if(costType == null)
                throw new ArgumentException("costType is null");
            if(cost <=0)
                throw new ArgumentException("cost can't less than zero");
            if(createBy == null)
                throw new ArgumentException("createBy is null");

            this.CostType = costType;
            this.ExpendCost = cost;
            this.CreateBy = createBy;
            this.Describtion = describtion;
        }
        public Guid Id { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public virtual CostType CostType { get; private set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public double ExpendCost { get; private set; }
        public string Describtion { get; set; }
        public virtual Member CreateBy { get; private set; }
    }
}
