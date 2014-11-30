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
    public class CostTypeTest
    {
        [TestMethod]
        public void Create_CostType_Test()
        {
            using(EntityframeworkContext context = new EntityframeworkContext())
            {
                var model = new CostType("生活开支",null);
                model.AddChildType(new CostType("水电气费",model));
                model.AddChildType(new CostType("交通费",model));
                model.AddChildType(new CostType("日常开支",model));
                context.RegisterNew<CostType, int>(model);
                context.Commit();
                Assert.AreNotEqual(0,model.Id);
            }
        }

        [TestMethod]
        public void Update_CostType_Test()
        {
            using (EntityframeworkContext context = new EntityframeworkContext())
            {
                var model = context.Context.Set<CostType>().Find(1);
                model.ChangeName("生活消费");
                context.RegisterModified<CostType, int>(model);
                context.Commit();
                Assert.AreEqual("生活消费", model.Name);
            }
        }

        [TestMethod]
        public void Search_CostType_Test()
        {
            using (EntityframeworkContext context = new EntityframeworkContext())
            {
                var model = context.Context.Set<CostType>().First(p => p.Id == 1);
                Assert.AreEqual(3, model.ChildTypes.Count);
            }
        }
    }
}
