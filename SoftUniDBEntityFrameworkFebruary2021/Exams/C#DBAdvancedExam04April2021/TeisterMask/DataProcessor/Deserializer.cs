namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectsDto[]), new XmlRootAttribute("Projects"));

            var reader = new StringReader(xmlString);

            var result = new StringBuilder();

            var projects = new List<Project>();


            using (reader)
            {
                var projectDtos = (ImportProjectsDto[])xmlSerializer.Deserialize(reader);

                foreach (var project in projectDtos)
                {
                    if (!IsValid(project))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }


                    DateTime projectOpenDate;
                    DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                    DateTime projectDueDate;
                    DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDate);

                    if (projectOpenDate == null || projectDueDate == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }


                    var tasks = new List<Task>();

                    foreach (var task in project.Tasks)
                    {
                        if (!IsValid(task))
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime taskOpenDate;
                        var isTaskOpenDateValid = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                        DateTime taskDueDate;
                        var isTaskDueDateValid = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                        if (!isTaskOpenDateValid ||
                            !isTaskDueDateValid ||
                            taskOpenDate < projectOpenDate ||
                            taskDueDate < projectDueDate)
                        {
                            result.AppendLine(ErrorMessage);
                            continue;
                        }

                        var currentTask = new Task()
                        {
                            Name = task.Name,
                            OpenDate = taskDueDate,
                            DueDate = taskOpenDate,
                            ExecutionType = (ExecutionType)task.ExecutionType,
                            LabelType = (LabelType)task.LabelType,
                        };

                        tasks.Add(currentTask);
                    }

                    context.Tasks.AddRange(tasks);

                    var currentProject = new Project()
                    {
                        Name = project.Name,
                        DueDate = projectOpenDate,
                        OpenDate = projectDueDate,
                        Tasks = tasks,
                    };

                    projects.Add(currentProject);
                    result.AppendLine(string.Format(SuccessfullyImportedProject, currentProject.Name, currentProject.Tasks.Count));
                }

                context.Projects.AddRange(projects);
            }

            context.SaveChanges();
            return result.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            return "TODO";
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}