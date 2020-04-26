using System;

namespace PayApp
{ 
    class Program
    {


        static void Main(string[] args)
        {
            Company oneCompany = new Company();
            bool running;
            string command = "";
            //Default values for Company are set in
            //class per C#6
            Console.WriteLine("Welcome to the Paylocity PayApp!");
            PrintHelp();
            running = true;
            while (running)
            {

                try
                {
                    command = System.Console.ReadLine();
                    switch (command)
                    {
                        case "adde":
                            Commands.Adde(oneCompany);
                            break;
                        case "list":
                            Commands.List();
                            break;
                        case "check":
                            Commands.Check();
                            break;
                        case "annual":
                            Commands.Annual();
                            break;
                        case "help":
                            PrintHelp();
                            break;
                        case "quit":
                            Console.WriteLine("Thank you for using PayApp! Be sure to like us on Facebook! :)");
                            running = false;
                            Environment.Exit(0);
                            break;
                        default:
                            PrintError();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("You hit an exception in the main try");
                }
            }
        }
        static void PrintHelp()
        {
            Console.WriteLine("The available case sensitive commands are:");
            PrintMenu();
        }
        static void PrintError()
        {
            Console.WriteLine("Sorry, I don't understand your request.");
            Console.WriteLine("Here are the things I know how to do:");
            PrintMenu();

        }
        static void PrintMenu()
        {
            Console.WriteLine("\"adde\" - add an employee");
            Console.WriteLine("\"list\" - list all employee records");
            Console.WriteLine("\"check\" - show bi-weekly benefit and salary costs");
            Console.WriteLine("\"annual\" - show annual benefit and salary costs");
            Console.WriteLine("\"help\" - see available commands");
            Console.WriteLine("\"quit\" - exit the program");

        }
    }
}
