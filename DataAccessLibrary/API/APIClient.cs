using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data.API
{

    public class APIClient
    {
        private HttpClient _client;
        public APIClient(HttpClient client)
        {
            this._client = client;
            client.DefaultRequestHeaders.Accept.Clear();
            var header = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(header);
        }
        public HttpClient Client
        {
            get
            {
                return this._client;
            }
        }
    }

}
