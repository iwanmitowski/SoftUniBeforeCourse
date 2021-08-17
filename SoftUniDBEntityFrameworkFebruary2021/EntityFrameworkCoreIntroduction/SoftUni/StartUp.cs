using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Uncomment to test!
            var context = new SoftUniContext();

            //15
            //Console.WriteLine(RemoveTown(context));

            //14
            //Console.WriteLine(DeleteProjectById(context));

            //13
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            //12
            //Console.WriteLine(IncreaseSalaries(context));

            //11
            //Console.WriteLine(GetLatestProjects(context));

            //10
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            //09
            Console.WriteLine(GetEmployee147(context)); 

            //08
            //Console.WriteLine(GetAddressesByTown(context));

            //07
            //Console.WriteLine(GetEmployeesInPeriod(context));

            //06
            //Console.WriteLine(AddNewAddressToEmployee(context));

            //05
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //04
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //03
            //Console.WriteLine(GetEmployeesFullInformation(context));
        }

        //15
        public static string RemoveTown(SoftUniContext context)
        {
            const string TownToDelete = "Seattle";

            var townToDelete = context.Towns
                .FirstOrDefault(x => x.Name == TownToDelete);

            var addressesToDelete = context.Addresses
                .Where(a => a.TownId == townToDelete.TownId);

            var deletedCount = addressesToDelete.Count();

            var employesAddressesToReplace = context.Employees
                .Where(x => addressesToDelete.Any(a => a.AddressId == x.AddressId));

            foreach (var e in employesAddressesToReplace)
            {
                e.AddressId = null;
            }

            context.SaveChanges();

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete);

            context.SaveChanges();


            return deletedCount+ $" addresses in {TownToDelete} were deleted";
;
        }

        //14
        public static string DeleteProjectById(SoftUniContext context)
        {
            const int projectIdToDelete = 2;
            var sb = new StringBuilder();

            context.Projects
                .Remove(new Models.Project() { ProjectId = projectIdToDelete });

            var projects = context.Projects.Take(10);

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().Trim();
        }

        //13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        //12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering" ||
                    x.Department.Name == "Tool Design" ||
                    x.Department.Name == "Marketing" ||
                    x.Department.Name == "Information Services")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Salary = x.Salary * 1.12m,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        //11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name);

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));

            }

            return sb.ToString().Trim();
        }

        //10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                .Where(x => x.Employees.Count() > 5)
                .Select(x => new
                {
                    EmployeesCount = x.Employees.Count(),
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    x.Employees,
                })
                .OrderBy(x => x.EmployeesCount)
                .ThenBy(x => x.Name);

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} {d.ManagerFirstName} - {d.ManagerLastName}");

                var employees = d.Employees.OrderBy(e => e.FirstName).ThenBy(x => x.LastName);

                foreach (var e in employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        //09
        public static string GetEmployee147(SoftUniContext context)
        {
            const int Id = 147;
            var sb = new StringBuilder();

            var employee = context.Employees
                .FirstOrDefault(x => x.EmployeeId == Id);

            var projects = context.EmployeesProjects
                .Where(x => x.EmployeeId == Id)
                .Select(x=>x.Project.Name)
                .OrderBy(x=>x)
                .ToList();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var p in projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().Trim();
        }

        //08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    EmployeesCount = x.Employees.Count()
                })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10);

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().Trim();
        }

        //07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
               .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLatName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(x => x.Project)
                })
               .Take(10)
               .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLatName}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} {(p.EndDate == null ? "not finished" : p.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }
            }

            return sb.ToString().Trim();
        }

        //06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            employee.Address = new Models.Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => new { x.Address.AddressText }) //За да не гръмне, че е null
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.AddressText}");
            }

            return sb.ToString().Trim();
        }

        //05
        static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - {e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.OrderBy(x => x.EmployeeId).Select(x => new { x.FirstName, x.MiddleName, x.LastName, x.JobTitle, x.Salary }).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}
