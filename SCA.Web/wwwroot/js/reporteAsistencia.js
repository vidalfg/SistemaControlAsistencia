

function ObtenerListaGradoSeccion() {

    sendServer({
        method: "POST",
        url: "/Reporte/ListarGradoSeccion",
    }).then(function (result) {
        if (result.responseText != "|") {
            let arrayplit = result.responseText.split("|");
            let grado = JSON.parse(arrayplit[0]);
            ArmarCombo(grado, "cboGrado");
            let seccion = JSON.parse(arrayplit[1]);
            ArmarCombo(seccion, "cboSeccion");
        }

    }).catch(function (error) {
        console.log('Ocurrió un error', error);
    })
}

function ArmarCombo(data, id) {
    var tr ="";
        tr = `<option value="0"> Seleccione </option>`;
    
    data.forEach(function (item) {
        tr += `
         <option value="${item.value}">${item.text}</option>
        `
        });
    $("#" +id).html(tr);
}


function ObtenerListaEstudiante() {
    const asistencia = "", estudiante = "", fechas = "";
    sendServer({
        method: "GET",
        url: "/api/asistencia/rptListarEstudianteAsistencia",
    }).then(function (result) {

          asistencia = JSON.parse(result.responseText);

     
       
        //if (result.responseText != "") {
        //    let arrayplit = JSON.parse(result.responseText);
        //    ArmarListaEstudiante(arrayplit,"tb_ListaEstudiante")
        //}

    }).catch(function (error) {
        console.log('Ocurrió un error', error);
    })


    sendServer({
        method: "GET",
        url: "/api/asistencia/rptListarAsistencia",
    }).then(function (result) {


         estudiante = JSON.parse(result.responseText);
       // estudiante = estudiante1;
      /*  console.log(Estudiante);*/

    }).catch(function (error) {
        console.log('Ocurrió un error', error);
    })

    sendServer({
        method: "GET",
        url: "/api/asistencia/rptListaFechasAsistencia",
    }).then(function (result) {
          
         fechas = JSON.parse(result.responseText);
        //fechas = fechas1;
       // console.log(Fechas);
       
    }).catch(function (error) {
        console.log('Ocurrió un error', error);
    })

    console.log(estudiante);

    for (var i = 0; i < estudiante.length; i++) {
        console.log(estudiante[i].idEstudiante);
    }

}

function ArmarListaEstudiante(data,id) {
    let tr = "";

    /*style = "display:none"*/

    data.forEach(function (item) {
        tr += `
        <tr>
        <td style = "display:none"> ${item.idEstudiante}</td>
        <td style = "display:none"> ${item.dni}</td>
        <td> ${item.grado} - ${item.seccion}</td>
        <td> ${item.apellidos}, ${item.nombres}</td>
        </tr>        `
    });
    $("#" + id).html(tr);

}

function armarReporteResult(cabezera,contenido ,data){
    const Estudiante = cabezera;
    const Asistencia = contenido;
    const match = data;
    let tr = '';
    tr += `
       <div class="row">

                    <div  class="col-sm-4" style="padding-right:0px;">
                        <table class="table table-condensed table-bordered table-hover table-striped table-sorted">
                            <thead>
                                <tr>
                                    <th colspan="2">Estudiantes</th>

                                </tr>
                            </thead>
                            <tbody id="tb_ListaEstudiante">
                                <tr>
                                    <td class="hide"> jajajajja</td>
                                    <td class="hide"> jajajajja</td>
                                    <td> jajajajja</td>
                                    <td> jajajajja</td>
                                </tr>

                            </tbody>

                        </table>
                    </div>

                    <div class="col-sm-8" style="padding-left:0px;">
                        <div class="table-responsive">
                            <table class="table table-condensed table-bordered table-hover table-striped table-sorted" style="border-right:0px;width:auto;">
                                <thead>
                                    <tr>
                                        <th class="text-center">23/10/2021</th>
                                        <th class="text-center">24/10/2021</th>
                                        <th class="text-center">25/10/2021</th>
                                        <th class="text-center">26/10/2021</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center">SI</td>
                                        <td class="text-center">No</td>
                                        <td class="text-center">SI</td>
                                        <td class="text-center">NO</td>
                                    </tr>
                                    <tr>
                                        <td class="text-center">SDSDDSDS</td>
                                        <td class="text-center">SDSDDSDS</td>
                                        <td class="text-center">SDSDDSDS</td>
                                        <td class="text-center">SDSDDSDS</td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
        `
}




$(function () {

    ObtenerListaGradoSeccion();
    ObtenerListaEstudiante();
});

$.fn.ForceNumericOnly =
    function () {
        return this.each(function () {
            $(this).keydown(function (e) {
                var key = e.charCode || e.keyCode || 0;
                // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
                // home, end, period, and numpad decimal
                return (
                    key == 8 ||
                    key == 9 ||
                    key == 13 ||
                    key == 46 ||
                    key == 110 ||
                    key == 190 ||
                    (key >= 35 && key <= 40) ||
                    (key >= 48 && key <= 57) ||
                    (key >= 96 && key <= 105));
            });
        });
    };

//$("#exampleInputdni").ForceNumericOnly();
