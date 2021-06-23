using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Cors;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using HMV.Core.DataAccess;
using Paineis.IoC;
using Paineis.Application.AutoMapper;
using Paineis.Api;

//[assembly: OwinStartup(typeof(Paineis.Api.Startup))]

namespace Paineis.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
#if DEBUG
            SwaggerConfig.Register(config);
#endif
            ConfigureCors(app);
            AtivandoAcessTokens(app);
            ConfiguraAmbiente();
            app.UseWebApi(config);
        }

        private void AtivandoAcessTokens(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new TokensDeAcessoProvider()
            };

            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void ConfigureCors(IAppBuilder app)
        {
            var politica = new CorsPolicy();

            politica.AllowAnyHeader = true;
#if DEBUG
            politica.Origins.Add("http://localhost:4200");
#else
            politica.Origins.Add("http://hoh2803.hmv.org.br:9112");  //homologação
            //politica.Origins.Add("http://hoh2840.hmv.org.br:9112"); //produção
#endif
            politica.Methods.Add("GET");
            politica.Methods.Add("POST");
            politica.Methods.Add("PUT");
            politica.Methods.Add("DELETE");

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(politica)
                }
            };
            app.UseCors(corsOptions);
        }

        private void ConfiguraAmbiente()
        {
            var config = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SessionManager.ConfigureDataAccess(config);
            IoCWorker.ConfigureWEB();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
