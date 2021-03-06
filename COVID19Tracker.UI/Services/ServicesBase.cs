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
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:44325/api/";
        public ServicesBase()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer PdcYTYb7uKqy4uJc244HypRgUC4Kejhlo51FjrIFgtiyIVz8mVHSZrsLXX_w5nkNZgKU0mFxJK_dGXo_ZeyWJhHhsH8oa5qyXXcFkJaTxO5j6m19ZCmkDeHXUKGv67Wk7x4D6U-1k11VzM3pu2_xWg8b2t6jN76mDszVPk95AfbsthETimX_5cBqrOc9CXLVLLDjc_gkWDDHU73GT0uo_X66-6DYGmJoDSPPG2Fsyf597oIkca92oDURw1FBRkSG3Vijo2Dr59t9MFxEBm3hApv2lcEanz6B4DHMldfMGwc4A-B1m-XaycvQ08ebrEkacK_fJi1uOjrlHYs1lY-_ZPUCPdlV57Y9pKAhWlaEtHpfJpUy4sgAewrHKCvWITD-o-18jTUq1P9m2MHfyJclC08Q47s6NaHFo4AcYwbBBxDzAQ7buTq4MkUCxyv9u3RtlNlgzpA4t8ysXqYF2KaaTlOAcB-0S4e3t8bTmD_TJM8");
        }    
        
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
