using test_retake.Models;

namespace test_retake.DTO;

public class AlbumDTO
{
    public string AlbumName { get; set; }
    public DateTime PublishDate { get; set; }
    public int IdMusicLabel { get; set; }

    public List<string> Tracks { get; set; }
}