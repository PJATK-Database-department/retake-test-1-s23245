namespace test_retake.Models;

public class MusicLabel
{
    public int IdMusicLabel { get; set; }
    public string Name { get; set; }

    public ICollection<Album> Albums { get; set; }
}