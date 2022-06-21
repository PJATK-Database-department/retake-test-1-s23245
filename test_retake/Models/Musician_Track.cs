namespace test_retake.Models;

public class Musician_Track
{
    public int IdTrack { get; set; }
    public int  IdMusician { get; set; }
    
    public Track Track { get; set; }
    public Musician Musician { get; set; }
}