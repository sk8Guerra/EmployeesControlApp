using System;
using System.Collections.Generic;
using System.Linq;
using EmployeesControl.Model;

namespace EmployeesControl.Controller
{
    public class DepartmentController
    {
        private static DepartmentController instance;
        private List<Department> departmentList;
        private Department departmet;
        private int idDepartment = 0;

        public DepartmentController()
        {
            departmentList = new List<Department>();
            Seerializer.desserializeDepartments(departmentList, "Departments.xml");
            if (departmentList.Count == 0)
            {
                idDepartment = 0;
            }
            else
            {
                int item = (departmentList.Count - 1);
                idDepartment = item;
            }
        }

        public static DepartmentController Instance
        {
            get
            {
                return (instance == null) ? instance = new DepartmentController() : instance;
            }
        }

        public void add()
        {
            Console.WriteLine("\n\t╔═════════════════════════════════════╗");
            Console.WriteLine("\t║       ADDING A NEW DEPARTMENT       ║");
            Console.WriteLine("\t╚═════════════════════════════════════╝");

            idDepartment++;
            departmet = new Department();
            departmet.IdDepartament = idDepartment;
            Console.Write("\n\tDepartment name: ");
            departmet.DepartmentName = Console.ReadLine();
            departmentList.Add(departmet);
            Seerializer.serializeDepartments(departmentList, "Departments.xml");
            Console.WriteLine("\n\t╔═══════════════════════════════════════════╗");
            Console.WriteLine("\t║     NEW DEPARTMENT ADDED SUCCESSFULLY     ║");
            Console.WriteLine("\t╚═══════════════════════════════════════════╝");
            Console.ReadKey();
        }

        public void edit()
        {
            Console.WriteLine("\n\t╔═════════════════════════════════════╗");
            Console.WriteLine("\t║         EDITING A DEPARTMENT        ║");
            Console.WriteLine("\t╚═════════════════════════════════════╝");

            Console.WriteLine("\n\tWhich one would you like to edit? (type the id)");
            Console.Write("\n\t>>");
            int idToEdit = Convert.ToInt32(Console.ReadLine());

            Department specific = searchById(idToEdit);

            if (specific != null)
            {
                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdDepartament);
                Console.WriteLine("{0}{1}", "\tName: ", specific.DepartmentName);

                Console.Write("\n\tNew department name: ");
                specific.DepartmentName = Console.ReadLine();
                Seerializer.serializeDepartments(departmentList, "Departments.xml");
                Console.WriteLine("\n\t╔═══════════════════════════════════════════╗");
                Console.WriteLine("\t║        DEPARTMENT EDITED SUCCESSFULLY     ║");
                Console.WriteLine("\t╚═══════════════════════════════════════════╝");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t║        THE DEPARTMENT YOU WANT TO EDIT WAS NOT FOUND     ║");
                Console.WriteLine("\t╚══════════════════════════════════════════════════════════╝");
                Console.ReadKey();
            }    
        }

        public void delete()
        {
            Console.WriteLine("\n\t╔═══════════════════════════════════╗");
            Console.WriteLine("\t║       DELETING A DEPARTMENT       ║");
            Console.WriteLine("\t╚═══════════════════════════════════╝");

            Console.WriteLine("\n\tWhich one would you like to delete? (type the id)");
            Console.Write("\n\t>>");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            Department itemToRemove = departmentList.SingleOrDefault(r => r.IdDepartament == idToDelete);

            if (itemToRemove != null)
            {
                departmentList.Remove(itemToRemove);
                Seerializer.serializeDepartments(departmentList, "Departments.xml");
                Console.WriteLine("\n\t╔═══════════════════════════════════════════╗");
                Console.WriteLine("\t║       DEPARTMENT DELETED SUCCESSFULLY     ║");
                Console.WriteLine("\t╚═══════════════════════════════════════════╝");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t║        THE DEPARTMENT YOU WANT TO DROP WAS NOT FOUND     ║");
                Console.WriteLine("\t╚══════════════════════════════════════════════════════════╝");
                Console.ReadKey();
            }

        }

        public void searchChoosing()
        {
            Console.WriteLine("\n\t╔══════════════════╗");
            Console.WriteLine("\t║     BY ID - 1 -  ║");
            Console.WriteLine("\t║    BY NAME - 2 - ║");
            Console.WriteLine("\t╚══════════════════╝");

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
                default:

                    break;
            }
        }

        private void showById()
        {
            Console.WriteLine("\n\tWhich one would you like to seach? (type the id)");
            Console.Write("\n\t>>");
            int idToShow = Convert.ToInt32(Console.ReadLine());

            Department specific = searchById(idToShow);

            if (specific != null)
            {
                Console.WriteLine("\n\t╔══════════════════════════════════════╗");
                Console.WriteLine("\t║          SHOWING DEPARTMENT          ║");
                Console.WriteLine("\t╚══════════════════════════════════════╝");

                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdDepartament);
                Console.WriteLine("{0}{1}", "\tName: ", specific.DepartmentName);

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔════════════════════════════════════════╗");
                Console.WriteLine("\t║          DEPARTMENT NOT FOUND          ║");
                Console.WriteLine("\t╚════════════════════════════════════════╝");

                Console.ReadKey();
            }
        }

        private void showByName()
        {
            Console.WriteLine("\n\tWhich one would you like to seach? (type the name)");
            Console.Write("\n\t>>");
            String nameToShow = Console.ReadLine();

            Department specific = searchByName(nameToShow);

            if (specific != null)
            {
                Console.WriteLine("\n\t╔══════════════════════════════════════╗");
                Console.WriteLine("\t║          SHOWING DEPARTMENT          ║");
                Console.WriteLine("\t╚══════════════════════════════════════╝");

                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdDepartament);
                Console.WriteLine("{0}{1}", "\tName: ", specific.DepartmentName);

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔════════════════════════════════════════╗");
                Console.WriteLine("\t║          DEPARTMENT NOT FOUND          ║");
                Console.WriteLine("\t╚════════════════════════════════════════╝");

                Console.ReadKey();
            }
        }

        private Department searchByName(String name)
        {
            Department department = departmentList.Find(x => x.DepartmentName == name);

            if (department != null)
            {
                return department;
            }
            return null;
        }

        private Department searchById(int id)
        {
            Department department = departmentList.Find(x => x.IdDepartament == id);

            if (department != null)
            {
                return department;
            }
            return null;
        }

        public Department searchByIdToAddAnEmployee(int id)
        {
            Department department = departmentList.Find(x => x.IdDepartament == id);

            if (department != null)
            {
                return department;
            }
            return null;
        }

        public Department searchByIdToFindAnApartment(int id)
        {
            Department department = departmentList.Find(x => x.IdDepartament == id);

            if (department != null)
            {
                return department;
            }
            return null;
        }

        public void show()
        {
            Console.WriteLine("\n\t╔══════════════════════════════════════╗");
            Console.WriteLine("\t║          SHOWING DEPARTMENTS         ║");
            Console.WriteLine("\t╚══════════════════════════════════════╝");
            foreach (Department temp in departmentList)
            {
                Console.WriteLine("{0}{1}", "\n\tID: ", temp.IdDepartament);
                Console.WriteLine("{0}{1}", "\tName: ", temp.DepartmentName);
            }
        }
    }
}
