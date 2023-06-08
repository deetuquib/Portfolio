﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab2.Models
{
    public class XMLandSchemaFileUpload
    {
        [Display(Name = "XML File")]
        public IFormFile XmlFile { get; set; }
        [Display(Name = "Schema File")]
        public IFormFile SchemaFile { get; set; }
    }
}