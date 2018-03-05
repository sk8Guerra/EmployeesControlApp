using System;
using EmployeesControl.Controller;
using EmployeesControl.Menu;

namespace EmployeesControl.Main
{
    class EmployeesMain
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;

            bool redo = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t╔══════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t║                            WELCOME TO EMPLYEES CONTROL                           ║");
                Console.WriteLine("\t╚══════════════════════════════════════════════════════════════════════════════════╝\n");

                Console.WriteLine("\n\t╔══════════════════╗");
                Console.WriteLine("\t║     MAIN MENU    ║");
                Console.WriteLine("\t╚══════════════════╝");

                Console.WriteLine("\n\t╔════════════════════╗");
                Console.WriteLine("\t║    EMPLOYEE - 1 -  ║");
                Console.WriteLine("\t║  DEPARTMENTS - 2 - ║");
                Console.WriteLine("\t║       JOBS - 3 -   ║");
                Console.WriteLine("\t║       EXIT - 4 -   ║");
                Console.WriteLine("\t╚════════════════════╝");

                try
                {
                    Console.Write("\n\t>>");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            EmployeeMenu.Instance.employeeMainMenu();
                            redo = true;
                            break;
                        case 2:
                            DepartmentMenu.Instance.departmentMainMenu();
                            redo = true;
                            break;
                        case 3:
                            JobMenu.Instance.jobMainMenu();
                            redo = true;
                            break;
                        case 4:
                            redo = false;
                            break;
                        default:
                            Console.WriteLine("\n\t╔═════════════════════════════════════════════════╗");
                            Console.WriteLine("\t║     THE MENU YOU HAVE CHOOSEN DOESN'T EXIST     ║");
                            Console.WriteLine("\t╚═════════════════════════════════════════════════╝");

                            Console.WriteLine("\n\tWould you like to repeat the menu? yes/no");
                            Console.Write("\n\t>> ");
                            String salida = Console.ReadLine();

                            if (salida.ToLower().Equals("yes"))
                            {
                                redo = true;
                            }
                            else
                            {
                                redo = false;
                            }
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\t╔════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t║    COMMAND NOT SUPPORTED, YOU DID NOT ENTER THE ID YOU SHOULD HAVE     ║");
                    Console.WriteLine("\t╚════════════════════════════════════════════════════════════════════════╝");

                    Console.WriteLine("\n\tWould you like to repeat the menu? yes/no");
                    Console.Write("\n\t>> ");
                    String salida = Console.ReadLine();

                    if (salida.ToLower().Equals("yes"))
                    {
                        redo = true;
                    }
                    else
                    {
                        redo = false;
                    }
                }
            } while (redo == true);
        }
    }
}
