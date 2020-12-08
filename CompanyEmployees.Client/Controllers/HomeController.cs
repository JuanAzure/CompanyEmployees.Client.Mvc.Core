using CompanyEmployees.Client.IServices;
using CompanyEmployees.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace CompanyEmployees.Client.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IClienteRestCliente _clienteRestCliente;
        public HomeController(ILogger<HomeController> logger, IClienteRestCliente clienteRestCliente)
        {
            _logger = logger;
            _clienteRestCliente = clienteRestCliente;
        }

        [Route("")]
        [Route("~/")]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            var clientes = await _clienteRestCliente.GetAll();
            return View(clientes);
        }


        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View("create", new ClienteViewModel());
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            await _clienteRestCliente.Create(clienteViewModel);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clienteRestCliente.GetById(id);
            return View("edit", client);
        }


        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ClienteViewModel clienteViewModel)
        {
            await _clienteRestCliente.Update(clienteViewModel);
            return RedirectToAction("Index");
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteRestCliente.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
