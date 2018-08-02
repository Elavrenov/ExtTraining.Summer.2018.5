using System;
using System.IO;
using No8.Solution.Entities;
using No8.Solution.Services;

namespace No8.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PrinterManager pm = new PrinterManager();
            CanonPrinter c = new CanonPrinter("canon", "124");
            EpsonPrinter e = new EpsonPrinter("epson", "123");

            pm.AddPrinter(c);
            pm.AddPrinter(e);

            while (true)
            {
                System.Console.WriteLine("\n");
                System.Console.WriteLine("Select your choice:");
                System.Console.WriteLine("1:Add new printer");
                System.Console.WriteLine("2:Print on Canon");
                System.Console.WriteLine("3:Print on Epson");
                System.Console.WriteLine("4:Choose printer to print");

                var key = System.Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    System.Console.WriteLine("\n Enter printer name:");
                    var name = System.Console.ReadLine();
                    System.Console.WriteLine("\n Enter printer model:");
                    var model = System.Console.ReadLine();
                    pm.CreatePrinter(name, model);
                    continue;
                }

                if (key.Key == ConsoleKey.D2)
                {
                    System.Console.WriteLine("\n Where you want save print. Enter way");
                    var fileLine = System.Console.ReadLine();
                    pm.Print(new FileStream(fileLine ?? throw new InvalidOperationException(), FileMode.Open), c);
                    continue;
                }

                if (key.Key == ConsoleKey.D3)
                {
                    System.Console.WriteLine("\n Where you want save print. Enter way");
                    var fileLine = System.Console.ReadLine();
                    pm.Print(new FileStream(fileLine ?? throw new InvalidOperationException(), FileMode.Open), e);
                    continue;
                }


                if (key.Key == ConsoleKey.D4)
                {
                    System.Console.WriteLine("\n choose printer \n");

                    pm.GetPrinterList();
                    var newKey = System.Console.ReadKey();
                    Printer p = c;

                    if (newKey.Key == ConsoleKey.D1)
                    {
                        p = c;
                    }

                    if (newKey.Key == ConsoleKey.D2)
                    {
                        p = e;
                    }

                    System.Console.WriteLine("\n Where you want save print. Enter way");
                    var fileLine = System.Console.ReadLine();
                    pm.Print(new FileStream(fileLine ?? throw new InvalidOperationException(), FileMode.Open), p);
                }
            }
        }
    }
}
