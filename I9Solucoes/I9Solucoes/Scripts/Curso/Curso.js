function inscrever(){
var idCurso=$("#idCurso").val();
var tempoAssinatura=$("#tempoAssinatura").val();
$("#botaoInscrever").prop("disabled","true");
    $.ajax({
        type: 'POST',
        url: "/Curso/InscreverNoCurso",
        async: true,
        datatype: "html",
data:{
idCurso: idCurso,
tempoAssinatura: tempoAssinatura
},
        success: function (data) {
if (!data.ExisteErro)
{
$("#alerta").html("<h2>"+data.Mensagem+"</h2>");
$("#inscricao").hidd();}
else
{
$("#botaoInscrever").prop("enabled","true");
$("#alerta").html("<h2>"+data.Mensagem+"</h2><a href='javascript:window.history.go(-1)'>Voltar</a>");}
        }
    });
}