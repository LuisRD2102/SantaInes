//Script para mostrar ventana Editar Empleado

$(function () {
    var PlaceHolderElement = $('#PlaceHolderModificarEmpleado');
    $('button[data-toggle="editarEmpleado-modal"]').click(function (event) {
        var rowNode = $(this).closest('tr');
        var usuario = $('#table-empleado').DataTable().row(rowNode).data()[3].toString();
        console.log(usuario);
        var url = $(this).data('url').replace("Usuario", usuario);
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})

//Script para mostrar ventana Eliminar Empleado

$(function () {
    var PlaceHolderElement = $('#PlaceHolderEliminarEmpleado');
    $('button[data-toggle="eliminarEmpleado-modal"]').click(function (event) {
        var rowNode = $(this).closest('tr');
        var usuario = $('#table-empleado').DataTable().row(rowNode).data()[3].toString();
        console.log(usuario);
        var url = $(this).data('url').replace("Usuario", usuario);
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})

