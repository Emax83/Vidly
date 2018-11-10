using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly
{
    public class Settings
    {

        public static Settings GetInstance()
        {
            return new Settings();
        }

        public string SMTP_Server { get; set; }
        public int SMTP_Port { get; set; }
        public string SMTP_User { get; set; }
        public string SMTP_Password { get; set; }
        public string SMTP_EncryptionType { get; set; }
        
        private Settings()
        {
            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("MailServer");
            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("");
            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("");
            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("");
            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("");

            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("pathImagesFileSystem");
            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("pathImagesWebsiteUrl");

            SMTP_Server = System.Configuration.ConfigurationManager.AppSettings.Get("DbConnection");


        }
    }
}