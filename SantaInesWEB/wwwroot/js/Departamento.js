﻿//const buscador = document.getElementById('search');
//const keys = [
//    { keyCode: 'AltLeft', isTriggered: false },
//    { keyCode: 'ControlLeft', isTriggered: false },
//];

// Script para mostrar ventana Agregar Departamento

$(function () {
    var PlaceHolderElement = $('#PlaceHolderAgregarDepartamento');
    $('button[data-toggle="agregarDepartamento-modal"]').click(function (event) {
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

$(function () {
    var PlaceHolderElement = $('#PlaceHolderModificarDepartamento');
    $('button[data-toggle="editarDepartamento-modal"]').click(function (event) {
        var rowNode = $(this).closest('tr');
        
        var id = $('#table-departamento').DataTable().row(rowNode).data()[0].toString();
        console.log(id);
        var url = $(this).data('url').replace("idDepartamento", id);
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})

//Script para mostrar ventana Eliminar Departamento

$(function () {
    var PlaceHolderElement = $('#PlaceHolderEliminarDepartamento');
    $('button[data-toggle="eliminarDepartamento-modal"]').click(function (event) {
        var id = $(this).closest('tr').find('.id').text();
        var url = $(this).data('url').replace("idDepartamento", id);
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})

//Script para activar el buscador con Alt+Ctrl

//window.addEventListener('keydown', (e) => {
//    keys.forEach((obj) => {
//        if (obj.keyCode === e.code) {
//            obj.isTriggered = true;
//        }
//    });

//    const shortcutTriggered = keys.filter((obj) => obj.isTriggered).length === keys.length;

//    if (shortcutTriggered) {
//        buscador.focus();
//    }
//});

//window.addEventListener('keyup', (e) => {
//    keys.forEach((obj) => {
//        if (obj.keyCode === e.code) {
//            obj.isTriggered = false;
//        }
//    });
//});