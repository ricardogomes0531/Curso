$(document).ready(function () {
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
                html += "<td>" + data[dados].TempoPrevistoDuracao + "< Meses/td>";
                html += "<td>" + data[dados].DataInicio + "</td>";
                html += "<td><a href=''>Saber Mais Informações</a></td>";
                html += "<td><a href=''>Inscrever-se</a></td>";
            }
            html += "</tr></tbody></table>";
            $("#cursos").html(html);

        }
    });
});

