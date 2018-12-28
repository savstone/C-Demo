using System;
using System.IO.Ports;
using System.Net.Http;
using System.Threading;

namespace NetCoreTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            HttpResponseMessage message = client.GetAsync("http://172.16.7.58:8085/api/LaserSyncData").Result;

            var result = message.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);


        }
    }
}
