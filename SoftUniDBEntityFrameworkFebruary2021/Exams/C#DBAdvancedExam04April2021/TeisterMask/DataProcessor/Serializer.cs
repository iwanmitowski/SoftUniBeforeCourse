namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ExportProjectDto()
                {
                    Name = x.Name,
                    Tasks = x.Tasks.Select(x => new ExportProjectTaskDto()
                    {
                        Name = x.Name,
                        Label = x.LabelType.ToString()
                    })
                    .OrderBy(x => x.Name)
                    .ToList(),
                    TasksCount = x.Tasks.Count(),
                    HasEndDate = x.DueDate == null ? "No" : "Yes"
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.Name)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            using var writer = new StringWriter();

            //Removes w3c text!!!
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(writer, projects, namespaces);

            return writer.ToString().Trim();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
                .ToArray()
                .Select(x => new ExportEmployeeDto()
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .ToArray()
                    .Select(et => new ExportTaskDto()
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString()
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result.Trim();
        }
    }
}