using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace IntegracionWD.Utils
{
    public class Properties
    {
        public string GetAppProperty(string key)
        {
            KeyValueConfigurationElement customSetting = null;
            Configuration webConfig = WebConfigurationManager.OpenWebConfiguration(null);

            if (webConfig.AppSettings.Settings.Count > 0)
            {
                customSetting = webConfig.AppSettings.Settings[key];
            }

            if (customSetting != null)
            {
                return customSetting.Value;
            }
            else
            {
                return key;
            }
        }

        public string GetConnectionString()
        {
            string connectionString = null;

            if (ConfigurationManager.ConnectionStrings.Count > 0)
            {
                connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            }

            return connectionString;
        }

    }
}