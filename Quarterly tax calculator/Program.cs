using System;

namespace QuarterlyTaxCalculator
{
    class Program
    {
        static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t >> Quarterly Tax Calculator << \n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static ulong GetMinutesPerQuarter()
        {
            ulong minutesQuarter;

            while (true)
            {
                Console.WriteLine("Enter the number of minutes of calls for January: ");
                string enteredMinutesJanuary = Console.ReadLine();

                Console.WriteLine("Enter the number of minutes of calls for January: ");
                string enteredMinutesFabruary = Console.ReadLine();

                Console.WriteLine("Enter the number of minutes of calls for January: ");
                string enteredMinutesMarch = Console.ReadLine();

                bool isDataValid = (ulong.TryParse(enteredMinutesJanuary, out ulong minutesJanuary)) &
                                   (ulong.TryParse(enteredMinutesFabruary, out ulong minutesFabruary)) &
                                   (ulong.TryParse(enteredMinutesMarch, out ulong minutesMarch));

                if (isDataValid)
                {
                    checked
                    {
                        minutesQuarter = minutesJanuary + minutesFabruary + minutesMarch;
                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n [ERROR]: Invalid input. \n");
                    Console.ForegroundColor = ConsoleColor.White;

                    minutesQuarter = 0;
                }
            }

            return minutesQuarter;
        }

        static decimal GetTotalCost(ulong minutesQuarter)
        {
            const decimal PRICE = 2; // UAN.
            return minutesQuarter * PRICE;
        }

        static decimal GetTax(decimal totalCost)
        {
            const decimal TAX_RATE = 20; // % 
            return totalCost / 100 * TAX_RATE;
        }

        static void PrintResult(ulong minutesQuarter, decimal totalCost, decimal tax)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(); // Іndentation.
            Console.WriteLine($"Total           : {minutesQuarter:N} minutes");
            Console.WriteLine($"Сost of minutes : {totalCost:N} UAN");
            Console.WriteLine($"Tax payable:    : {tax:N} UAN");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {

            PrintHeader();

            ulong minutesQuarter = GetMinutesPerQuarter();

            decimal totalCost = GetTotalCost(minutesQuarter); // UAN.

            decimal tax = GetTax(totalCost); // UAN.

            PrintResult(minutesQuarter, totalCost, tax);

            // Delay.
            Console.ReadKey();
        }
    }
}
