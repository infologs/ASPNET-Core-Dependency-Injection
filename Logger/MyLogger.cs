using MyFirstCoreWebApplication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreWebApplication.Logger
{
    public class MyLogger : ILog
    {
        public int Count { get; set; }

        public int forMethodInjection { get; set; }

        public void WriteLog()
        {
            Count = Count + 1;
            Console.WriteLine("This message is coming through dependancy injection. " + Count);
        }

        public void WriteLog(string data)
        {
            forMethodInjection++;
            Console.WriteLine("The message from " + data +" injection :" + forMethodInjection);
        }
    }
}
