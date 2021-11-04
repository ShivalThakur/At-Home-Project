using AtHomeProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtHomeProject.Apis
{
    public interface IApi
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Task<decimal> GetOffer(QueryModel queryModel);
    }
}
