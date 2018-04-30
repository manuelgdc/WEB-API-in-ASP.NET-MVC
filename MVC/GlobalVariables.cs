﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public class GlobalVariables
    {
        public static HttpClient httpClient = new HttpClient();

        static GlobalVariables()
        {
            httpClient.BaseAddress = new Uri("http://localhost:49831/api/");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}