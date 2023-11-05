using ADO.Net.Entities;
using ADO.Net.Services;
using System.Threading.Channels;

namespace ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicService musicService = new();
            ArtistService artistService = new();

            Music music = new()
            {
                Name = "Shemmamme updated",
                Duration = 300,
                ArtistId = 2,
                //Id=1
            };
            Artist artist = new()
            {
                Id=2,
                Name="Asiman",
                Age=20
            };

            //musicService.CreateMusic(music);
            //musicService.UpdateMusic(music);

            //var getMusic=musicService.GetByIdMusic(1);
            //Console.WriteLine(getMusic.Name+" "+getMusic.Artist.Name);

            //var musics=musicService.GetAllMusics();
            //musics.ForEach(x=>Console.WriteLine(x.Name));
            //musicService.DeleteMusic(1);

            //artistService.CreateArtist(artist);
            //var getArtist=artistService.GetByIdArtist(2);
            //Console.WriteLine(getArtist.Name);
            artistService.UpdateArtist(artist);
            var artists=artistService.GetAllArtists();
            artists.ForEach(artist => Console.WriteLine(artist.Name));


        }
    }
}