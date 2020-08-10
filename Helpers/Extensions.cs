﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdwachingApi.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Acces-Control-Expose-Headerd", "Application-Error");
            response.Headers.Add("Acces-Control-Allow-Origin", "*");
        }
    }
}
