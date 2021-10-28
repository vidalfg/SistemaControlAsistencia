
//function ObtenerLista() {
//    sendServer({
//        method: "GET",
//        url: "/api/asistencia/listarasistenciadia",
        
//    }).then(function (result) {
       
//        ArmarListadoAsistencia(result.responseText);
//    }).catch(function (error) {
//        console.log('Ocurrió un error', error);
//    })
//}

//function ArmarListadoAsistencia(data) {
//    let json = JSON.parse(data);
   
//    let tr = "";

//    if (json.length != 0) {
//        json.forEach(function (item) {
//            tr += `
//        <div class="callout callout-info tamanho-list">
//            <h6>${item.Estudiante} - ${item.Dni} <span class="float-right badge bg-success">${item.HoraIngreso}</span> &nbsp;&nbsp;&nbsp;&nbsp; <span class="float-center badge bg-info">${item.Grado} - ${item.Seccion} </span>  &nbsp;&nbsp;&nbsp;&nbsp;  </h6>
//        </div>
//        `
//        });

//        $("#tb_Asistencia").html(tr);
//    }

//}


$(function () {

  //  ObtenerLista();

    $.validator.setDefaults({
        submitHandler: function () {

            let parametro = document.getElementById("exampleInputdni").value;
            sendServer({
                method: "POST",
                url: "/Home/RegistrarAsistenciaDiaria?parametro=" + parametro,
            }).then(function (result) {
                console.log(result.responseText)
                              
                if (result.responseText != "") {
                    let data = JSON.parse(result.responseText);
                    toastr.success('' + data.Apellidos + ', ' + data.Estudiante);
                }
                else {
                    toastr.error('Usuario No existe en el Sistema.');
                }
               

            }).catch(function (error) {
                console.log('Ocurrió un error', error);
            })

            toastr.options = {
                "positionClass": "toast-bottom-right",
            }
           
             
        }
    });



    $('#asistenciaForm').validate({
        rules: {
            dni: {
                required: true,
                minlength: 8
            }
        },
        messages: {
            dni: {
                required: "Este campo es obligatorio",
                minlength: "Ingresa Dni de 8 digitos"

            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });


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
