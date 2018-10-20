using System;
using System.Configuration;

namespace VkBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot(ConfigurationManager.ConnectionStrings["token"].ConnectionString,
                              ConfigurationManager.ConnectionStrings["confirm-code"].ConnectionString);
            while (true) ;
        }                                                  
    }
}
