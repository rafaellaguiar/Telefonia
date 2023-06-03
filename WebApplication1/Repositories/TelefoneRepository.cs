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

    public async Task InserirContato(string numeroTelefone, string nomeContato, string idUsuario)
    {
        await _connection.OpenAsync();

        var command = $"call InserirContato(\"{numeroTelefone}\", \"{nomeContato}\", \"{idUsuario} \")";

        var sqlCommand = new MySqlCommand(command, _connection);

        await sqlCommand.ExecuteNonQueryAsync();

        _connection.Close();
    }
    public async Task<bool> DeleteContato(int idContato)
    {
        await _connection.OpenAsync();

        var command = $"call DeletarContato({idContato})";

        var sqlCommand = new MySqlCommand(command, _connection);

        try
        {
            await sqlCommand.ExecuteNonQueryAsync();
        } catch
        {
            return false;
        }

        _connection.Close();

        return true;
    }
    public async Task<bool> AlterarNomeContato(int idContato, string novoNomeContato)
    {
        await _connection.OpenAsync();

        var command = $"call AlterarNomeContato({idContato}, \"{novoNomeContato}\")";

        var sqlCommand = new MySqlCommand(command, _connection);

        await sqlCommand.ExecuteNonQueryAsync();

        _connection.Close();

        return true;
    }
    public async Task<IEnumerable<Contato>> GetContatos(string idUsuario) 
    {
        await _connection.OpenAsync();

        var command = $"call ObterContatosPorUsuario(\"{idUsuario}\")"; 

        var sqlCommand = new MySqlCommand(command, _connection);
        var contatos = new List<Contato>();

       var reader =  await sqlCommand.ExecuteReaderAsync();

        while (reader.Read()) 
        {
            contatos.Add(new Contato()
            {
                IdUsuario = reader["idUsuario"].ToString(),
                IdContato = Int32.Parse(reader["idContato"].ToString()),
                NumeroTelefone = reader["numeroTelefone"].ToString(),
                NomeContato = reader["nomeContato"].ToString(),
            }) ;
        };

        _connection.Close();
        return contatos;
    }
}
