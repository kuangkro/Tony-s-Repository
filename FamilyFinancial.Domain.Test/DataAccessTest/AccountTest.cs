using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Infrastructure.Repository.Implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamilyFinancial.Domain.Test.DataAccessTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Create_Account_Test()
        {
            using(EntityframeworkContext context = new EntityframeworkContext())
            {
                var model = new Account("Tony", "123456");
                context.RegisterNew<Account,int>(model);
                context.Commit();
                Assert.AreNotEqual(0,model.Id);
            }
        }

        [TestMethod]
        public void Update_Account_Test()
        {
            using (EntityframeworkContext context = new EntityframeworkContext())
            {
                var model = context.Context.Set<Account>().Find(1);
                model.RegisterEmail = "kuangkro@gmail.com";
                context.RegisterModified<Account, int>(model);
                context.Commit();
                Assert.AreEqual("kuangkro@gmail.com", model.RegisterEmail);
            }
        }
    }
}
