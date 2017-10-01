using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackByDelegateConsoleApp
{
    public class TryCatchFinally
    {
        public void ReadFile(int index)
        {
            string path = @"C:\Users\User\Desktop\Infosys_OnBoarding.pdf";
            StreamReader file = new StreamReader(path);
            char[] buffer = new char[10000];
            try
            {
                file.ReadBlock(buffer, index, buffer.Length);
            }
            catch(IOException e)
            {
                Console.WriteLine("Error reading from {0}. Message  = {1}", path, e.Message);
            }
            finally
            {
                if(file != null)
                {
                    file.Close();
                }
            }
        }
    }
}
