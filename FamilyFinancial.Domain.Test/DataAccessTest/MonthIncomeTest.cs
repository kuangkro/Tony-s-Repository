using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Domain.Entities;
using FamilyFinancial.Domain.ValueObject;
using FamilyFinancial.Infrastructure.Repository.Implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamilyFinancial.Domain.Test.DataAccessTest
{
    [TestClass]
    public class MonthIncomeTest
    {
        [TestMethod]
        public void Create_MonthIncome_Test()
        {
            using(EntityframeworkContext context = new EntityframeworkContext())
            {
                Member member = context.Context.Set<Member>().First();
                var model = new MonthIncome();
                model.AddItems(new List<IncomeItem>()
                        {
                            new IncomeItem(200,member,model),
                            new IncomeItem(300,member,IncomeType.Other,model)
                        });
                context.RegisterNew<MonthIncome, Guid>(model);
                context.Commit();
                Assert.AreNotEqual(Guid.Empty,model.Id);
            }
        }

        [TestMethod]
        public void Update_MonthIncome_Test()
        {
            using (EntityframeworkContext context = new EntityframeworkContext())
            {
                var model = context.Context.Set<Member>().Find(Guid.Parse("81B0D18F-3243-E411-8282-005056C00008"));
                model.ChangeContact(new Contact()
                                        {
                                            Email = "leihao.xie@symbio.com",
                                            QQ = "350357474"
                                        });
                context.RegisterModified<Member,Guid>(model);
                context.Commit();
                Assert.AreEqual(model.Contact.Email, "leihao.xie@symbio.com");
            }
        }

        [TestMethod]
        public void Search_MonthIncome_Test()
        {
            using(EntityframeworkContext context = new EntityframeworkContext())
            {
                var incomes = context.Context.Set<MonthIncome>()
                    //.Include(p => p.Items)
                    .First(p => p.Id.Equals(new Guid("88434521-0244-E411-8250-005056C00008")));
                Assert.IsNotNull(incomes);
                Assert.AreEqual(incomes.Items.Count,2);
            }
        }
    }
}
