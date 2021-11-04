using System.Threading.Tasks;

namespace AtHomeProject.Utils
{
    public interface IApiCalls
    {
        Task<TResponseModel> PostAsync<TRequestModel, TResponseModel>(string url, TRequestModel requestModel);

    }
}