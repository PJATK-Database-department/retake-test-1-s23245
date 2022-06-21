using test_retake.DTO;

namespace test_retake.Services;

public interface IDbService
{
    AlbumDTO GetAlbum(int idAlbum);
    bool CheckIdAlbum(int idAlbum);
    void DeleteMusician(int idMusician);

}