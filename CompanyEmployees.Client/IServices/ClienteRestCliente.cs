using CompanyEmployees.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyEmployees.Client.IServices
{
    public class ClienteRestCliente : IClienteRestCliente
    {
        private readonly IHttpClientFactory _httpClientFactory;        
        public ClienteRestCliente(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ClienteViewModel>> GetAll()
        {

            var httpClient = _httpClientFactory.CreateClient("APIClient");
            var response = await httpClient.GetAsync("api/cliente").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var clienteString = await response.Content.ReadAsStringAsync();
            var clientes = JsonSerializer.Deserialize<List<ClienteViewModel>>(clienteString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return clientes;
        }


        public async Task<ClienteViewModel> GetById(int Id)
        {

            var httpClient = _httpClientFactory.CreateClient("APIClient");
            var response = await httpClient.GetAsync("api/cliente/" + Id).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var clienteString = await response.Content.ReadAsStringAsync();
            var clientes = JsonSerializer.Deserialize<ClienteViewModel>(clienteString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return clientes;
        }

        public Task<HttpResponseMessage> Create(ClienteViewModel clienteViewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("APIClient");
                return httpClient.PostAsJsonAsync("api/cliente", clienteViewModel);

            }
            catch
            {
                return null;

            }
        }


        public Task<HttpResponseMessage> Update(ClienteViewModel clienteViewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("APIClient");
                return httpClient.PutAsJsonAsync("api/cliente", clienteViewModel);

            }
            catch (Exception)
            {
                return null;

            }
        }
        public Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                //var cliente = new HttpClient();
                //cliente.BaseAddress = new Uri(BASE_URL);
                //cliente.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/json"));
                var httpClient = _httpClientFactory.CreateClient("APIClient");
                return httpClient.DeleteAsync("api/cliente/" + id);

            }
            catch (Exception)
            {
                return null;

            }
        }

    }
}
