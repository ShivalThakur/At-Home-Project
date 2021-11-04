using AtHomeProject.Common;
using AtHomeProject.Utils;
using System;
using System.Threading.Tasks;

namespace AtHomeProject.Apis.ApiThree
{
    public class Api : IApi
    {
        public string Url { get; set; } = "http://localhost:5000/api/v1/apis/apithree";
        public string UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        public async Task<decimal> GetOffer(OfferModel offerModel)
        {
            var apiCalls = new XmlApiCalls();
            var requestModel = Mapper(offerModel);
            var response = await apiCalls.PostAsync<RequestModel, ResponseModel>(Url, requestModel).ConfigureAwait(false);
            return response.Quote;
        }

        private RequestModel Mapper(OfferModel offerModel)
        {
            var requestModel = new RequestModel()
            {
                Source = offerModel.Source,
                Destination = offerModel.Destination,
                Packages = offerModel.Packages
            };
            return requestModel;
        }
    }
}
