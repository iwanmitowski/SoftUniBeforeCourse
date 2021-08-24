namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            var albumsInfo = ExportAlbumsInfo(context, 9);
            var songAboutDurationInfo = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(songAboutDurationInfo);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s => new
                    {
                        s.Name,
                        Price = s.Price,
                        SongWriterName = s.Writer.Name
                    })
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.SongWriterName).ToList(),
                    TotalAlbumPrice = x.Price,

                })
                .ToList();

            foreach (var album in albums.OrderByDescending(x => x.TotalAlbumPrice))
            {
                int counter = 1;
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context.Songs
                .ToList() //!!!
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    x.Name,
                    Performer = x.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault(),
                    Writer = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    x.Duration,
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToList();

            int counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer:f2}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer:f2}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().Trim();
        }
    }
}
