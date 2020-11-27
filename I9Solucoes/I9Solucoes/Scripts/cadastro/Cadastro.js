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
{toastr.info("Por favor preencher o campo nome.","Atenção");
return;}
else if (dataNascimento=="")
{toastr.info("Por favor preencher o campo data de nascimento.","Atenção");
return;}
else if (cpf=="")
{toastr.info("Por favor preencher o campo CPF.","Atenção");
return;}
else if (sexo=="")
{toastr.info("Por favor preencher o campo sexo.","Atenção");
return;}
else if (mail=="")
{toastr.info("Por favor preencher o campo e-mail.","Atenção");
return;}
else if (celular=="")
{toastr.info("Por favor preencher o campo celular.","Atenção");
return;}
else if (whatsapp=="")
{toastr.info("Por favor nos informe se seu celular também é Whatsapp.","Atenção");
return;}
else if (senha!=confirmarSenha)
{toastr.info("As senhas digitadas não conferem.","Atenção");
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
{toastr.info(data.Mensagem,"Atenção");}
else
{
                swal({
                    title: "Êxito",
                    text: data.Mensagem,
                    icon: "info"
                }).then(() => { document.location.href = "/Home"; });
            }


        }
    });

}