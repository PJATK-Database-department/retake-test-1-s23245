using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using test_retake.DTO;
using test_retake.Models;

namespace test_retake.Services;

public class DbService : IDbService
{
    private string _connectionString;

    public DbService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("LocalHost");
    }
    
    public AlbumDTO GetAlbum(int idAlbum)
    {
        AlbumDTO result = new AlbumDTO();
        string selectString = "SELECT a.AlbumName,a.PublishDate,a.IdMusicLabel,t.TrackName FROM dbo.Album a JOIN " +
                              " dbo.Track t on a.IdAlbum = t.IdAlbum WHERE a.IdAlbum = @IdAlbum ORDER BY t.Duration ASC";

        var connection = new SqlConnection(_connectionString);
        var command = new SqlCommand(selectString, connection);

        List<string> tracks = new List<string>();
        
        connection.Open();
        command.Parameters.AddWithValue("@IdAlbum", idAlbum);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.AlbumName = (string) reader[0];
                result.PublishDate = (DateTime) reader[1];
                result.IdMusicLabel = (int)reader[2];
                    tracks.Add((string)reader[3]);
            }
            
        connection.Close();

        result.Tracks = tracks;
        return result;
    }

    public bool CheckIdAlbum(int idAlbum)
    {
        string selectString = "SELECT COUNT(*) FROM dbo.Album WHERE IdAlbum = @IdAlbum";
        var connection = new SqlConnection(_connectionString);
        var command = new SqlCommand(selectString, connection);

        command.Parameters.AddWithValue("@IdAlbum", idAlbum);
        
        connection.Open();
            int UserExist = (int)command.ExecuteScalar();
        connection.Close();

        if (UserExist > 0)
            return true;

        return false;
    }

    public void DeleteMusician(int idMusician)
    {
        string selectString = "DELETE FROM Musician WHERE IdMusician = @IdMusician";

        var connection = new SqlConnection(_connectionString);
        var command = new SqlCommand(selectString, connection);

        connection.Open();
        command.Parameters.AddWithValue("@IdMusician", idMusician);
        int reader = (int)command.ExecuteScalar();

        connection.Close();
    }
}   