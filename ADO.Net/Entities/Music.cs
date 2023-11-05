namespace ADO.Net.Entities;

public class Music
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public Artist Artist { get; set; }
    public int ArtistId { get; set; }
}
