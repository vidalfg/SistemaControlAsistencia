using Microsoft.AspNetCore.Mvc;
using SCA.Web.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Web.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ServicioAsistencia _servicioAsistencia;
        public ReporteController(ServicioAsistencia servicioAsistencia)
        {
            _servicioAsistencia = servicioAsistencia;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> ListarGradoSeccion()
        {
            string resultado = await _servicioAsistencia.executeCommand("usp_ListarInformeGradoSeccion");
            return resultado;
        }

        [HttpPost]
        public async Task<string> ListarFecha()
        {
            string resultado = await _servicioAsistencia.executeCommand("usp_rptListaFechaAsistencia");
            return resultado;
        }


    }
}
