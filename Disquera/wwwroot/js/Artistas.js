var datatable;


$(document).ready(function () {
    CargarDatatable();

});

function CargarDatatable() {
    datatable = $('#tblartistas').DataTable({
        "ajax": {
            "url": "/Artistas/GeAll",
            "type": "GET",
            "datatype": "json",

        },
        "columns": [
            { "data": "artistaID", "widtha": "5%" },
            { "data": "nombre", "widtha": "10%" },
            { "data": "apellido", "widtha": "15%" },
            { "data": "sexo", "width": "10%" },
            { "data": "fechaNacimiento", "width": "10%" },
            { "data": "descripcion", "width": "20%" },
            { "data": "genero.nombre", "width": "20%" },           
            { "data": "urlImagen", "width": "15%" },


            {
                "data": "artistaID",
                "render": function (data) {
                    return   `<div clas="tex-center">
                    
                    <a href="/Artistas/Edit/${data}" class="btn btn-success" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-Edit"></i>Editar </a>

                    <a onclick=Delete("/Artistas/Delete/${data}") class="btn btn-danger" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-trash-alt"></i>Eliminar </a>


                    `;
                }, "width": "20%"

            }


        ], "width": "100%"



    });
}
function Delete(url) {
    swal({
        title: "Esta Seguro De Borrar",
        text: "Este Contenido no se puede recuperar",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Borrar",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    datas.ajax.reload();

                }
                else {
                    toastr.error(data.message)

                }
            }

        });
    });


}
//function Delete(url) {
//    swal({
//        title: "Esta Seguro De Borrar",
//        text: "Este Contenido no se puede recuperar",
//        type: "warning",
//        showCancelButton: true,
//        confirmButtonColor: "#DD6B55",
//        confirmButtonText: "Si, Borrar",
//        closeOnconfirm: true

//    }, function () {
//        $.ajax({
//            type: "DELETE",
//            url: url,
//            success: function (data) {
//                if (success.data) {
//                    toastr.success(data.mesassge);
//                    datatable.ajax.reload();
//                }
//                else {
//                    toastr.error(data.mesassge)
//                }
//            }

//        });
//    });

//}
