namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";
        

        //All employees, projects, tasks, employeesprojects counts are exactly the same with document. Somehow the result is 16/25
        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<ImportProjectsDto>), new XmlRootAttribute("Projects"));

            var reader = new StringReader(xmlString);

            using (reader)
            {
                var projectDtos = (List<ImportProjectsDto>)serializer.Deserialize(reader);

                foreach (var projectDto in projectDtos)
                {
                    if (!IsValid(projectDto))
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    DateTime projectOpenDate;
                    DateTime? projectDueDateAsNullable = null;

                    var isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                    if (!isProjectOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                    {
                        DateTime projectDueDate;

                        var isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDate);

                        if (!isProjectDueDateValid)
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        projectDueDateAsNullable = projectDueDate;
                    }

                    var project = new Project()
                    {
                        DueDate = projectDueDateAsNullable,
                        OpenDate = projectOpenDate,
                        Name = projectDto.Name
                    };

                    foreach (var taskDto in projectDto.Tasks)
                    {
                        if (!IsValid(taskDto))
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        DateTime taskOpenDate;

                        var isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                        if (!isTaskOpenDateValid)
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        if (taskOpenDate < projectOpenDate)
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        DateTime taskDueDate;

                        var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                        if (!isTaskDueDateValid)
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        //When DateTime is nullable take its value with .Value
                        if (projectDueDateAsNullable.HasValue && taskDueDate > projectDueDateAsNullable.Value)
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        var task = new Task()
                        {
                            DueDate = taskDueDate,
                            Name = taskDto.Name,
                            OpenDate = taskOpenDate,
                            LabelType = (LabelType)taskDto.LabelType,
                            ExecutionType = (ExecutionType)taskDto.ExecutionType
                        };

                        project.Tasks.Add(task);
                    }

                    context.Projects.Add(project);

                    context.SaveChanges();

                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                }
            }

            return sb.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                var taskIds = context.Tasks.Select(x => x.Id).ToList();

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    if (!taskIds.Contains(taskId))
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask() { TaskId = taskId });
                };

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count()));

            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}