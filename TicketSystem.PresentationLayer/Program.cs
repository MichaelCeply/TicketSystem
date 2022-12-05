using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.ApplicationLayer;

namespace TicketSystem.PresentationLayer
{
    public class Program
    {
        static void Main()
        {
            bool RunFlag = true; 
            while(RunFlag)
            {
                string? pressed = ConsoleCmd.Hello();
                ConsoleCmd.Clear();
                if (pressed == "1")
                {
                    int id = 0;
                    bool log = ConsoleCmd.UserLogin(out id);
                    if (log)
                    {
                        ConsoleCmd.TimeTable(id);
                    }
                }
                else if(pressed == "2")
                {
                    int id = 0;
                    bool reg = ConsoleCmd.Register(out id);
                    if(reg) { ConsoleCmd.TimeTable(id); }
                }
                else if(pressed == "3")
                {
                    int id = 0;
                    bool log = ConsoleCmd.WLogin(out id);
                    if (log) { ConsoleCmd.Credits(id); }
                }
                else RunFlag = false;
            } 
            ConsoleCmd.Bye();
        }
    }
}
