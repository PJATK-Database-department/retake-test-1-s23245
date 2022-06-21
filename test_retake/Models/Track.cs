namespace test_retake.Models;

public class Track
{
    public int IdTrack { get; set; }
    public string TrackName { get; set; }
    public float Duration { get; set; }
    public Album? Album { get; set; }
    public int IdAlbum { get; set; }

    public ICollection<Musician_Track> MusicianTracks { get; set; }
}