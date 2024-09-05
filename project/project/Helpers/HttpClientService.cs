using Azure;
using project.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace project.Helpers
{
    public class HttpClientService
    {
        private static readonly string _baseUrl = "https://localhost:7197/";
        private static readonly string _loginUrl = "/api/Users/login";
        private static readonly string _examsUrl = "/api/Exams";
        public static async Task<string> Login(string loginJson)
        {
            HttpResponseMessage responseBody = await PostRequest(_loginUrl, loginJson);
            if(responseBody != null && responseBody.StatusCode == HttpStatusCode.OK) 
            {
                return await responseBody.Content.ReadAsStringAsync();
            }
            return null;
        }
        public static async Task<string>  CreateExam(string examJson)
        {
            HttpResponseMessage responseBody = await PostRequest(_examsUrl, examJson);
            if (responseBody != null && responseBody.StatusCode == HttpStatusCode.OK)
            {
                return await responseBody.Content.ReadAsStringAsync();
            }
            return null;
        }
        public static async Task<string> SubmitExam(string examJson)
        {
            HttpResponseMessage responseBody = await PostRequest($"{_examsUrl}/SubmitExam", examJson);
            if (responseBody != null && responseBody.StatusCode == HttpStatusCode.OK)
            {
                return await responseBody.Content.ReadAsStringAsync();
            }
            return null;
        }
        public static async Task<string> UpdateExam(string examJson, int examId)
        {
            HttpResponseMessage responseBody = await PutRequest(_examsUrl, examJson, examId);
            if (responseBody != null && responseBody.StatusCode == HttpStatusCode.OK)
            {
                return await responseBody.Content.ReadAsStringAsync();
            }
            return null;
        }
        public static async Task<string> GetExam(string examName)
        {
            HttpResponseMessage responseBody = await GetRequest($"{_examsUrl}/{examName}");
            if (responseBody != null && responseBody.StatusCode == HttpStatusCode.OK)
            {
                return await responseBody.Content.ReadAsStringAsync();
            }
            return null;
        }

        public static async Task<string> GetStatistics(string examName)
        {
            HttpResponseMessage responseBody = await GetRequest($"{_examsUrl}/statistics/{examName}");
            if (responseBody != null && responseBody.StatusCode == HttpStatusCode.OK)
            {
                return await responseBody.Content.ReadAsStringAsync();
            }
            return null;
        }

        private static async Task<HttpResponseMessage> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                HttpResponseMessage response = await client.GetAsync(url);
                return response;
            }
        }

        private static async Task<HttpResponseMessage> PostRequest(string url, string requestBody)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_baseUrl);
                    StringContent content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    return response;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        private static async Task<HttpResponseMessage> PutRequest(string url, string requestBody, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_baseUrl);
                    StringContent content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync($"{url}/{id}", content);
                    return response;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
