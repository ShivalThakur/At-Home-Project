using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AtHomeProject.Apis.ApiThree
{
    public class RequestModel
    {
        [XmlElement("source")]
        public string Source { get; set; }
        [XmlElement("destination")]
        public string Destination { get; set; }
        [XmlElement("packages")]
        public int[] Packages { get; set; }
    }
}
