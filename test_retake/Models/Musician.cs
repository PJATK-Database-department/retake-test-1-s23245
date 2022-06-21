namespace test_retake.Models;

public class Musician
{
    public int IdMusician { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Nickname { get; set; }

    public ICollection<Musician_Track> MusicianTracks { get; set; }
}