using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCA.Web.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly ServicioAsistencia _servicioAsistencia;
        public AsistenciaController(ServicioAsistencia servicioAsistencia)
        {
            _servicioAsistencia = servicioAsistencia;
        }

        //[HttpPost]
        //[Route("RegistrarAsistenciaDiaria/{data}")]
        //public async Task<IActionResult>  RegistrarAsistenciaDiaria(string data)
        //{
        //    var resultado = await _servicioAsistencia.executeCommandParameter("usp_RegistraAsistenciaDiaria", "@dni", data);
        //    return Ok(resultado);
        //}

        [HttpGet]
        [Route("ListarAsistenciaDia")]
        public async Task<IActionResult> ListarAsistenciaDia()
        {
            var resultado = await _servicioAsistencia.executeCommand("sp_ListarAsistenciaDiaria");
            return Ok(resultado);
        }

        [HttpGet]
        [Route("rptListarAsistencia")]
        public IActionResult rptListarAsistencia()
        {
            var resultados =  _servicioAsistencia.rptListarAsistencia();
            //var fechas = _servicioAsistencia.rptListaFechasAsistencia();
            //var estudiante = _servicioAsistencia.rptListarEstudianteAsistencia();
            //var resultados = asistencia + "|" + estudiante + "|" + fechas;
            return Ok(resultados);
        }
        [HttpGet]
        [Route("rptListarEstudianteAsistencia")]
        public IActionResult rptListarEstudianteAsistencia()
        {
            var resultado = _servicioAsistencia.rptListarEstudianteAsistencia();
            return Ok(resultado);
        }


        [HttpGet]
        [Route("rptListaFechasAsistencia")]
        public IActionResult rptListaFechasAsistencia()
        {
            var resultado =  _servicioAsistencia.rptListaFechasAsistencia();
            return Ok(resultado);
        }

    }
}
