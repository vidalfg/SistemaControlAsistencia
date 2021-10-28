using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Web.Models
{
    public class rptReporte 
    {

    }

  
    public class rptListaRegistroAsistencia
    {
        public int IdEstudiante { get; set; }
        public string DniEstudiante { get; set; }
        public string Fecha { get; set; }
        public int IdTipoAsistencia { get; set; }
    }
    public class rptListaRegistroEstudianteAsistencia
    {
        public int IdEstudiante { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }

    }

 

    public class ListarFechas
    {
        public string Fecha { get; set; }
    }
   
}
