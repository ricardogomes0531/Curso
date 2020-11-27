use I9Solucoes;
	IF OBJECT_ID('dbo.usuario') is null
create table usuario(Id int identity primary key, DataCadastro date not null, Nome varchar(50) not null, Email varchar(50) not null, TipoDocumento char(4) not null, Documento varchar(20) not null, senha varchar(100) not null, Isadmin bit, DataNascimento date not null);
	IF OBJECT_ID('dbo.curso') is null
create table curso(Id int identity primary key, Nome varchar(50) not null, DataCadastro date not null, TempoPrevistoDuracao int not null, Descricao varchar(1000) not null, Ativo bit not null, AceitaMatricula bit not null, DataInicio date not null, ValorMonetario decimal not null)


	IF OBJECT_ID('dbo.produto') is null
create table produto(Id int identity primary key,  IdFornecedor int not null, DataCadastro date not null, DataAlteracao date, UsuarioCadastro varchar(50) not null, UsuarioAlteracao varchar(50), EstoqueMinimo int, DataValidade date, Custo decimal not null, CustoVenda decimal not null, PrazoEntregaFornecedor int, Localizacao varchar(200), Marca varchar(50),
constraint cnt_fornecedor_produto foreign key(IdFornecedor) references fornecedor(Id))

