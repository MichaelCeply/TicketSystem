using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.ApplicationLayer;

namespace TicketSystem.PresentationLayer
{
    public class ConsoleCmd
    {
        public static string? Hello()
        {
            System.Console.BackgroundColor = ConsoleColor.DarkBlue;
            System.Console.ForegroundColor = ConsoleColor.White;
            ConsoleCmd.Clear();
            System.Console.WriteLine("Vitejte v ticket systemu!");
            System.Console.WriteLine("Pro prihlaseni zakaznika stisknete '1',\n" +
                "pro registraci zakaznika '2',\n" +
                "pro prihlaseni zamestnance '3',\n" +
                "pro vypnuti cokoliv jineho");
            return (Console.ReadLine());
        }
        public static void Bye()
        {
            Console.WriteLine("Nashledanou!");
            return;
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static bool UserLogin(out bool exit)
        {
            exit = false;
            Console.WriteLine("Zadej uzivatelske jmeno nebo exit pro vraceni zpet:");
            string name = Console.ReadLine();
            if (name == "exit")
            {
                exit = true;
                return false;
            }
            Console.WriteLine("Zadej heslo:");
            string password = Console.ReadLine();
            int res = CustomerLogin.Execute(name, password);
            if (res > 0)
            {
                ConsoleCmd.Clear();
                Console.WriteLine($"Zakaznik {res} prihlasen!");
                return true;
            }
            if (res == -1) 
            {
                ConsoleCmd.Clear();
                Console.WriteLine("Spatne jmeno!");
                return false;
            }
            if (res == -2)
            {
                ConsoleCmd.Clear();
                Console.WriteLine("Spatne heslo!");
                return false;
            }
            else return false;
        }
        public static bool Register(out bool exit)
        {
            Console.WriteLine("Registrace\n");
            exit = false;
            Console.WriteLine("Zadej jmeno nebo exit pro ukonceni:");
            string name = Console.ReadLine();
            if (name == "exit") { exit = true; return false; }
            Console.WriteLine("Zadej email:");
            string email = Console.ReadLine();
            Console.WriteLine("Zadej heslo:");
            string password = Console.ReadLine();
            int res = Registration.Execute(name,email, password);
            if (res > 0)
            {
                ConsoleCmd.Clear();
                Console.WriteLine($"Zakaznik {res} registrovan!");
                return true;
            }
            if (res == -1)
            {
                ConsoleCmd.Clear();
                Console.WriteLine("Jiz pouzivane jmeno!");
                return false;
            }
            if (res == -2)
            {
                ConsoleCmd.Clear();
                Console.WriteLine("Jiz pouzivany email!");
                return false;
            }
            if(res == -3)
            {
                ConsoleCmd.Clear();
                Console.WriteLine("Slabe heslo!");
                return false;
            }
            else return false;
        }
    }
}
