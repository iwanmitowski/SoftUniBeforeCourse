using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlAttribute("TasksCount")]
        public int TasksCount  { get; set; }

        [XmlArray("Tasks")]
        public List<ExportProjectTaskDto> Tasks { get; set; }
    }
}
