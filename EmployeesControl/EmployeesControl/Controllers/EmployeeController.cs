using System;
using System.Linq;
using System.Collections.Generic;
using EmployeesControl.Model;

namespace EmployeesControl.Controller
{
    public class EmployeeController
    {
        private static EmployeeController instance = null;
        private List<Employee> employeeList;
        private List<Employee> le;
        private List<Employee> specific;
        private Employee employee;
        private int idEmployee = 0;
        
        public EmployeeController()
        {
            employeeList = new List<Employee>();
            le = new List<Employee>();
            specific = new List<Employee>();
            Seerializer.desserializeEmployees(employeeList, "Employees.xml");
            if (employeeList.Count == 0)
            {
                idEmployee = 0;
            }
            else
            {
                int item = (employeeList.Count - 1);
                idEmployee = item;
            }
        }

        public static EmployeeController Instance
        {
            get
            {
                return (instance == null) ? instance = new EmployeeController() : instance;
            }
        }

        public void add()
        {
            Console.WriteLine("\n\t╔═══════════════════════════════════╗");
            Console.WriteLine("\t║       ADDING A NEW EMPLOYEE       ║");
            Console.WriteLine("\t╚═══════════════════════════════════╝");

            idEmployee++;
            employee = new Employee();
            employee.IdEmployee = idEmployee;
            Console.Write("\n\tName: ");
            employee.Name = Console.ReadLine();
            Console.Write("\tLast name: ");
            employee.LastName = Console.ReadLine();
            Console.Write("\tAddress: ");
            employee.Address = Console.ReadLine();
            Console.Write("\tPhone number: ");
            employee.PhoneNumber = Console.ReadLine();
            Console.Write("\tSalary: ");
            employee.Salary = Convert.ToDouble(Console.ReadLine());

            JobController.Instance.show();
            Console.WriteLine("\n\tWhich job would you like to assign to this new employee? (type the id)");
            Console.Write("\tWorkstation: ");
            int workStation = Convert.ToInt32(Console.ReadLine());
            employee.WorkStation = JobController.Instance.searchByIdToAddAnEmployee(workStation);

            DepartmentController.Instance.show();
            Console.WriteLine("\n\tWhich department would you like to assign to this new employee? (type the id)");
            Console.Write("\tDepartment: ");
            int dept = Convert.ToInt32(Console.ReadLine());
            employee.Section = DepartmentController.Instance.searchByIdToAddAnEmployee(dept);
            this.employeeList.Add(employee);
            Seerializer.serializeEmployees(employeeList, "Employees.xml");
            Console.WriteLine("\n\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║     NEW EMPLOYEE ADDED SUCCESSFULLY     ║");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");
            Console.ReadKey();
        }

        public void edit()
        {
            Console.WriteLine("\n\t╔════════════════════════════════════╗");
            Console.WriteLine("\t║         EDITING AN EMPLOYEE        ║");
            Console.WriteLine("\t╚════════════════════════════════════╝");

            Console.WriteLine("\n\tWhich one would you like to edit? (type the id)");
            Console.Write("\n\t>>");
            int idToEdit = Convert.ToInt32(Console.ReadLine());

            Employee specific = searchById(idToEdit);

            if (specific != null)
            {
                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdEmployee);
                Console.WriteLine("{0}{1}", "\tName: ", specific.Name);
                Console.WriteLine("{0}{1}", "\tLast name: ", specific.LastName);
                Console.WriteLine("{0}{1}", "\tAddress: ", specific.Address);
                Console.WriteLine("{0}{1}", "\tPhone number: (+502) ", specific.PhoneNumber);
                Console.WriteLine("{0}{1}", "\tSalary: Q ", specific.Salary);
                Console.WriteLine("{0}{1}", "\tJob: ", specific.WorkStation.JobName);
                Console.WriteLine("{0}{1}", "\tDepartment: ", specific.Section.DepartmentName);

                Console.Write("\n\tNew name: ");
                employee.Name = Console.ReadLine();
                Console.Write("\tNew last name: ");
                employee.LastName = Console.ReadLine();
                Console.Write("\tNew address: ");
                employee.Address = Console.ReadLine();
                Console.Write("\tNew phone number: ");
                employee.PhoneNumber = Console.ReadLine();
                Console.Write("\tNew salary: ");
                employee.Salary = Convert.ToDouble(Console.ReadLine());

                JobController.Instance.show();
                Console.WriteLine("\n\tWhich job would you like to assign to this new employee? (type the id)");
                Console.Write("\tNew workstation: ");
                int workStation = Convert.ToInt32(Console.ReadLine());
                employee.WorkStation = JobController.Instance.searchByIdToAddAnEmployee(workStation);

                DepartmentController.Instance.show();
                Console.WriteLine("\n\tWhich department would you like to assign to this new employee? (type the id)");
                Console.Write("\tNew department: ");
                int dept = Convert.ToInt32(Console.ReadLine());
                employee.Section = DepartmentController.Instance.searchByIdToAddAnEmployee(dept);
                Seerializer.serializeEmployees(employeeList, "Employees.xml");
                Console.WriteLine("\n\t╔═════════════════════════════════════════╗");
                Console.WriteLine("\t║        EMPLOYEE EDITED SUCCESSFULLY     ║");
                Console.WriteLine("\t╚═════════════════════════════════════════╝");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t║        THE EMPLOYEE YOU WANT TO EDIT WAS NOT FOUND     ║");
                Console.WriteLine("\t╚════════════════════════════════════════════════════════╝");
                Console.ReadKey();
            }
        }

        public void delete()
        {
            Console.WriteLine("\n\t╔══════════════════════════════════╗");
            Console.WriteLine("\t║       DELETING AN EMPLOYEE       ║");
            Console.WriteLine("\t╚══════════════════════════════════╝");

            Console.WriteLine("\n\tWhich one would you like to delete? (type the id)");
            Console.Write("\n\t>>");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            Employee itemToRemove = employeeList.SingleOrDefault(r => r.IdEmployee == idToDelete);

            if (itemToRemove != null)
            {
                employeeList.Remove(itemToRemove);
                Seerializer.serializeEmployees(employeeList, "Employees.xml");
                Console.WriteLine("\n\t╔═════════════════════════════════════════╗");
                Console.WriteLine("\t║       EMPLOYEE DELETED SUCCESSFULLY     ║");
                Console.WriteLine("\t╚═════════════════════════════════════════╝");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t║        THE EMPLOYEE YOU WANT TO DROP WAS NOT FOUND     ║");
                Console.WriteLine("\t╚════════════════════════════════════════════════════════╝");
                Console.ReadKey();
            }
        }

        public void searchChoosing()
        {
            Console.WriteLine("\n\t╔═══════════════════════╗");
            Console.WriteLine("\t║        BY ID - 1 -    ║");
            Console.WriteLine("\t║       BY NAME - 2 -   ║");
            Console.WriteLine("\t║    BY LAST NAME - 3 - ║");
            Console.WriteLine("\t╚═══════════════════════╝");

            Console.Write("\n\t>>");
            int searching = Convert.ToInt32(Console.ReadLine());

            switch (searching)
            {
                case 1:
                    this.showById();
                    break;
                case 2:
                    this.showByName();
                    break;
                case 3:
                    this.showByLastName();
                    break;
                default:

                    break;
            }
        }

        private void showById()
        {
            Console.WriteLine("\n\tWhich one would you like to seach? (type the id)");
            Console.Write("\n\t>>");
            int idToShow = Convert.ToInt32(Console.ReadLine());
            Employee specific = searchById(idToShow);
            if (specific != null)
            {
                Console.WriteLine("\n\t╔════════════════════════════════════╗");
                Console.WriteLine("\t║          SHOWING EMPLOYEE          ║");
                Console.WriteLine("\t╚════════════════════════════════════╝");
                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdEmployee);
                Console.WriteLine("{0}{1}", "\tName: ", specific.Name);
                Console.WriteLine("{0}{1}", "\tLast name: ", specific.LastName);
                Console.WriteLine("{0}{1}", "\tAddress: ", specific.Address);
                Console.WriteLine("{0}{1}", "\tPhone number: (+502) ", specific.PhoneNumber);
                Console.WriteLine("{0}{1}", "\tSalary: Q ", specific.Salary);
                Console.WriteLine("{0}{1}", "\tJob: ", specific.WorkStation.JobName);
                Console.WriteLine("{0}{1}", "\tDepartment: ", specific.Section.DepartmentName);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔══════════════════════════════════════╗");
                Console.WriteLine("\t║          EMPLOYEE NOT FOUND          ║");
                Console.WriteLine("\t╚══════════════════════════════════════╝");
                Console.ReadKey();
            }
        }

        private void showByName()
        {
            Console.WriteLine("\n\tWhich one would you like to seach? (type the name)");
            Console.Write("\n\t>>");
            String nameToShow = Console.ReadLine();
            Employee specific = searchByName(nameToShow);
            if (specific != null)
            {
                Console.WriteLine("\n\t╔════════════════════════════════════╗");
                Console.WriteLine("\t║          SHOWING EMPLOYEE          ║");
                Console.WriteLine("\t╚════════════════════════════════════╝");
                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdEmployee);
                Console.WriteLine("{0}{1}", "\tName: ", specific.Name);
                Console.WriteLine("{0}{1}", "\tLast name: ", specific.LastName);
                Console.WriteLine("{0}{1}", "\tAddress: ", specific.Address);
                Console.WriteLine("{0}{1}", "\tPhone number: (+502) ", specific.PhoneNumber);
                Console.WriteLine("{0}{1}", "\tSalary: Q ", specific.Salary);
                Console.WriteLine("{0}{1}", "\tJob: ", specific.WorkStation.JobName);
                Console.WriteLine("{0}{1}", "\tDepartment: ", specific.Section.DepartmentName);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔══════════════════════════════════════╗");
                Console.WriteLine("\t║          EMPLOYEE NOT FOUND          ║");
                Console.WriteLine("\t╚══════════════════════════════════════╝");
                Console.ReadKey();
            }
        }

        private void showByLastName()
        {
            Console.WriteLine("\n\tWhich one would you like to seach? (type the name)");
            Console.Write("\n\t>>");
            String lastNameToShow = Console.ReadLine();
            Employee specific = searchByLastName(lastNameToShow);
            if (specific != null)
            {
                Console.WriteLine("\n\t╔════════════════════════════════════╗");
                Console.WriteLine("\t║          SHOWING EMPLOYEE          ║");
                Console.WriteLine("\t╚════════════════════════════════════╝");
                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdEmployee);
                Console.WriteLine("{0}{1}", "\tName: ", specific.Name);
                Console.WriteLine("{0}{1}", "\tLast name: ", specific.LastName);
                Console.WriteLine("{0}{1}", "\tAddress: ", specific.Address);
                Console.WriteLine("{0}{1}", "\tPhone number: (+502) ", specific.PhoneNumber);
                Console.WriteLine("{0}{1}", "\tSalary: Q ", specific.Salary);
                Console.WriteLine("{0}{1}", "\tJob: ", specific.WorkStation.JobName);
                Console.WriteLine("{0}{1}", "\tDepartment: ", specific.Section.DepartmentName);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔══════════════════════════════════════╗");
                Console.WriteLine("\t║          EMPLOYEE NOT FOUND          ║");
                Console.WriteLine("\t╚══════════════════════════════════════╝");
                Console.ReadKey();
            }
        }

        public void showByDepartment()
        {
            Console.WriteLine("\n\t╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║          SHOWING EMPLOYEE(S) OF AN APARTMENT          ║");
            Console.WriteLine("\t╚═══════════════════════════════════════════════════════╝");


            DepartmentController.Instance.show();
            Console.WriteLine("\n\tWhich employees would you like to show in a specific department? (type the id)");
            Console.Write("\n\tDepartment: ");
            int dept = Convert.ToInt32(Console.ReadLine());
            Department d = DepartmentController.Instance.searchByIdToFindAnApartment(dept);
            specific = searchByDepartment(d.DepartmentName);
            
            if (specific != null)
            {
                foreach (Employee temp in le)
                {
                    Console.WriteLine("{0}{1}", "\n\tID: ", temp.IdEmployee);
                    Console.WriteLine("{0}{1}", "\tName: ", temp.Name);
                    Console.WriteLine("{0}{1}", "\tLast name: ", temp.LastName);
                    Console.WriteLine("{0}{1}", "\tAddress: ", temp.Address);
                    Console.WriteLine("{0}{1}", "\tPhone number: (+502) ", temp.PhoneNumber);
                    Console.WriteLine("{0}{1}", "\tSalary: Q ", temp.Salary);
                    Console.WriteLine("{0}{1}", "\tJob: ", temp.WorkStation.JobName);
                    Console.WriteLine("{0}{1}", "\tDepartment: ", temp.Section.DepartmentName);
                }
                specific.Clear();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔═══════════════════════════════════════╗");
                Console.WriteLine("\t║          EMPLOYEES NOT FOUND          ║");
                Console.WriteLine("\t╚═══════════════════════════════════════╝");
                Console.ReadKey();
            }
        }

        private List<Employee> searchByDepartment(String dept)
        {
            le = employeeList.Where(e => e.Section.DepartmentName.Equals(dept)).ToList();

            if (le != null)
            {
                return le;
            }
            return null;
        }

        private Employee searchByName(String name)
        {
            Employee employee = employeeList.Find(x => x.Name == name);

            if (employee != null)
            {
                return employee;
            }
            return null;
        }

        private Employee searchByLastName(String lastName)
        {
            Employee employee = employeeList.Find(x => x.LastName == lastName);

            if (employee != null)
            {
                return employee;
            }
            return null;
        }

        private Employee searchById(int id)
        {
            Employee employee = employeeList.Find(x => x.IdEmployee == id);

            if (employee != null)
            {
                return employee;
            }
            return null;
        }
        
        public void show()
        {
            Console.WriteLine("\n\t╔════════════════════════════════════╗");
            Console.WriteLine("\t║          SHOWING EMPLOYEES         ║");
            Console.WriteLine("\t╚════════════════════════════════════╝");

            foreach (Employee temp in employeeList)
            {
                Console.WriteLine("{0}{1}", "\n\tID: ", temp.IdEmployee);
                Console.WriteLine("{0}{1}", "\tName: ", temp.Name);
                Console.WriteLine("{0}{1}", "\tLast name: ", temp.LastName);
                Console.WriteLine("{0}{1}", "\tAddress: ", temp.Address);
                Console.WriteLine("{0}{1}", "\tPhone number: (+502) ", temp.PhoneNumber);
                Console.WriteLine("{0}{1}", "\tSalary: Q ", temp.Salary);
                Console.WriteLine("{0}{1}", "\tJob: ", temp.WorkStation.JobName);
                Console.WriteLine("{0}{1}", "\tDepartment: ", temp.Section.DepartmentName);
            }
        }
    }
}
