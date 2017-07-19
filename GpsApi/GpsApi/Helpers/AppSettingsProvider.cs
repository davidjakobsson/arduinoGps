﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GpsApi.Helpers
{
    public class AppSettingsProvider
    {
        public string DatabaseConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["GpsDatabase"].ConnectionString; }
        }
    }
}