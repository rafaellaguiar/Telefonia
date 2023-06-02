using MySqlConnector;
using Telefonia.Core.Models;

namespace Telefonia.Core.Repositories;

public class TelefoneRepository
{
    private readonly MySqlConnection _connection;

    public TelefoneRepository(MySqlConnection connection)
    {
        _connection = connection;
    }

    public async Task InserirContato(int idContato, string numeroTelefone, string nomeContato, string idUsuario)
    {
        await _connection.OpenAsync();

        var command = $"call InserirContato({idContato}, {numeroTelefone}, {nomeContato},{idUsuario})";

        var sqlCommand = new MySqlCommand(command, _connection);

        await sqlCommand.ExecuteNonQueryAsync();

        _connection.Close();
    }

    public async Task InserirUsuario(string idUsuario, string nome, string telefone, string email)
    {
        await _connection.OpenAsync();

        var command = $"call InserirUsuario({idUsuario}, {nome}, {telefone},{email})";

        var sqlCommand = new MySqlCommand(command, _connection);

        await sqlCommand.ExecuteNonQueryAsync();

        _connection.Close();
    }


    public async Task<IEnumerable<Usuario>> GetContatos(string idUsuario) 
    {
        await _connection.OpenAsync();

        var command = $"call ObterContatosPorUsuario({idUsuario})"; 

        var sqlCommand = new MySqlCommand(command, _connection);
        var usuarios = new List<Usuario>();

       var reader =  await sqlCommand.ExecuteReaderAsync();

        while (reader.Read()) 
        {
            usuarios.Add(new Usuario()
            {
                IdUsuario = reader["idUsuario"].ToString(),
                Email = reader["email"].ToString(),
                Nome = reader["nome"].ToString(),
                Telefone = reader["telefone"].ToString()
            }) ;
        };

        _connection.Close();
        return usuarios;
    }
}
