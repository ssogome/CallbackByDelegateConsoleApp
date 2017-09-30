using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackByDelegateConsoleApp
{
    public delegate void TaskCompletedCallback(string taskResult);
    public class Callback
    {
        public void StartNewTask(TaskCompletedCallback taskCompletedCallback)
        {
            Console.WriteLine("I have started an new task!");
            if (taskCompletedCallback != null) taskCompletedCallback("I have completed Task!");
        }
    }

    public class CallbackTest
    {
        public void Test()
        {
            TaskCompletedCallback callback = TestCallback;
            Callback testCallback = new Callback();
            testCallback.StartNewTask(callback);
        }

        public void TestCallback(string result)
        {
            Console.WriteLine(result);
        }
    }
}
