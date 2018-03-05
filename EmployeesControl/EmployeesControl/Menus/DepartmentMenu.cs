using System;
using EmployeesControl.Controller;

namespace EmployeesControl.Menu
{
    public class DepartmentMenu
    {
        private static DepartmentMenu instance;
        private bool redo = false;

        public static DepartmentMenu Instance
        {
            get
            {
                return (instance == null) ? instance = new DepartmentMenu() : instance;
            }
        }

        public void departmentMainMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t╔═════════════════════════╗");
                Console.WriteLine("\t║     DEPARTMENT MENU     ║");
                Console.WriteLine("\t╚═════════════════════════╝");

                Console.WriteLine("\n\t╔═════════════════════════╗");
                Console.WriteLine("\t║    ADD DEPARTMENT - 1 - ║");
                Console.WriteLine("\t║   EDIT DEPARTMENT - 2 - ║");
                Console.WriteLine("\t║   DROP DEPARTMENT - 3 - ║");
                Console.WriteLine("\t║ SEARCH DEPARTMENT - 4 - ║");
                Console.WriteLine("\t║  SHOW DEPARTMENT - 5 -  ║");
                Console.WriteLine("\t║        EXIT  - 6 -      ║");
                Console.WriteLine("\t╚═════════════════════════╝");

                try
                {
                    Console.Write("\n\t>>");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            DepartmentController.Instance.add();
                            redo = true;
                            break;
                        case 2:
                            DepartmentController.Instance.show();
                            DepartmentController.Instance.edit();
                            redo = true;
                            break;
                        case 3:
                            DepartmentController.Instance.show();
                            DepartmentController.Instance.delete();
                            redo = true;
                            break;
                        case 4:
                            DepartmentController.Instance.searchChoosing();
                            redo = true;
                            break;
                        case 5:
                            DepartmentController.Instance.show();
                            Console.ReadKey();
                            redo = true;
                            break;
                        case 6:
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
                } catch (FormatException)
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
