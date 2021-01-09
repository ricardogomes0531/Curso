function salvar(){
var nome=$("#nome").val();
var dataNascimento=$("#dataNascimento").val();
var cpf=$("#cpf").val();
var sexo=$("#sexo").val();
var mail=$("#mail").val();
var celular=$("#celular").val();
var whatsapp=$("#whatsapp").val();
var senha=$("#criarSenha").val();
var confirmarSenha=$("#confirmarSenha").val();
if (nome=="")
{$("#alerta").html("<span>Favor preencher o campo nome.</span>");
return;}
else if (dataNascimento=="")
{$("#alerta").html("<span>Favor preencher o campo data de nascimento.</span>");
return;}
else if (cpf=="")
{$("#alerta").html("<span>Favor preencher o campo CPF.</span>");
return;}
else if (sexo=="")
{$("#alerta").html("<span>Favor preencher o campo sexo.</span>");
return;}
else if (mail=="")
{$("#alerta").html("<span>Favor preencher o campo e-mail.</span>");
return;}
else if (celular=="")
{$("#alerta").html("<span>Favor preencher o campo celular.</span>");
return;}
else if (whatsapp=="")
{$("#alerta").html("<span>Favor preencher o campo informando se seu celular é ou não é Whatsapp.</span>");
return;}
else if (senha!=confirmarSenha)
{$("#alerta").html("<span>As senhas digitadas não são iguais.</span>");
return;}

else if (senha=="")
{$("#alerta").html("<span>Preencher a senha.</span>");
return;}
else if (confirmarSenha=="")
{$("#alerta").html("<span>Preencher a confirmação da senha.</span>");
return;}

    $.ajax({
        type: 'POST',
        url: "/Cadastro/Salvar",
        async: true,
        datatype: "html",
data:{
nome: nome,
dataNascimento: dataNascimento,
cpf: cpf,
sexo: sexo,
email: mail,
celular: celular,
whatsapp: whatsapp,
senha: senha
},
        success: function (data) {
if (data.ExisteErro)
{$("#alerta").html("<span>"+data.Mensagem+"</span>")}
else
{
alert(data.Mensagem);
document.location.href="/home";
            }


        }
    });

}