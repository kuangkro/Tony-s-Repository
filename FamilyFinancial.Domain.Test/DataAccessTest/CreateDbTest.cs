using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyFinancial.Infrastructure.Repository.Implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamilyFinancial.Domain.Test.DataAccessTest
{
    [TestClass]
    public class CreateDbTest
    {
        [TestMethod]
        public void Create_Database_Test()
        {
            EntityframeworkContext context = new EntityframeworkContext();
            context.Context.Database.Initialize(true);
        }
    }
}
