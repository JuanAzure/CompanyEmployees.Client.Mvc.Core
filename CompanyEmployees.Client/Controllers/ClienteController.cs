using CompanyEmployees.Client.IServices;
using CompanyEmployees.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CompanyEmployees.Client.Controllers
{
    [Route("Clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteRestCliente _clienteRestCliente;

        public ClienteController(IClienteRestCliente clienteRestCliente)
        {
            _clienteRestCliente = clienteRestCliente;
        }


        [Route("search")]
        public async Task<IActionResult> Search(int codigoCliente = 0)
        {
            ClienteViewModel clienteViewModel = null;
            try
            {
                if (codigoCliente == 0)
                {
                    return View("search");
                }
                clienteViewModel = new ClienteViewModel();
                clienteViewModel = await _clienteRestCliente.GetById(codigoCliente);
            }
            catch (Exception)
            {
                ViewBag.clients = "Search Client not Found";
                return View("search");
            }
            return View("search", clienteViewModel);
        }

    }
}
