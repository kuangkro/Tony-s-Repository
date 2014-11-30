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
    public class ExpandTest
    {
        [TestMethod]
        public void Create_Expand_Test()
        {
            using(EntityframeworkContext context = new EntityframeworkContext())
            {
                var costType = context.Context.Set<CostType>().First(p => p.ParentType != null);
                var member = context.Context.Set<Member>().First();
                var model = new Expand(costType, 80, member, "");
                context.RegisterNew<Expand, Guid>(model);
                context.Commit();
                Assert.AreNotEqual(Guid.Empty,model.Id);
            }
        }

        [TestMethod]
        public void Update_Expand_Test()
        {
            using (EntityframeworkContext context = new EntityframeworkContext())
            {
                var id = Guid.Parse("20A7115F-2346-E411-8843-005056C00008");
                var model = context.Context.Set<Expand>().First(p => p.Id.Equals(id));
                model.Describtion = "水电费";
                context.RegisterModified<Expand, Guid>(model);
                context.Commit();
                Assert.AreEqual("水电费", model.Describtion);
            }
        }
    }
}
