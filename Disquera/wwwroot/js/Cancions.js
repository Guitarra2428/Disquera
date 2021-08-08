var datatable;


$(document).ready(function () {
    CargarDatatable();
    s
});

function CargarDatatable() {
    datatable = $('#tblcancions').DataTable({
        "ajax": {
            "url": "/Cancions/GetAll",
            "type": "GET",
            "datatype": "json",

        },
        "columns": [
            { "data": "cancionID", "widtha": "10%" },
            { "data": "tema", "widtha": "10%" },
            { "data": "tiempoReproducion", "widtha": "15%" },
            { "data": "fechaCreacion", "width": "10%" },
            { "data": "album.nombre", "widtha": "10%" },


            {
                "data": "cancionID", "render": function (data) {
                    return   `<div clas="tex-center">
                    
                    <a href='/Cancions/Edit/${data}' class="btn btn-success" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-Edit"></i>Editar </a>

                    <a onclick=Delete("/Cancions/Delete/${data}") class="btn btn-danger" style=" cursor:pointer; width=100%;">
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
            type: "DELETE",
            url: url,
            success: function (data) {
                if (success.data) {
                    toastr.success(data.mesassge);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.mesassge)
                }
            }

        });
    });

}
