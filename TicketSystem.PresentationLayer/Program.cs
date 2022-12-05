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
                bool ULogFlag = true, UDoStuffFlag = true, URegFlag = true;
                string? pressed = ConsoleCmd.Hello();
                ConsoleCmd.Clear();
                if (pressed == "1")
                {
                    while(ULogFlag)
                    {
                        bool exit = false;
                        bool again = ConsoleCmd.UserLogin(out exit);
                        if (exit == true) ULogFlag = false; UDoStuffFlag = false;
                        if (again == true) ULogFlag = false;
                    }
                }
                else if(pressed == "2")
                {
                    while(URegFlag)
                    {
                        bool exit = false;
                        bool again = ConsoleCmd.Register(out exit);
                        if (exit == true) ULogFlag = false; UDoStuffFlag = false;
                        if (again == true) URegFlag = false;
                    }
                }
                else RunFlag = false;
            } 
            ConsoleCmd.Bye();
        }
    }
}
