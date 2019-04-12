using AttachedMode.Services.Abstract_HomeWork1;
using System;

namespace AttachedMode.Services_HomeWork1
{
    public class ConsoleReporter:IReporter
    {
        public void SendReporter(string text)
        {
            Console.WriteLine(text);
        }

        public void SendReporter(string temp,string text)
        {
            Console.Write(text);
        }
    }
}
