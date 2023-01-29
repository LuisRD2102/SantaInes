
// Script para mostrar ventana Agregar Empleado

$(function () {
    var PlaceHolderElement = $('#PlaceHolderAgregarEmpleado');
    $('button[data-toggle="agregarEmpleado-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})

//Script para mostrar ventana Editar Departamento

//$(function () {
//    var PlaceHolderElement = $('#PlaceHolderModificarDepartamento');
//    $('button[data-toggle="editarDepartamento-modal"]').click(function (event) {
//        var id = $(this).closest('tr').find('.id').text();
//        console.log(id);
//        var url = $(this).data('url').replace("idDepartamento", id);
//        $.get(url).done(function (data) {
//            PlaceHolderElement.html(data);
//            PlaceHolderElement.find('.modal').modal('show');
//        })
//    })
//})

//Script para mostrar ventana Eliminar Departamento

//$(function () {
//    var PlaceHolderElement = $('#PlaceHolderEliminarDepartamento');
//    $('button[data-toggle="eliminarDepartamento-modal"]').click(function (event) {
//        var id = $(this).closest('tr').find('.id').text();
//        var url = $(this).data('url').replace("idDepartamento", id);
//        $.get(url).done(function (data) {
//            PlaceHolderElement.html(data);
//            PlaceHolderElement.find('.modal').modal('show');
//        })
//    })
//})

