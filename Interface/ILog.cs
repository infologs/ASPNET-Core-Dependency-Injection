using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreWebApplication.Interface
{
    public interface ILog
    {
        void WriteLog();
        void WriteLog(string data);
    }
}
