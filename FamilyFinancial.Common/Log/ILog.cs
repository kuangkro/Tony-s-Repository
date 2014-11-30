using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyFinancial.Common.Log
{
    public interface ILog
    {
        void Info(string message);
        void Default(string message);
        void Exception(string exception);
    }
}
