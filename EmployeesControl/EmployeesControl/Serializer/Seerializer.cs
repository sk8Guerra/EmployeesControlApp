using EmployeesControl.Model;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml.Serialization;

namespace EmployeesControl
{
    public static class Seerializer
    {
        //Departments
        public static void serializeDepartments(this List<Department> list, string filename)
        {
            var seralizer = new XmlSerializer(typeof(List<Department>));
            using (var stream = File.OpenWrite(filename))
            {
                seralizer.Serialize(stream, list);
            }
        }

        public static void desserializeDepartments(this List<Department> list, string filename)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Department>));
                using (var stream = File.OpenRead(filename))
                {
                    var other = (List<Department>)(serializer.Deserialize(stream));
                    list.Clear();
                    list.AddRange(other);
                }
            } catch { }
        }

        //Employees
        public static void serializeEmployees(this List<Employee> list, string filename)
        {
            var seralizer = new XmlSerializer(typeof(List<Employee>));
            using (var stream = File.OpenWrite(filename))
            {
                seralizer.Serialize(stream, list);
            }
        }

        public static void desserializeEmployees(this List<Employee> list, string filename)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Employee>));
                using (var stream = File.OpenRead(filename))
                {
                    var other = (List<Employee>)(serializer.Deserialize(stream));
                    list.Clear();
                    list.AddRange(other);
                }
            } catch { }
        }

        //Jobs
        public static void serializeJobs(this List<Job> list, string filename)
        {
            var seralizer = new XmlSerializer(typeof(List<Job>));
            using (var stream = File.OpenWrite(filename))
            {
                seralizer.Serialize(stream, list);
            }
        }

        public static void desserializeJobs(this List<Job> list, string filename)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Job>));
                using (var stream = File.OpenRead(filename))
                {
                    var other = (List<Job>)(serializer.Deserialize(stream));
                    list.Clear();
                    list.AddRange(other);
                }
            } catch { }
        }

    }
}
