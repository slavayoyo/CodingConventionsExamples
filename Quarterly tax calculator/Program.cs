using System;

namespace QuarterlyTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t >> Quarterly Tax Calculator << \n");
            Console.ForegroundColor = ConsoleColor.White;

            ulong minutesQuarter;
            {
                while (true)
                {
                    Console.WriteLine("Enter the number of minutes of calls for January: ");
                    string enteredMinutesJanuary = Console.ReadLine();

                    Console.WriteLine("Enter the number of minutes of calls for January: ");
                    string enteredMinutesFabruary = Console.ReadLine();

                    Console.WriteLine("Enter the number of minutes of calls for January: ");
                    string enteredMinutesMarch = Console.ReadLine();

                    if ((ulong.TryParse(enteredMinutesJanuary, out ulong minitesJanuary)) &&
                        (ulong.TryParse(enteredMinutesFabruary, out ulong minitesFabruary)) &&
                        (ulong.TryParse(enteredMinutesMarch, out ulong minitesMarch)))
                    {
                        checked
                        {
                            minutesQuarter = minitesJanuary + minitesFabruary + minitesMarch;
                        }
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n [ERROR]: Invalid input. \n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }

            decimal totalCost; // UAN.
            {
                const decimal PRICE = 2; // uan.
                totalCost = minutesQuarter * PRICE;
            }

            decimal tax; // UAN.
            {
                const decimal TAX_RATE = 20; // % 
                tax = totalCost / 100 * TAX_RATE;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(); // Іndentation.
            Console.WriteLine($"Total           : {minutesQuarter:N} minutes");
            Console.WriteLine($"Сost of minutes : {totalCost:N} UAN");
            Console.WriteLine($"Tax payable:    : {tax:N} UAN");
            Console.ForegroundColor = ConsoleColor.White;

            // Delay.
            Console.ReadKey();
        }
    }
}
