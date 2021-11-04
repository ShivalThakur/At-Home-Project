using AtHomeProject.Apis;
using AtHomeProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiOne = AtHomeProject.Apis.ApiOne;
using ApiTwo= AtHomeProject.Apis.ApiTwo;
using ApiThree = AtHomeProject.Apis.ApiThree;
using System.Linq;
namespace AtHomeProject.DoWork
{
    public class ProcessWork
    {
        public async Task<decimal> GetBestDeal(QueryModel queryModel)
        {
            var deals = new List<decimal>();
            var apis = new List<IApi>()
            {
                new ApiOne.Api(),
                new ApiTwo.Api(),
                new ApiThree.Api()
            };
            foreach (var api in apis)
            {
                var deal = await api.GetOffer(queryModel).ConfigureAwait(false);
                deals.Add(deal);
            }
            return deals.OrderBy(x => x).First();
        }
    }
}
