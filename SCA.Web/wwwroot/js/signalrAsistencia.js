
$(function () {

    console.log("hola hola");

    LoadAsistenciaData();

    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadAsistencia", function () {
        LoadAsistenciaData();
    })

    LoadAsistenciaData();

    function LoadAsistenciaData() {
        var tr = '';
        sendServer({
            method: "GET",
            url: "/api/asistencia/listarasistenciadia",

        }).then(function (result) {

            let json = JSON.parse(result.responseText);
            if (json.length != 0) {
                json.forEach(function (item) {
                    tr += `
              <div class="callout callout-info tamanho-list">
                <h6>${item.Estudiante} - ${item.Dni} <span class="float-right badge bg-success">${item.HoraIngreso}</span> &nbsp;&nbsp;&nbsp;&nbsp; <span class="float-center badge bg-info">${item.Grado} - ${item.Seccion} </span>  &nbsp;&nbsp;&nbsp;&nbsp;  </h6>
                 </div>
                 `
                });

                $("#tb_Asistencia").html(tr);
               
            }

        }).catch(function (error) {
            //toastr.error('Usuario No existe en el Sistema.');
            console.log('Ocurrió un error', error);
        })

    }
});
