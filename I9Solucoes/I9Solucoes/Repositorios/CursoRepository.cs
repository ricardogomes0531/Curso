using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using I9Solucoes.Models;

namespace I9Solucoes.Repositorios
{
	public class CursoRepository : DataBase
	{
		private SqlConnection _conexao;
		public CursoRepository()
		{
			_conexao = Conectar();
		}

		public bool Inserir(string nome, string usuarioCadastro, string endereco, string cep, string uf, string cidade, string numero, string complemento)
		{
			bool retorno = false;
			SqlCommand query = new SqlCommand("insert into Fornecedor(Nome, DataCadastro, DataAlteracao, UsuarioCadastro, UsuarioAlteracao, Endereco, Cep, Uf, Cidade, Numero, Complemento) values(@Nome, @DataCadastro, @DataAlteracao, @usuarioCadastro, @usuarioAlteracao, @Endereco, @Cep, @Uf, @Cidade, @Numero, @Complemento)", _conexao);
			_conexao.Open();
			SqlParameter parametroNome = new SqlParameter()
			{
				ParameterName = "@nome",
				SqlDbType = SqlDbType.VarChar,
				Value = nome
			};
			SqlParameter parametroDataCadastro = new SqlParameter()
			{
				ParameterName = "@dataCadastro",
				SqlDbType = SqlDbType.DateTime,
				Value = DateTime.Now
			};

			SqlParameter parametroDataAlteracao = new SqlParameter()
			{
				ParameterName = "@dataAlteracao",
				SqlDbType = SqlDbType.DateTime,
				Value = Convert.DBNull
			};

			SqlParameter parametroUsuarioCadastro = new SqlParameter()
			{
				ParameterName = "@usuarioCadastro",
				SqlDbType = SqlDbType.VarChar,
				Value = usuarioCadastro
			};

			SqlParameter parametroUsuarioAlteracao = new SqlParameter()
			{
				ParameterName = "@usuarioAlteracao",
				SqlDbType = SqlDbType.VarChar,
				Value = Convert.DBNull
			};

			SqlParameter parametroEndereco = new SqlParameter()
			{
				ParameterName = "@endereco",
				SqlDbType = SqlDbType.VarChar,
				Value = endereco
			};

			SqlParameter parametroCep = new SqlParameter()
			{
				ParameterName = "@cep",
				SqlDbType = SqlDbType.VarChar,
				Value = cep
			};

			SqlParameter parametroUf = new SqlParameter()
			{
				ParameterName = "@uf",
				SqlDbType = SqlDbType.VarChar,
				Value = uf
			};

			SqlParameter parametroCidade = new SqlParameter()
			{
				ParameterName = "@cidade",
				SqlDbType = SqlDbType.VarChar,
				Value = cidade
			};

			SqlParameter parametroNumero = new SqlParameter()
			{
				ParameterName = "@numero",
				SqlDbType = SqlDbType.VarChar,
				Value = numero
			};

			SqlParameter parametroComplemento = new SqlParameter()
			{
				ParameterName = "@complemento",
				SqlDbType = SqlDbType.VarChar,
				Value = complemento
			};

			query.Parameters.Add(parametroNome);
			query.Parameters.Add(parametroDataCadastro);
			query.Parameters.Add(parametroDataAlteracao);
			query.Parameters.Add(parametroUsuarioCadastro);
			query.Parameters.Add(parametroUsuarioAlteracao);
			query.Parameters.Add(parametroEndereco);
			query.Parameters.Add(parametroCep);
			query.Parameters.Add(parametroUf);
			query.Parameters.Add(parametroNumero);
			query.Parameters.Add(parametroComplemento);
			query.Parameters.Add(parametroCidade);
			if (query.ExecuteNonQuery() > 0)
				retorno = true;
			else
				retorno = false;

			return retorno;
		}

		public List<Curso> Listar()
		{
			List<Curso> retorno = new List<Curso>();
			SqlCommand query = new SqlCommand("select * from curso where Ativo=1", _conexao);
			_conexao.Open();
			SqlDataReader dados = query.ExecuteReader();
			while (dados.Read())
			{
				Curso curso = new Curso()
				{
					AceitaMatricula = dados.GetBoolean(dados.GetOrdinal("AceitaMatricula")),
					Ativo = dados.GetBoolean(dados.GetOrdinal("Ativo")),
					DataCadastro = dados.GetDateTime(dados.GetOrdinal("DataCadastro")),
					DataInicio = dados.GetDateTime(dados.GetOrdinal("DataInicio")),
					Descricao = dados.GetString(dados.GetOrdinal("Descricao")),
					Id = dados.GetInt32(dados.GetOrdinal("Id")),
					Nome = dados.GetString(dados.GetOrdinal("Nome")),
					TempoPrevistoDuracao = dados.GetInt32(dados.GetOrdinal("TempoPrevistoDuracao")),
					 ValorMonetario=dados.GetDecimal(dados.GetOrdinal("ValorMonetario")),
					  Explicacao=dados.GetString(dados.GetOrdinal("Explicacao"))
				};
retorno.Add(curso);
			}
			return retorno;
		}

		public Curso Buscar(int id)
		{
			Curso retorno = new Curso();
			SqlCommand query = new SqlCommand("select * from curso where Id=@id", _conexao);
			_conexao.Open();
			SqlParameter idParametro = new SqlParameter()
			{
				ParameterName = "@id",
				 SqlDbType=SqlDbType.Int,
				Value = id
			};
			query.Parameters.Add(idParametro);
			SqlDataReader dados = query.ExecuteReader();
			if (dados.Read())
			{
				retorno.AceitaMatricula = dados.GetBoolean(dados.GetOrdinal("AceitaMatricula"));
				retorno.DataInicio = dados.GetDateTime(dados.GetOrdinal("DataInicio"));
				retorno.Descricao = dados.GetString(dados.GetOrdinal("Descricao"));
				retorno.Explicacao = dados.GetString(dados.GetOrdinal("Explicacao"));
				retorno.Id = dados.GetInt32(dados.GetOrdinal("Id"));
				retorno.Nome = dados.GetString(dados.GetOrdinal("Nome"));
				retorno.TempoPrevistoDuracao = dados.GetInt32(dados.GetOrdinal("TempoPrevistoDuracao"));
				retorno.ValorMonetario = dados.GetDecimal(dados.GetOrdinal("ValorMonetario"));
				retorno.DataCadastro = dados.GetDateTime(dados.GetOrdinal("DataCadastro"));
				retorno.Ativo = dados.GetBoolean(dados.GetOrdinal("Ativo"));
			}
			return retorno;
		}

	}
}