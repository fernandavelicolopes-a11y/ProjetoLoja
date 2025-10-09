﻿using ProjetoLoja2DSA.Models;

namespace ProjetoLoja2DSA.Repositorio
{
    using MySql.Data.MySqlClient;
    using System.Data;

    public class UsuarioRepositorio(IConfiguration configuration)
    {
        // Declara um campo privado somente leitura para armazenar a string de conexão com o MySQL.
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        //metodo para cadastrar usuario
        public void AdicionarUsuario(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                //abrindo a conexao com o banco de dados
                conexao.Open();

                //cria uma variavel que vai receber o metodo criar comando
                var cmd = conexao.CreateCommand();

                //cria um novo comando MYSQL para inserir os dados na tabela usuario
                cmd.CommandText = "INSERT INTO Usuario (email, senha) Values (@email, @senha)";

                //adiciona o parametro email e define seu tipo
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.Email;

                //adiciona o parametro senha e define seu tipo
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.Senha;

                //executa o comando SQL e insere os dados e retorna as linhas afetadas
                cmd.ExecuteNonQuery();

                //fecha a conexao com o banco de dados
                conexao.Close();
            }
        }

        // metodo para buscar todos os usuarios
        public Usuario ObterUsuario(string email)
        {
            // Cria uma nova instância da conexão MySQL dentro de um bloco 'using'.
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                // Abre a conexão com o banco de dados MySQL.
                conexao.Open();

                // Cria um novo comando SQL para selecionar todos os campos da tabela 'Usuario' onde o campo 'Email' corresponde ao parâmetro fornecido.
                MySqlCommand cmd = new("SELECT * FROM Usuario WHERE Email = @email", conexao);

                // Adiciona um parâmetro ao comando SQL para o campo 'Email', especificando o tipo como VarChar e utilizando o valor do parâmetro 'email'.
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

                // Executa o comando SQL SELECT e obtém um leitor de dados (MySqlDataReader). O CommandBehavior.CloseConnection garante que a conexão
                // será fechada automaticamente quando o leitor for fechado.
                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    // Inicializa uma variável 'usuario' como null. Ela será preenchida se um usuário for encontrado.
                    Usuario usuario = null;
                    // Lê a próxima linha do resultado da consulta. Retorna true se houver uma linha e false caso contrário.
                    if (dr.Read())
                    {
                        // Cria uma nova instância do objeto 'Usuario'.
                        usuario = new Usuario
                        {
                            // Lê o valor da coluna "Id" da linha atual do resultado, converte para inteiro e atribui à propriedade 'Id' do objeto 'usuario'.
                            Id = Convert.ToInt32(dr["id"]),
                            // Lê o valor da coluna "Nome" da linha atual do resultado, converte para string e atribui à propriedade 'Nome' do objeto 'usuario'.
                            //Nome = dr["nome"].ToString(),
                            // Lê o valor da coluna "Email" da linha atual do resultado, converte para string e atribui à propriedade 'Email' do objeto 'usuario'.
                            Email = dr["email"].ToString(),
                            // Lê o valor da coluna "Senha" da linha atual do resultado, converte para string e atribui à propriedade 'Senha' do objeto 'usuario'.
                            Senha = dr["senha"].ToString()
                        };
                    }
                    /* Retorna o objeto 'usuario'. Se nenhum usuário foi encontrado com o email fornecido, a variável 'usuario'
                     permanecerá null e será retornado.*/
                    return usuario;
                }
            }
        }
    }
 }
