var datatable;


$(document).ready(function () {
    cargarDatable();
});

function cargarDatable() {
    datatable = $('#tblartistas').DataTable({
        "ajax": {
            "url": "/Artistas/GeAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "artistaID", "widtha": "5%" },

            { "data": "nombre", "widtha": "5%" },

            {
                "data": "artistaID", "render": function (data) {
                    return `<div clas="tex-center">
                    
                    <a href='/tblartistas/Edit/${data}' class="btn btn-success" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-edit"></i>Editar </a>

                    <a onclick=Delete("/tblartistas/Delete/${data}") class="btn btn-danger" style=" cursor:pointer; width=100%;">
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

function Delete(url) {
    swal({
        title: "Esta Seguro De Borrar",
        text: "Este Contenido no se puede recuperar",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Borrar",
        closeOnconfirm: true
    },
        function () {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();

                    }
                    else {
                        toastr.error(data.message)

                    }
                }

            });
        });

}
