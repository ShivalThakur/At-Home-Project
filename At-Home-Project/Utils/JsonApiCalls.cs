using AtHomeProject.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AtHomeProject.Utils
{
    public class JsonApiCalls : IApiCalls
    {
        public async Task<TResponseModel> PostAsync<TRequestModel, TResponseModel>(string url, TRequestModel requestModel)
        {
            using HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");
            using var response = await client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<TResponseModel>(responseContent);
            return data;
        }

    }
    public class XmlApiCalls : IApiCalls
    {
        public async Task<TResponseModel> PostAsync<TRequestModel, TResponseModel>(string url, TRequestModel requestModel)
        {
            using HttpClient client = new HttpClient();
            var x = new XmlSerializer(requestModel.GetType());
            using StringWriter textWriter = new StringWriter();
            x.Serialize(textWriter, requestModel);
            var contentStr = textWriter.ToString();
            var content = new StringContent(contentStr, Encoding.Unicode, "application/xml");
            using var response = await client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            // Deserializer
            var xmlSerializer = new XmlSerializer(typeof(TResponseModel));
            using StringReader textReader = new StringReader(responseContent);
            var data = (TResponseModel)xmlSerializer.Deserialize(textReader);
            return data;
        }

    }
}
