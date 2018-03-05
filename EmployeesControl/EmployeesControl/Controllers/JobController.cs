using System;
using EmployeesControl.Model;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesControl.Controller
{
    public class JobController
    {
        private static JobController instance;
        private List<Job> jobList;
        private Job job;
        private int idJob = 0;

        public JobController()
        {
            jobList = new List<Job>();
            Seerializer.desserializeJobs(jobList, "Jobs.xml");
            if (jobList.Count == 0)
            {
                idJob = 0;
            }
            else
            {
                int item = (jobList.Count - 1);
                idJob = item;
            }
        }

        public static JobController Instance
        {
            get
            {
                return (instance == null) ? instance = new JobController() : instance;
            }
        }

        public void add()
        {
            Console.WriteLine("\n\t╔══════════════════════════════╗");
            Console.WriteLine("\t║       ADDING A NEW JOB       ║");
            Console.WriteLine("\t╚══════════════════════════════╝");

            idJob++;
            job = new Job();
            job.IdJob = idJob;
            Console.Write("\n\tJob name: ");
            job.JobName = Console.ReadLine();
            jobList.Add(job);
            Seerializer.serializeJobs(jobList, "Jobs.xml");
            Console.WriteLine("\n\t╔════════════════════════════════════╗");
            Console.WriteLine("\t║     NEW JOB ADDED SUCCESSFULLY     ║");
            Console.WriteLine("\t╚════════════════════════════════════╝");
            Console.ReadKey();
        }

        public void edit()
        {
            Console.WriteLine("\n\t╔══════════════════════════════╗");
            Console.WriteLine("\t║         EDITING A JOB        ║");
            Console.WriteLine("\t╚══════════════════════════════╝");
            Console.WriteLine("\n\tWhich one would you like to edit? (type the id)");
            Console.Write("\n\t>>");
            int idToEdit = Convert.ToInt32(Console.ReadLine());
            Job specific = searchById(idToEdit);
            if (specific != null)
            {
                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdJob);
                Console.WriteLine("{0}{1}", "\tName: ", specific.JobName);
                Console.Write("\n\tNew job name: ");
                specific.JobName = Console.ReadLine();
                Seerializer.serializeJobs(jobList, "Jobs.xml");
                Console.WriteLine("\n\t╔════════════════════════════════════╗");
                Console.WriteLine("\t║        JOB EDITED SUCCESSFULLY     ║");
                Console.WriteLine("\t╚════════════════════════════════════╝");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔═══════════════════════════════════════════════════╗");
                Console.WriteLine("\t║        THE JOB YOU WANT TO EDIT WAS NOT FOUND     ║");
                Console.WriteLine("\t╚═══════════════════════════════════════════════════╝");
                Console.ReadKey();
            }
        }
        
        public void delete()
        {
            Console.WriteLine("\n\t╔════════════════════════════╗");
            Console.WriteLine("\t║       DELETING A JOB       ║");
            Console.WriteLine("\t╚════════════════════════════╝");
            Console.WriteLine("\n\tWhich one would you like to delete? (type the id)");
            Console.Write("\n\t>>");
            int idToDelete = Convert.ToInt32(Console.ReadLine());
            Job itemToRemove = jobList.SingleOrDefault(r => r.IdJob == idToDelete);
            if (itemToRemove != null)
            {
                jobList.Remove(itemToRemove);
                Seerializer.serializeJobs(jobList, "Jobs.xml");
                Console.WriteLine("\n\t╔════════════════════════════════════╗");
                Console.WriteLine("\t║       JOB DELETED SUCCESSFULLY     ║");
                Console.WriteLine("\t╚════════════════════════════════════╝");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔═══════════════════════════════════════════════════╗");
                Console.WriteLine("\t║        THE JOB YOU WANT TO DROP WAS NOT FOUND     ║");
                Console.WriteLine("\t╚═══════════════════════════════════════════════════╝");
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
            Job specific = searchById(idToShow);
            if (specific != null)
            {
                Console.WriteLine("\n\t╔═══════════════════════════════╗");
                Console.WriteLine("\t║          SHOWING JOB          ║");
                Console.WriteLine("\t╚═══════════════════════════════╝");
                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdJob);
                Console.WriteLine("{0}{1}", "\tName: ", specific.JobName);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔═════════════════════════════════╗");
                Console.WriteLine("\t║          JOB NOT FOUND          ║");
                Console.WriteLine("\t╚═════════════════════════════════╝");
                Console.ReadKey();
            }
        }

        private void showByName()
        {
            Console.WriteLine("\n\tWhich one would you like to seach? (type the name)");
            Console.Write("\n\t>>");
            String nameToShow = Console.ReadLine();

            Job specific = searchByName(nameToShow);

            if (specific != null)
            {
                Console.WriteLine("\n\t╔═══════════════════════════════╗");
                Console.WriteLine("\t║          SHOWING JOB          ║");
                Console.WriteLine("\t╚═══════════════════════════════╝");

                Console.WriteLine("{0}{1}", "\n\tID: ", specific.IdJob);
                Console.WriteLine("{0}{1}", "\tName: ", specific.JobName);

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n\t╔═════════════════════════════════╗");
                Console.WriteLine("\t║          JOB NOT FOUND          ║");
                Console.WriteLine("\t╚═════════════════════════════════╝");

                Console.ReadKey();
            }
        }

        private Job searchByName(String name)
        {
            Job job = jobList.Find(x => x.JobName == name);

            if (job != null)
            {
                return job;
            }
            return null;
        }

        private Job searchById(int id)
        {
            Job job = jobList.Find(x => x.IdJob == id);

            if (job != null)
            {
                return job;
            }
            return null;
        }

        public Job searchByIdToAddAnEmployee(int id)
        {
            Job job = jobList.Find(x => x.IdJob == id);

            if (job != null)
            {
                return job;
            }
            return null;
        }

        public void show()
        {
            Console.WriteLine("\n\t╔═══════════════════════════════╗");
            Console.WriteLine("\t║          SHOWING JOBS         ║");
            Console.WriteLine("\t╚═══════════════════════════════╝");
            foreach (Job temp in jobList)
            {
                Console.WriteLine("{0}{1}", "\n\tID: ", temp.IdJob);
                Console.WriteLine("{0}{1}", "\tName: ", temp.JobName);
            }
        }
    }
}
