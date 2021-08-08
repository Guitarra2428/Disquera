var datatable;


$(document).ready(function () {
    cargarDatable();
});

function cargarDatable() {
    datatable = $("#tblgeneros").DataTable({
        "ajax": {
            "url": "/Generos/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "colunms": [
            { "data": "generosID", "widtha": "10%" },

            { "data": "nombre", "widtha": "10%" },

            {
                "data": "generosID", "render": function (data) {
                    `<div clas="tex-center">
                    
                    <a href='/Generos/Edit/${data}' class="btn btn-success" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-edit"></i>Editar </a>

                    <a onclik=Delete("/Generos/Delete/${data}") class="btn btn-danger" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-trash-alt"></i>Eliminar </a>


                    `;
                }, "width": "20%"

            }


        ],
        "languaje": {
            "emptyTable": "No hay registro"
        }, "width": "100%"



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
//                    dataTable.ajax.reload();
//                }
//                else {
//                    toastr.error(data.mesassge)
//                }
//            }

//        });
//    });

//}
