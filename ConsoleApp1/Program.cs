using System;
using WebApp.Controllers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AdvertResidentalOrm deneme = new AdvertResidentalOrm();

            foreach (var item in deneme.Select())
            {
                Console.WriteLine(item);
            }
        }
    }
}
