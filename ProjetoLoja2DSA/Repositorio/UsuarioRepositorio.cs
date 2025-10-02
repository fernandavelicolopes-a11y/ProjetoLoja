using ProjetoLoja2DSA.Models;

namespace ProjetoLoja2DSA.Repositorio
{
    using MySql.Data.MySqlClient;

    public class UsuarioRepositorio(IConfiguration configuration)
    {
        // Declara um campo privado somente leitura para armazenar a string de conexão com o MySQL.
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");
    }
}
public Usuario ObterUsuario(string email)
{


}