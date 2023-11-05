using ADO.Net.DataAccess;
using ADO.Net.Entities;
using System.Data;

namespace ADO.Net.Services;

public class MusicService
{
    Sql _dbcontext = new();
    ArtistService _artistService = new();


    public List<Music> GetAllMusics()
    {
        List<Music> musics = new();
        string query = "select*from Musics";
        var table = _dbcontext.ExecuteQuery(query);
        foreach (DataRow row in table.Rows)
        {
            Music music = new()
            {
                Name = row["Name"].ToString(),
                ArtistId = (int)row["ArtistId"],
                Artist = _artistService.GetByIdArtist((int)row["ArtistId"]),
                Duration = (int)row["Duration"]
            };
            musics.Add(music);
        }
        return musics;
    }
    public Music GetByIdMusic(int id)
    {
        Music music = new();
        string query = $"select*from Musics where Id={id}";
        var table = _dbcontext.ExecuteQuery(query);
        if (table.Rows.Count == 0)
        {
            throw new Exception("Music Not found");
        }
        music.Id = (int)table.Rows[0]["Id"];
        music.Name = table.Rows[0]["Name"].ToString();
        music.ArtistId = (int)table.Rows[0]["ArtistId"];
        music.Duration = (int)table.Rows[0]["Duration"];
        music.Artist = _artistService.GetByIdArtist((int)table.Rows[0]["ArtistId"]);

        return music;
    }

    public void CreateMusic(Music music)
    {
        string command = $"insert into Musics values('{music.Name}',{music.Duration},{music.ArtistId})";
        int result=_dbcontext.ExecuteCommand(command);
        if (result > 0) {
            Console.WriteLine("Music successfully added");
        }
    }
    public void UpdateMusic(Music music)
    {
        var existMusic = GetByIdMusic(music.Id);
        if (existMusic is null)
            throw new Exception("music not found");
        if(music.Name.Length is not 0)
            existMusic.Name=music.Name;
        if(music.ArtistId is not 0)
            existMusic.ArtistId=music.ArtistId;
        if(music.Duration is not 0)
            existMusic.Duration=music.Duration;


        string command = $"update Musics set Name='{existMusic.Name}',Duration={existMusic.Duration},ArtistId={existMusic.ArtistId} where Id={music.Id}";
        int result = _dbcontext.ExecuteCommand(command);
        if (result > 0)
        {
            Console.WriteLine("Music is successfully updated");
        }
    }
    public void DeleteMusic(int id)
    {
        string command = $"delete from Musics where Id={id}";
        int result = _dbcontext.ExecuteCommand(command);
        if (result > 0)
        {
            Console.WriteLine("Music successfully deleted");
        }
    }
}
