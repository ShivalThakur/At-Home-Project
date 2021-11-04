using AtHomeProject.Common;
using AtHomeProject.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AtHomeProject.Apis.ApiOne
{
    public class Api : IApi
    {
        public string Url { get; set; } = "http://localhost:5000/api/v1/apis/apione";
        public string UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        public async Task<decimal> GetOffer(OfferModel offerModel)
        {
            var apiCalls = new JsonApiCalls();
            var requestModel = Mapper(offerModel);
            var response = await apiCalls.PostAsync<RequestModel, ResponseModel>(Url, requestModel).ConfigureAwait(false);
            return response.Total;
        }

        private RequestModel Mapper(OfferModel offerModel)
        {
            var requestModel = new RequestModel()
            {
                ContactAddress = offerModel.Source,
                WarehouseAddress = offerModel.Destination,
                Dimensions = offerModel.Packages
            };
            return requestModel;
        }
    }
}
