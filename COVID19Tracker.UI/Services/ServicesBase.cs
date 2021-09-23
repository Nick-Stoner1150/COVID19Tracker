using COVID19Tracker.Models.Employee_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.UI.Services
{
    public class ServicesBase : IServicesBase
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string baseUrl = "https://localhost:44325/api/";


        /* public static async Task GetDataWithAuthentication()
        {
            var authCredential = Encoding.UTF8.GetBytes("{userTest} : {passTest}");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authCredential));
                client.BaseAddress = new Uri($"{baseUrl}")
            })
        } */
    
    

        public async Task Create<T>(string route, T content)
        {
            var response = await _httpClient.PostAsJsonAsync($"{baseUrl}{route}", content);
        }
        public async Task<T> GetById<T>(string route, int id)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}{route}{id}");
            
            if (response.IsSuccessStatusCode)
            {
                T classDetail = await response.Content.ReadAsAsync<T>();
                return classDetail;
            }

            return default;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string route)
        {
            
            var response = await _httpClient.GetAsync($"{baseUrl}{route}");

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<T> listOfEntities = await response.Content.ReadAsAsync<IEnumerable<T>>();
                return listOfEntities;
            }

            return null;
        }

        public async Task UpdateEntity<T>(string route, T content, int id)
        {
            await _httpClient.PutAsJsonAsync($"{baseUrl}{route}{id}", content);
        }

        public async Task DeleteById(string route, int id)
        {
            await _httpClient.DeleteAsync($"{baseUrl}{route}{id}");
        }

        public async Task<IEnumerable<T>> GetAllVaccinatedByDepartment<T>(string route, int parameterId)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}{route}{parameterId}");

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<T> listOfEntities = await response.Content.ReadAsAsync<IEnumerable<T>>();
                return listOfEntities;
            }

            return null;
        }
           
    }

}
