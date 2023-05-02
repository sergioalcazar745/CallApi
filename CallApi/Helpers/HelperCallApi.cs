using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallApi.Helpers
{
    public class HelperCallApi
    {
        private string _Uri;
        private MediaTypeWithQualityHeaderValue _Header;

        public string Uri { 
            get
            {
                return _Uri;
            } 

            set
            {
                this._Uri = value;
            }
        }

        public MediaTypeWithQualityHeaderValue Header {
            get
            {
                return _Header;
            } 

            set
            {
                this._Header = value;
            }
        }

        public async Task<T> GetApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
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

        public async Task<T> GetApiAsync<T>(string request, object key)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(data);
                    string dataJson = json.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> GetApiAsync<T>(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
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

        public async Task<T> GetApiAsync<T>(string request, object key, string token)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(data);
                    string dataJson = json.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PostApiAsync<T>(string request, object objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);

                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
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

        public async Task<T> PostApiAsync<T>(string request, object key, object objeto)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);

                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PostApiAsync<T>(string request, string token, object objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
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

        public async Task<T> PosttApiAsync<T>(string request, object key, string token, object objeto)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PutApiAsync<T>(string request, object objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);

                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
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

        public async Task<T> PutApiAsync<T>(string request, object key, object objeto)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);

                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PutApiAsync<T>(string request, string token, object objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
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

        public async Task<T> PutApiAsync<T>(string request, object key, string token, object objeto)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(_Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PutApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_Uri);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage response = await client.DeleteAsync(request);
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

        public async Task<T> DeleteApiAsync<T>(string request, object key)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Uri);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage response = await client.DeleteAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> DeleteApiAsync<T>(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

                HttpResponseMessage response = await client.DeleteAsync(request);
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

        public async Task<T> DeleteApiAsync<T>(string request, object key, string token)
        {
            string keyString = key.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

                HttpResponseMessage response = await client.DeleteAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(keyString).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
