using System;

namespace EmployeesControl.Model
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public Double Salary { get; set; }
        public Job WorkStation { get; set; }
        public Department Section { get; set; }
    }
}
