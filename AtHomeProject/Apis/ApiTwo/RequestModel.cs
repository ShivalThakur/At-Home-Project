using System;
using System.Collections.Generic;
using System.Text;

namespace AtHomeProject.Apis.ApiTwo
{
    public class RequestModel
    {
        public string Consignee { get; set; }
        public string Consignor { get; set; }
        public int[]  Cartons { get; set; }
    }
}
