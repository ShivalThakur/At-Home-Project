using System;
using System.Collections.Generic;
using System.Text;

namespace AtHomeProject.Common
{
    public class QueryModel
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int[] Packages { get; set; }
    }
}
