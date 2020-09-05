using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Angular_MVC.App_Start
{
    public class WebApiConfiguration
    {
        public static string SiteRoot
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.SiteRoot]; }
        }

        public static string SupportMail
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.SupportMail]; }
        }

        public static string[] CorsAccessControlAllowOrigin
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.CorsAccessControlAllowOrigin].Split(','); }
        }

        public static string[] CorsAccessControllAllowHeaders
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.CorsAccessControlAllowHeaders].Split(','); }
        }

        public static string[] CorsAccessControllAllowMethods
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.CorsAccessControlAllowMethods].Split(','); }
        }

        public static bool EnableCronTasks
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[DevFxConstants.Config.EnableCronTasks]); }
        }

        public static string DefaultUser
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.DefaultUser]; }
        }

        public static string RunAs
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.RunAs]; }
        }

        public static int GridSize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings[DevFxConstants.Config.GridSize]); }
        }

        // Mails

        public static bool SendMails
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[DevFxConstants.Config.SendMails]); }
        }

        public static string SmtpHost
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.SmtpHost]; }
        }

        public static string SmtpCredentialsUserName => GetSecure(DevFxConstants.Config.SmtpCredentialsUserName);

        public static string SmtpCredentialsPassWord => GetSecure(DevFxConstants.Config.SmtpCredentialsPassWord);

        public static string MailSendFrom
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.MailSendFrom]; }
        }

        public static string MailSendFromDisplayName
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.MailSendFromDisplayName]; }
        }

        public static bool EnableSsl
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[DevFxConstants.Config.EnableSsl]); }
        }

        public static int Port
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings[DevFxConstants.Config.Port]); }
        }

        // B2C Authentication
        public static bool AuthEnabled
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[DevFxConstants.Config.B2CAuthEnabled]); }
        }

        public static bool UseRealAuth
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[DevFxConstants.Config.UseRealAuth]); }
        }

        public static string B2CDefaultDomain
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.B2CDefaultDomain]; }
        }

        public static string B2CAuthorityUrl
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.B2CAuthorityUrl]; }
        }

        public static string B2CSignInPolicy => Get(DevFxConstants.Config.B2CSignInPolicy);

        public static string B2CResetPasswordPolicy => Get(DevFxConstants.Config.B2CResetPasswordPolicy);

        public static string B2CInvitationPolicy => Get(DevFxConstants.Config.B2CInvitationPolicy);

        public static string B2CAuthReturnUrl
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.B2CAuthReturnUrl]; }
        }

        public static string KeyVaultCertUrl => Get(DevFxConstants.Config.KeyVaultCertUrl);

        public static string B2CAuthTenantId => GetSecure(DevFxConstants.Config.B2CAuthTenantId);

        public static string B2CAuthClientId => GetSecure(DevFxConstants.Config.B2CAuthClientId);

        public static string B2CAuthClientSecret => GetSecure(DevFxConstants.Config.B2CAuthClientSecret);

        public static string B2CExtensionAppId => GetSecure(DevFxConstants.Config.B2CExtensionAppId);

        public static string KeyVaultClientId => GetSecure(DevFxConstants.Config.KeyVaultClientId);
        public static string KeyVaultSecret => GetSecure(DevFxConstants.Config.KeyVaultSecret);
        public static string ADTenantId => GetSecure(DevFxConstants.Config.ADTenantId);
        public static string ADClientId => GetSecure(DevFxConstants.Config.ADClientId);
        public static string ADClientSecret => GetSecure(DevFxConstants.Config.ADClientSecret);

        private static string Get(string key) => ConfigurationManager.AppSettings[key];

        private static string GetSecure(string key) => (GetFromCustomSection(DevFxConstants.Config.Sections.SecureAppSettings, key));

        public static string Origins
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.Origins]; }
        }

        public static string Audience
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.Audience]; }
        }

        public static string IadbMailSuffix
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.IadbMailSuffix]; }
        }

        public static string AdminGroups
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.AdminGroups]; }
        }

        public static string ReadOnlyGroups
        {
            get { return ConfigurationManager.AppSettings[DevFxConstants.Config.ReadOnlyGroups]; }
        }

        public static bool CheckOktaForDeactivate
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[DevFxConstants.Config.CheckOktaForDeactivate]); }
        }

        public static bool CustomFlag
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[DevFxConstants.Config.CustomFlag]); }
        }

        public static string CognosGroupIdentifierValue => Get(DevFxConstants.Config.CognosGroupIdentifierValue);

        private static string GetFromCustomSection(string sectionName, string key)
        {
            var section = ConfigurationManager.GetSection(sectionName) as NameValueCollection;

            return section == null ? null : section[key];
        }
    }
}