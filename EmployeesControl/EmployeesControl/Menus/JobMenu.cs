using System;
using EmployeesControl.Controller;

namespace EmployeesControl.Menu
{
    public class JobMenu
    {
        private static JobMenu instance;
        private bool redo = false;

        public static JobMenu Instance
        {
            get
            {
                return (instance == null) ? instance = new JobMenu() : instance;
            }
        }

        public void jobMainMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t╔══════════════════╗");
                Console.WriteLine("\t║     JOB MENU     ║");
                Console.WriteLine("\t╚══════════════════╝");

                Console.WriteLine("\n\t╔══════════════════╗");
                Console.WriteLine("\t║    ADD JOB - 1 - ║");
                Console.WriteLine("\t║   EDIT JOB - 2 - ║");
                Console.WriteLine("\t║   DROP JOB - 3 - ║");
                Console.WriteLine("\t║ SEARCH JOB - 4 - ║");
                Console.WriteLine("\t║  SHOW JOBS - 5 - ║");
                Console.WriteLine("\t║      EXIT  - 6 - ║");
                Console.WriteLine("\t╚══════════════════╝");

                try
                {
                    Console.Write("\n\t>>");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            JobController.Instance.add();
                            redo = true;
                            break;
                        case 2:
                            JobController.Instance.show();
                            JobController.Instance.edit();
                            redo = true;
                            break;
                        case 3:
                            JobController.Instance.show();
                            JobController.Instance.delete();
                            redo = true;
                            break;
                        case 4:
                            JobController.Instance.searchChoosing();
                            redo = true;
                            break;
                        case 5:
                            JobController.Instance.show();
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
