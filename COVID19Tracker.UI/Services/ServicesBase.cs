﻿using COVID19Tracker.Models.Employee_Models;
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
    }

}
