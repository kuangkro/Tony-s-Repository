using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FamilyFinancial.Domain.AggregateRoot
{
    public class CostType:IAggregateRoot<int>
    {
        private CostType()
        {
            ChildTypes = new Collection<CostType>();
        }
        public CostType(string name, CostType parent):this()
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentException("name can't be null or empty");

            this.Name = name;
            this.ParentType = parent;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public virtual CostType ParentType { get; private set; }
        public virtual ICollection<CostType> ChildTypes { get; private set; }


        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("name can't be null or empty");
            this.Name = name;
        }
        public void ChangeParentType(CostType parentType)
        {
            this.ParentType = parentType;
        }
        public void AddChildType(CostType type)
        {
            if(type == null)
                throw new ArgumentException("type is null");

            this.ChildTypes.Add(type);
        }
        public void RemoveChildType(CostType type)
        {
            if (type == null)
                throw new ArgumentException("type is null");

            this.ChildTypes.Remove(type);

        }
    }
}
