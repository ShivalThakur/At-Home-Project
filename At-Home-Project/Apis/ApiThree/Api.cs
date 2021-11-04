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



        public async Task<decimal> GetOffer(QueryModel queryModel)
        {
            var apiCalls = new XmlApiCalls();
            var requestModel = Mapper(queryModel);
            var response = await apiCalls.PostAsync<RequestModel, ResponseModel>(Url, requestModel).ConfigureAwait(false);
            return response.Quote;
        }

        private RequestModel Mapper(QueryModel queryModel)
        {
            var requestModel = new RequestModel()
            {
                Source = queryModel.Source,
                Destination = queryModel.Destination,
                Packages = queryModel.Packages
            };
            return requestModel;
        }
    }
}
