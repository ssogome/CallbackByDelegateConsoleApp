using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CallbackByDelegateConsoleApp
{
    class Program
    {
        static int requestCounter;
        static ArrayList hostData = new ArrayList();
        static StringCollection hostNames = new StringCollection();
        static void UpdateUserInterface()
        {
            Console.WriteLine("{0} requests remaining. ", requestCounter);
        }

        static void Main(string[] args)
        {
            //Create a delegate that will process the results of the asynchronous request
            AsyncCallback callBack = new AsyncCallback(ProcessDnsInformation);
            string host;
            do
            {
                Console.Write("Enter the name of the computer or <enter> to finish.");
                host = Console.ReadLine();
                if (host.Length > 0)
                {
                    //Increment the request count in a thread-safe manner
                    Interlocked.Increment(ref requestCounter);
                    //Start the asynchromous request for DNS information
                    Dns.BeginGetHostEntry(host, callBack, host);
                }
            } while (host.Length > 0);

            // The user has entered all of the host names for lookup. Now wait until the threads complete.
            while(requestCounter > 0)
            {
                UpdateUserInterface();
            }
            //Display the result
            for(int i=0; i< hostNames.Count; i++)
            {
                object data = hostData[i];
                string message = data as string;
                if(message != null)
                {
                    Console.WriteLine("Request for {0} returned message : {1}", hostNames[i], message);
                    continue;
                }
                //Get the results
                IPHostEntry h = (IPHostEntry)data;
                string[] aliases = h.Aliases;
                IPAddress[] addresses = h.AddressList;
                if(aliases.Length > 0)
                {
                    Console.WriteLine("Aliases for {0}", hostNames[i]);
                    for(int j=0; j< aliases.Length; j++)
                    {
                        Console.WriteLine("{0}", aliases[j]);
                    }
                }
                if(addresses.Length > 0)
                {
                    Console.WriteLine("Addresses for {0}", hostNames[i]);
                    for(int k=0; k< addresses.Length; k++)
                    {
                        Console.WriteLine("{0}", addresses[k].ToString());
                    }
                }
            }

            

            CallbackTest callbackTest = new CallbackTest();
            callbackTest.Test();

            Console.WriteLine("\n Using Interfaces as callback");

            MeetingExecution mtingExec = new MeetingExecution();
            mtingExec.PerformingMeeting();

           
            Console.ReadKey();
        }

        static void ProcessDnsInformation(IAsyncResult result)
        {
            string hostName = (string)result.AsyncState;
            hostNames.Add(hostName);
            try
            {
                //Get results
                IPHostEntry host = Dns.EndGetHostEntry(result);
                hostData.Add(host);
            }
            catch(SocketException ex)
            {
                hostData.Add(ex.Message);
            }
            finally
            {
                //Decrement the request counter in a thread-safe manner
                Interlocked.Decrement(ref requestCounter);
            }
        }
    }
}
