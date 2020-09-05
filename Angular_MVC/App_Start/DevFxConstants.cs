using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular_MVC.App_Start
{
    public static partial class DevFxConstants
    {
        public static class Config
        {
            public static class Sections
            {
                public const string SecureAppSettings = "secureAppSettings";
            }

            public const string SiteRoot = "SiteRoot";
            public const string SupportMail = "SupportMail";
            public const string DefaultCulture = "devfx:DefaultCulture";

            public const string CorsAccessControlAllowOrigin = "cors:Access-Control-Allow-Origin";
            public const string CorsAccessControlAllowHeaders = "cors:Access-Control-Allow-Headers";
            public const string CorsAccessControlAllowMethods = "cors:Access-Control-Allow-Methods";

            public const string EnableCronTasks = "EnableCronTasks";
            public const string DefaultUser = "DefaultUser";
            public const string GridSize = "GridSize";
            public const string RunAs = "RunAs";

            // Mails
            public const string SendMails = "SendMails";
            public const string SmtpHost = "SmtpHost";
            public const string SmtpCredentialsUserName = "SmtpCredentialsUserName";
            public const string SmtpCredentialsPassWord = "SmtpCredentialsPassWord";
            public const string MailSendFrom = "MailSendFrom";
            public const string MailSendFromDisplayName = "MailSendFromDisplayName";
            public const string EnableSsl = "EnableSsl";
            public const string Port = "Port";

            // External Services Related
            public const string B2CAuthEnabled = "B2CAuthEnabled";
            public const string B2CDefaultDomain = "B2CDefaultDomain";
            public const string B2CAuthorityUrl = "B2CAuthorityUrl";
            public const string B2CSignInPolicy = "B2CSignInPolicy";
            public const string B2CResetPasswordPolicy = "B2CResetPasswordPolicy";
            public const string B2CInvitationPolicy = "B2CInvitationPolicy";

            public const string B2CAuthReturnUrl = "B2CAuthReturnUrl";
            public const string B2CAuthTenantId = "B2CAuthTenantId";
            public const string B2CAuthClientId = "B2CAuthClientId";
            public const string B2CAuthClientSecret = "B2CAuthClientSecret";
            public const string B2CExtensionAppId = "B2CExtensionAppId";

            public const string KeyVaultCertUrl = "KeyVaultCertUrl";
            public const string KeyVaultClientId = "KeyVaultClientId";
            public const string KeyVaultSecret = "KeyVaultSecret";

            public const string ADTenantId = "ADTenantId";
            public const string ADClientId = "ADClientId";
            public const string ADClientSecret = "ADClientSecret";

            public const string UseRealAuth = "UseRealAuth";

            public const string UseOkta = "UseOkta";
            public const string OktaToken = "OktaToken";
            public const string OktaServiceUrl = "OktaServiceUrl";
            public const string OktaTenantId = "OktaTenantId";
            public const string Audience = "Audience";
            public const string Origins = "Origins";

            public const string OktaAuthEnabled = "OktaAuthEnabled";
            public const string OktaApsEntityID = "OktaApsEntityID";
            public const string OktaEntityID = "OktaEntityID";
            public const string OktaMetadataUrl = "OktaMetadataUrl";
            public const string OktaReturnUrl = "OktaReturnUrl";
            public const string OktaSingleSignOnServiceUrl = "OktaSingleSignOnServiceUrl";

            public const string IadbMailSuffix = "IadbMailSuffix";

            public const string AdminGroups = "AdminGroups";
            public const string ReadOnlyGroups = "ReadOnlyGroups";
            public const string OktaAdminGroup = "OktaAdminGroup";
            public const string OktaAdminApp = "OktaAdminApp";

            public const string CheckOktaForDeactivate = "CheckOktaForDeactivate";
            public const string CustomFlag = "CustomFlag";

            public const string CognosGroupIdentifierValue = "CognosGroupIdentifierValue";
        }
    }
}