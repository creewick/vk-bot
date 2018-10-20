using System;
using System.Configuration;

namespace VkBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot(ConfigurationManager.AppSettings["token"],
                              ConfigurationManager.AppSettings["confirm-code"]);
            while (Console.Read() != 'q') ;
        }                                                  
    }
}
