function converteDataJsonParaJavascript(value) {
    if (value == null)
        return null;
    var dataTexto = value.replace('/', '').replace('/', '').replace('Date', '').replace('(', '').replace(')', '');
    var date = new Date(parseInt(dataTexto));
    var dia = date.getDate();
    var mes = date.getMonth() + 1;
    var ano = date.getFullYear();
    if (mes != 10 && mes != 11 && mes != 12) {
        mes = "0" + mes;
    }

    return dia + "/" + mes + "/" + ano;
};

$(document).ready(function () {
$("#canalYoutube").load("/home/ListarVideos");
    $.ajax({
        type: 'GET',
        url: '/Home/Cursos',
        async: true,
        datatype: "html",
        success: function (data) {
            var html = "<table border='0' cellpadding='0' cellspacing='0' style='width:100%;'>";
            html += "<thead>";
            html += "<tr class='tab-titulo'>";
            html += "<th>Curso</th><th>Descrição</th><th>Tempo de Duração</th><th>Data de Início</th><th>Opção</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            html += "<tr>";
            for (var dados in data) {
                html += "<td>" + data[dados].Nome + "</td>";
                html += "<td>" + data[dados].Descricao + "</td>";
                html += "<td>" + data[dados].TempoPrevistoDuracao + " Meses</td>";
                html += "<td>" + converteDataJsonParaJavascript(data[dados].DataInicio) + "</td>";
                html += "<td><a href='/Curso/Detalhe?id="+data[dados].Id+"'>Saber Mais Informações</a></td>";
                html += "<td><a href='/Curso/Inscrever?idCurso="+data[dados].Id+"'>Inscrever-se neste curso</a></td>";
            }
            html += "</tr></tbody></table>";
            $("#cursos").html(html);

        }
    });
});

