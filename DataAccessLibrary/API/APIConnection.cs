using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.API
{
    public class APIConnection
    {
        private readonly APIClient _client;
        public APIConnection(APIClient client)
        {
            this._client = client;
        }
        public async Task<T> GenericAPICall<T>(string url) where T:class
        {
            
            using (HttpResponseMessage response = await _client.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    T dataType = JsonConvert.DeserializeObject<T>(json);

                    return dataType;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
