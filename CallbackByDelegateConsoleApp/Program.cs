using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackByDelegateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CallbackTest callbackTest = new CallbackTest();
            callbackTest.Test();

            Console.WriteLine("\n Using Interfaces as callback");

            MeetingExecution mtingExec = new MeetingExecution();
            mtingExec.PerformingMeeting();
            Console.ReadKey();
        }
    }
}
