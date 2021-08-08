var datatable;


$(document).ready(function () {
    CargarDatatable();

});

function CargarDatatable() {
    datatable = $('#tblalbums').DataTable({
        "ajax": {
            "url": "/Albums/GetAll",
            "type": "Get",
            "datatype": "json",

        },
        "columns": [
            { "data": "albumID", "widtha": "10%" },
            { "data": "nombre", "widtha": "10%" },
            { "data": "fechaLanzamiento", "widtha": "10%" },
            { "data": "artista.nombre", "width": "20%" },           
            { "data": "urlImagen", "width": "20%" },

           {
               "data": "albumID",
               "render": function (data) {
                   return `<div clas="tex-center">
                    
                    <a href='/albums/Edit/${data}' class="btn btn-success" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-Edit"></i>Editar </a>

                    <a onclick=Delete("/Albums/Delete/${data}") class="btn btn-danger" style=" cursor:pointer; width=100%;">
                     <i class="fas fa-trash-alt"></i>Eliminar </a>


                    `;
                },"width":"20%"

            }


        ]    
            
            

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
 