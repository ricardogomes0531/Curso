use I9Solucoes;
	IF OBJECT_ID('dbo.usuario') is null
create table Usuario(Nome varchar(50) not null, DataNascimento date not null, Cpf varchar(14) not null, Sexo varchar(8) not null, Email varchar(50) not null, Celular varchar(11) not null, Whatsapp varchar(3) not null, senha varchar(10))
	IF OBJECT_ID('dbo.curso') is null
create table curso(Id int identity primary key, Nome varchar(50) not null, DataCadastro date not null, TempoPrevistoDuracao int not null, Descricao varchar(100) not null, Explicacao varchar(1000) not null, Ativo bit not null, AceitaMatricula bit not null, DataInicio date not null, ValorMonetario decimal not null)
--insere curso
insert into curso (nome, datacadastro, tempoprevistoduracao, descricao, explicacao, ativo, aceitamatricula, datainicio, valormonetario)
values('Lógica de programação para Deficientes Visuais', getdate(), 3, 'Curso prático de lógica de programação com php', 'Curso onde a pessoa cega aprenderá sem todo aquele sofrimento, os conceitos com prática aplicada.', 1, 1, '2020-11-01', '300.00')

	IF OBJECT_ID('dbo.aluno_curso') is null
create table aluno_curso(Id int identity primary key, IdCurso int, IdAluno int, SnLiberado varchar(1), DataCadastro datetime)
insert into aluno_curso(idcurso, idaluno, snliberado, datacadastro) values(1,2,'s',getdate());

	IF OBJECT_ID('dbo.modulo_curso') is null
create table modulo_curso(Id int identity primary key, IdCurso int, Nome varchar(50))
insert into modulo_curso(idcurso, nome) values(1, 'introdução')

insert into modulo_curso(idcurso, nome) values(1, 'Estruturas condicionais')


	IF OBJECT_ID('dbo.produto') is null
create table produto(Id int identity primary key,  IdFornecedor int not null, DataCadastro date not null, DataAlteracao date, UsuarioCadastro varchar(50) not null, UsuarioAlteracao varchar(50), EstoqueMinimo int, DataValidade date, Custo decimal not null, CustoVenda decimal not null, PrazoEntregaFornecedor int, Localizacao varchar(200), Marca varchar(50),
constraint cnt_fornecedor_produto foreign key(IdFornecedor) references fornecedor(Id))

