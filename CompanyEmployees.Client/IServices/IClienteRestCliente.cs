using CompanyEmployees.Client.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CompanyEmployees.Client.IServices
{
    public interface IClienteRestCliente
    {
        Task<List<ClienteViewModel>> GetAll();
        Task<ClienteViewModel> GetById(int Id);
        Task<HttpResponseMessage> Create(ClienteViewModel clienteViewModel);

        Task<HttpResponseMessage> Update(ClienteViewModel clienteViewModel);

        Task<HttpResponseMessage> Delete(int id);


        
    }
}
