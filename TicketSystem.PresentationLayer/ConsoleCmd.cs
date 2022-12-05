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
        public static bool UserLogin(out int id)
        {
            while (true)
            {
                id = 0;
                Console.WriteLine("Zadej uzivatelske jmeno nebo exit pro vraceni zpet:");
                string name = Console.ReadLine();
                if (name == "exit")
                {
                    return false;
                }
                Console.WriteLine("Zadej heslo:");
                string password = Console.ReadLine();
                id = CustomerLogin.Execute(name, password);
                if (id > 0)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine($"Zakaznik {id} prihlasen!");
                    return true;
                }
                if (id == -1)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Spatne jmeno!");
                }
                if (id == -2)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Spatne heslo!");
                }
            }
        }
        public static bool Register(out int id)
        {
            while (true)
            {
                Console.WriteLine("Registrace\n");
                Console.WriteLine("Zadej jmeno nebo exit pro ukonceni:");
                string name = Console.ReadLine();
                if (name == "exit") { id = 0; return false; }
                Console.WriteLine("Zadej email:");
                string email = Console.ReadLine();
                Console.WriteLine("Zadej heslo:");
                string password = Console.ReadLine();
                id = Registration.Execute(name, email, password);
                if (id > 0)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine($"Zakaznik {id} registrovan!");
                    return true;
                }
                if (id == -1)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Jiz pouzivane jmeno!");
                }
                if (id == -2)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Jiz pouzivany email!");
                }
                if (id == -3)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Slabe heslo!");
                }
            }
        }

        public static bool TimeTable(int id)
        {
            while (true)
            {
                Console.WriteLine("Pocatecni stanice:");
                string start = Console.ReadLine();
                if (start == "exit")
                {
                    return false;
                }
                Console.WriteLine("Cilova stanice:");
                string end = Console.ReadLine();
                Console.WriteLine("Cas odjezdu:");
                string time = Console.ReadLine();

                List<string>? trains = ShowTrains.Execute(id, start, end, time, out int res);
                if (res == 0)
                {
                    ConsoleCmd.Clear();
                    if (trains.Count == 0) Console.WriteLine($"Nenalezeny zadne spoje");
                    else
                    {
                        foreach (string st in trains)
                        {
                            Console.WriteLine(st);
                        }
                    }
                }
                if (res == -1)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Spatna vychozi stanice!");
                }
                if (res == -2)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Spatna cilopva stanice!");
                }
            }
        }

        public static bool WLogin(out int id)
        {
            while (true)
            {
                id = 0;
                Console.WriteLine("Zadej uzivatelske jmeno nebo exit pro vraceni zpet:");
                string name = Console.ReadLine();
                if (name == "exit")
                {
                    return false;
                }
                Console.WriteLine("Zadej heslo:");
                string password = Console.ReadLine();
                id = WorkerLogin.Execute(name, password);
                if (id > 0)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine($"Zamestnanec {id} prihlasen!");
                    return true;
                }
                if (id == -1)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Spatne jmeno!");                  
                }
                if (id == -2)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Spatne heslo!");                   
                }
            }
        }
        public static bool Credits(int id)
        {
            while (true)
            {
                Console.WriteLine("Nabijeni kreditu");
                Console.WriteLine("Jmeno uzivatele:");
                string name = Console.ReadLine();
                if (name == "exit")
                {
                    return false;
                }
                Console.WriteLine("Vlozene penize");
                string moneyS = Console.ReadLine();
                if (!moneyS.All(char.IsDigit)) { Console.WriteLine("Spatny format"); return false; }
                int money = Convert.ToInt32(moneyS);
                int res = AddCredits.Execute(id, name, money);
                if (res > 0)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine($"Zamestnanec {res} prihlasen!");
                }
                if (res == -1)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Zaporne mnozstvi penez");
                }
                if (res == -2)
                {
                    ConsoleCmd.Clear();
                    Console.WriteLine("Uzivatel neexistuje!");
                }
            }
        }
    }
}
