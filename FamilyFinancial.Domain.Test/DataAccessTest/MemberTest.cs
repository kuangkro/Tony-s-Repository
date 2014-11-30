using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Domain.AggregateRoot;
using FamilyFinancial.Domain.ValueObject;
using FamilyFinancial.Infrastructure.Repository.Implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamilyFinancial.Domain.Test.DataAccessTest
{
    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void Create_Member_Test()
        {
            using(EntityframeworkContext context = new EntityframeworkContext())
            {
                var account = context.Context.Set<Account>().Find(1);
                var model = new Member(account,"Tony.xie",24);
                context.RegisterNew<Member,Guid>(model);
                context.Commit();
                Assert.AreNotEqual(Guid.Empty,model.Id);
            }
        }

        [TestMethod]
        public void Update_Member_Test()
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
    }
}
