﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Core.Requests;
using Core.Responses;
using Services;

namespace FoodJournal.UI.Data
{
    public class DiabetesDataService : IDiabetesDataService
    {
        public DiabetesDataService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public Task<LoginResponse> Login(string username, string password)
        {
            var loginRequest = new LoginRequest
            {
                Username = username,
                Password = password
            };

            return HttpClient.PostAsJsonAsync<LoginRequest>("api/login", loginRequest)
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadFromJsonAsync<LoginResponse>();
                    }
                    else
                    {
                        return null;
                        throw new Exception(response.ReasonPhrase);
                    }
                }).Unwrap();
        }
    }
}