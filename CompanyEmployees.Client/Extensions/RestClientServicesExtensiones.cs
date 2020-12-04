using CompanyEmployees.Client.IServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;

namespace CompanyEmployees.Client.Extensions
{
    public static class RestClientServicesExtensiones
    {
        public static void configureServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteRestCliente, ClienteRestCliente>();
        }
        public static void configureServicesHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("APIClient", Client =>
           {
               Client.BaseAddress = new Uri("http://localhost:9000/");
               Client.DefaultRequestHeaders.Clear();
               Client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
               
           }
           );
        }
    }
}
