using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Net.Json;

namespace CallApi.Helpers
{
    public class HelperCallApi
    {
        public async Task<T> CallApiAsync<T>(string uri, string request, MediaTypeWithQualityHeaderValue headers)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(headers);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> CallApiPostPutAsync<T>(string uri, string request, MediaTypeWithQualityHeaderValue headers)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(headers);
                string stringT = typeof(T).ToString();
                string json = JsonConvert.SerializeObject(stringT);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                return await response.Content.ReadAsAsync<T>();
            }
        }
    }
}
