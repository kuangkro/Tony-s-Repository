using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.ValueObject;

namespace FamilyFinancial.Domain.AggregateRoot
{
    public class Member : IAggregateRoot<Guid>
    {
        private Member(){}
        public Member(Account account,string name,int age)
        {
            if(account == null)
                throw new Exception("account can't be null");
            if(string.IsNullOrEmpty(name))
                throw new Exception("name can't be null or empty");
            if(age <=0 || age >= 100 )
                throw new Exception("value of age should between 0 and 100");

            this.Account = account;
            this.Name = name;
            this.Age = age;
            this.Contact = new Contact();
        }

        public Guid Id { get; set; }
        public virtual Account Account { get; private set; }
        public string Name { get; private set; }
        public int Age { get; set; }
        public Contact Contact { get;private set; }

        public void ChangeContact(Contact contact)
        {
            if(contact == null)
                throw new Exception("contact can't be null");
            this.Contact = contact;
        }

        public void ChangeNameAndAge(string name,int age)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("name can't be null or empty");
            if (age <= 0 || age >= 100)
                throw new Exception("value of age should between 0 and 100");
            this.Name = name;
            this.Age = age;
        }
    }
}
