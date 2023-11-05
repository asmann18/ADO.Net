using ADO.Net.DataAccess;
using ADO.Net.Entities;
using System.Data;

namespace ADO.Net.Services;

public class ArtistService
{
    Sql _dbcontext = new Sql();


    public List<Artist> GetAllArtists()
    {
        List<Artist> artists = new();
        string query = "select*from Artists";
        var table = _dbcontext.ExecuteQuery(query);

        foreach (DataRow row in table.Rows)
        {
            Artist artist = new()
            {
                Id = (int)row["Id"],
                Name = row["Name"].ToString(),
                Age = (int)row["Age"]
            };
            artists.Add(artist);

        }

        return artists;
    }
    public Artist GetByIdArtist(int id)
    {
        Artist artist = new();
        string query = $"select*from Artists where Id={id}";
        var result = _dbcontext.ExecuteQuery(query);
        if (result.Rows.Count == 0)
        {
            throw new Exception("Artist Not found");
        }
        artist.Id = (int)result.Rows[0]["Id"];
        artist.Name = result.Rows[0]["Name"].ToString();
        artist.Age = (int)result.Rows[0]["Age"];
        return artist;
    }

    public void CreateArtist(Artist artist)
    {
        string command = $"insert into Artists values ('{artist.Name}',{artist.Age})";
        int result = _dbcontext.ExecuteCommand(command);
        if (result > 0)
        {
            Console.WriteLine("Artist successfully added");
        }
    }
    public void UpdateArtist(Artist artist)
    {
        var existArtist = GetByIdArtist(artist.Id);
        if (existArtist is null)
        {
            throw new Exception("Artist not Found");
        }
        if (artist.Name.Length is not 0)
        {
            existArtist.Name = artist.Name;
        }
        if(artist.Age is not 0)
        {
            existArtist.Age = artist.Age;
        }
        string command = $"update Artists set Name='{existArtist.Name}',Age={existArtist.Age} where Id={artist.Id}";
        int result=_dbcontext.ExecuteCommand(command);
        if (result > 0)
        {
            Console.WriteLine("Artist is successfully updated");
        }
    }
    public void DeleteArtist(int id)
    {
        string command = $"delete from Artists where Id={id}";
        int result = _dbcontext.ExecuteCommand(command);
        if (result > 0)
        {
            Console.WriteLine("Artist successfully deleted");
        }

    }


}
