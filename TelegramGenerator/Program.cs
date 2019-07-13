using Json.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Telegram> Telegrams = new List<Telegram>();
            Console.WriteLine("Input the number of telegrams you would like to write to file: ");
            int numOfTelegrams = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Input number of milliseconds between each write to file: ");
            int milliSec = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Write name of json file: ");
            string fileName = Console.ReadLine();

            for (int i = 0; i < numOfTelegrams; i++) Telegrams.Add(Telegram.RandomTelegram());
                                 
            foreach (var item in Telegrams)
            {
                Thread.Sleep(milliSec);
                File.AppendAllText($"C:\\Users\\cris\\Desktop\\{fileName}.json", $"{item} ," + Environment.NewLine);
            }

            Console.WriteLine("Telegrams successfully written to file.");
            
        }
    }
}
