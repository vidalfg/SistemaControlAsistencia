using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SCA.Web.DataAcces;
using SCA.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ServicioAsistencia _servicioAsistencia;
        private readonly IHubContext<SignalrServer> _signalrHub;
        public HomeController(ILogger<HomeController> logger , ServicioAsistencia servicioAsistencia, IHubContext<SignalrServer> signalrHub)
        {
            _logger = logger;
            _servicioAsistencia = servicioAsistencia;
            _signalrHub = signalrHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> RegistrarAsistenciaDiaria(string parametro)
        {
            string resultado = await _servicioAsistencia.executeCommandParameter("usp_RegistraAsistenciaDiaria", "@dni", parametro);
            await _signalrHub.Clients.All.SendAsync("LoadAsistencia");
            return resultado;
        }

       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
