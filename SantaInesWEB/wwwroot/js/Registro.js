$(document).ready(function () {

	//Rellena el dropdown de estados
	var dropDown = $("#estadosDDL");
	$.ajax({
		type: "GET",
		url: 'https://localhost:7270/Direccion/ConsultarEstados',
		data: "",
		success: function (result) {
			var data = result.data;
			var s = '<option value="">Estado</option>';
			for (var i = 0; i < data.length; i++) {
				s += '<option value="' + data[i].id_estado + '">' + data[i].estado + '</option>';
			}
			dropDown.html(s);
			dropDown.prop('disabled', false);
		}
	});

	//Rellena el dropdown de municipios segun el estado que se seleccione
	$("#estadosDDL").change(function () {
		var dropDown = $("#municipiosDDL");
		dropDown.prop('disabled', true);
		$("#parroquiasDDL").prop('disabled', true);
		$("#municipiosDDL option:not(:first)").remove();
		$("#parroquiasDDL option:not(:first)").remove();
		var id_estado = $("#estadosDDL").val();

		if (id_estado)
			$.ajax({
				type: "GET",
				url: 'https://localhost:7270/Direccion/ConsultarMunicipios/' + id_estado,
				data: "",
				success: function (result) {
					var data = result.data;
					var s = '<option value="">Municipio</option>';
					for (var i = 0; i < data.length; i++) {
						s += '<option value="' + data[i].id_municipio + '">' + data[i].municipio + '</option>';
					}
					dropDown.html(s);
					dropDown.prop('disabled', false);
				}
			});
	});

	//Rellena el dropdown de parroquias segun el municipio que se seleccione
	$("#municipiosDDL").change(function () {
		var dropDown = $("#parroquiasDDL");
		dropDown.prop('disabled', true);
		$("#parroquiasDDL option:not(:first)").remove();
		var id_municipio = $("#municipiosDDL").val();

		if (id_municipio)
			$.ajax({
				type: "GET",
				url: 'https://localhost:7270/Direccion/ConsultarParroquias/' + id_municipio,
				data: "",
				success: function (result) {
					var data = result.data;
					var s = '<option value="">Parroquia</option>';
					for (var i = 0; i < data.length; i++) {
						s += '<option value="' + data[i].id_parroquia + '">' + data[i].parroquia + '</option>';
					}
					dropDown.html(s);
					dropDown.prop('disabled', false);
				}
			});
	});

});

$(function () {
	$("#telefono").mask("(999) 999-9999");
	$("#cedula").mask("99999999");
});

document.querySelector('#fecha').onchange = function () {
	this.style.color = "black";
};