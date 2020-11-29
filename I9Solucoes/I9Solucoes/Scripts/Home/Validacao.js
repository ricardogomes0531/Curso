function validarLogin() {
    var email = $("#email").val();
    var senha = $("#senha").val();
if (email=="" || senha=="")
{toastr.info("É necessário preencher e-mail e senha para fazer login.", "Atenção");
return;}
    $.ajax({
        type: "POST",
        url: '/Home/Logar',
        async: false,
        datatype: "html",
        data: {
            email: email,
            senha: senha
        },
        success: function (data) {
            if (!data) {
                toastr.info("E-mail ou senha inválidos", "Atenção");
            }
            else {
                document.location.href = "home/MeusCursos";
                        }
            }
        });
}

