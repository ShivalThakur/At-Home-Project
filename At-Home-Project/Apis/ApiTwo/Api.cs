using AtHomeProject.Common;
using AtHomeProject.Utils;
using System;
using System.Threading.Tasks;


namespace AtHomeProject.Apis.ApiTwo
{
    public class Api : IApi
    {
        public string Url { get; set; } = "http://localhost:5000/api/v1/apis/apitwo";
        public string UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        public async Task<decimal> GetOffer(QueryModel queryModel)
        {
            var apiCalls = new JsonApiCalls();
            var requestModel = Mapper(queryModel);
            var response = await apiCalls.PostAsync<RequestModel, ResponseModel>(Url, requestModel).ConfigureAwait(false);
            return response.Amount;
        }

        private RequestModel Mapper(QueryModel queryModel)
        {
            var requestModel = new RequestModel()
            {
                Consignee = queryModel.Source,
                Consignor = queryModel.Destination,
                Cartons = queryModel.Packages
            };
            return requestModel;
        }
    }
}

