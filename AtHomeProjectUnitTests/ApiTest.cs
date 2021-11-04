using AtHomeProject.Apis;
using AtHomeProject.Common;
using AtHomeProject.DoWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
namespace AtHomeProjectUnitTests
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public async Task GetOffers()
        {
            var offerModel = new OfferModel()
            {
                Source = "Chandigarh",
                Destination = "Delhi",
                Packages = new int[] { 15, 18, 25 }
            };
            var processWork = new ProcessWork();
            var bestDeal = await processWork.GetBestDeal(offerModel).ConfigureAwait(false);
            Debug.WriteLine($"Best deal : {bestDeal}");
            Assert.IsTrue(bestDeal > 0);


        }
    }
}
