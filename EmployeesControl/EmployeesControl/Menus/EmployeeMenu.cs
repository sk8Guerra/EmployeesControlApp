using System;
using System.Linq;
using EmployeesControl.Controller;

namespace EmployeesControl.Menu
{
    public class EmployeeMenu
    {
        private static EmployeeMenu instance;
        private bool redo = false;

        public static EmployeeMenu Instance
        {
            get
            {
                return (instance == null) ? instance = new EmployeeMenu() : instance;
            }
        }

        public void employeeMainMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t╔═══════════════════════╗");
                Console.WriteLine("\t║     EMPLOYEE MENU     ║");
                Console.WriteLine("\t╚═══════════════════════╝");

                Console.WriteLine("\n\t╔═══════════════════════════════════════╗");
                Console.WriteLine("\t║           ADD EMPLOYEE - 1 -          ║");
                Console.WriteLine("\t║           EDIT EMPLOYEE - 2 -         ║");
                Console.WriteLine("\t║           DROP EMPLOYEE - 3 -         ║");
                Console.WriteLine("\t║         SEARCH EMPLOYEE - 4 -         ║");
                Console.WriteLine("\t║          SHOW EMPLOYEES - 5 -         ║");
                Console.WriteLine("\t║  SHOW EMPLOYEES OF AN APARTMENT - 6 - ║");
                Console.WriteLine("\t║               EXIT  - 7 -             ║");
                Console.WriteLine("\t╚═══════════════════════════════════════╝");

                try
                {
                    Console.Write("\n\t>>");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            EmployeeController.Instance.add();
                            redo = true;
                            break;
                        case 2:
                            EmployeeController.Instance.show();
                            EmployeeController.Instance.edit();
                            redo = true;
                            break;
                        case 3:
                            EmployeeController.Instance.show();
                            EmployeeController.Instance.delete();
                            redo = true;
                            break;
                        case 4:
                            EmployeeController.Instance.searchChoosing();
                            redo = true;
                            break;
                        case 5:
                            EmployeeController.Instance.show();
                            Console.ReadKey();
                            redo = true;
                            break;
                        case 6:
                            EmployeeController.Instance.showByDepartment();
                            redo = true;
                            break;
                        case 7:
                            redo = false;
                            break;
                        default:
                            Console.WriteLine("\n\t╔═════════════════════════════════════════════════╗");
                            Console.WriteLine("\t║     THE MENU YOU HAVE CHOOSEN DOESN'T EXIST     ║");
                            Console.WriteLine("\t╚═════════════════════════════════════════════════╝");

                            Console.WriteLine("\n\tWould you like to repeat the menu? yes/no");
                            Console.Write("\n\t>> ");
                            String repeating = Console.ReadLine();

                            if (repeating.ToLower().Equals("yes"))
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
                    Console.WriteLine("\n\t╔═════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t║    COMMAND NOT SUPPORTED, YOU DID NOT ENTER THE ID THAT YOU SHOULD HAVE     ║");
                    Console.WriteLine("\t╚═════════════════════════════════════════════════════════════════════════════╝");

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
