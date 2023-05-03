using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

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
                client.BaseAddress = new Uri(this._Uri);
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

        public async Task<T> GetApiTokenAsync<T>(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
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

        public async Task<T> GetApiAsync<T>(string request, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(data);
                    string dataJson = json.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> GetApiTokenAsync<T>(string request, string token, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(data);
                    string dataJson = json.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        // T OBJECT

        public async Task<T> PostApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
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

        public async Task<T> PostApiTokenAsync<T>(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
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

        public async Task<T> PostApiAsync<T>(string request, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PostApiTokenAsync<T>(string request, string token, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
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
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
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

        public async Task<T> PostApiTokenAsync<T>(string request, object objeto, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
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

        public async Task<T> PostApiAsync<T>(string request, object objeto, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PostApiTokenAsync<T>(string request, object objeto, string key, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        // WITHOUT T OBJECT

        public async Task<bool> PostApiAsync(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> PostApiTokenAsync(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> PostApiAsync(string request, object objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> PostApiTokenAsync(string request, object objeto, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        // T OBJECT

        public async Task<T> PutApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
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

        public async Task<T> PutApiTokenAsync<T>(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
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

        public async Task<T> PutApiAsync<T>(string request, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PutApiTokenAsync<T>(string request, string key, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
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
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
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

        public async Task<T> PutApiTokenAsync<T>(string request, object objeto, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
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

        public async Task<T> PutApiAsync<T>(string request, object objeto, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> PutApiTokenAsync<T>(string request, object objeto, string key, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        // WITHOUT T OBJECT

        public async Task<bool> PutApiAsync(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> PutApiTokenAsync(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> PutApiAsync(string request, object objeto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> PutApiTokenAsync(string request, object objeto, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this._Header);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                string json = JsonConvert.SerializeObject(objeto);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                return response.IsSuccessStatusCode;
            }
        }

        // T OBJECT

        public async Task<T> DeleteApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Uri);
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

        public async Task<T> DeleteApiTokenAsync<T>(string request, string token)
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

        public async Task<T> DeleteApiAsync<T>(string request, string key)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Uri);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.DeleteAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonData = JObject.Parse(data);
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<T> DeleteApiTokenAsync<T>(string request, string key, string token)
        {
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
                    string dataJson = jsonData.GetValue(key).ToString();
                    return JsonConvert.DeserializeObject<T>(dataJson);
                }
                else
                {
                    return default(T);
                }
            }
        }

        // WITHOUT T OBJECT

        public async Task<bool> DeleteApiAsync(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Uri);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.DeleteAsync(request);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteApiTokenAsync(string request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = await client.DeleteAsync(request);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
