using TechTitans.Enums;
using TechTitans.Models;
using TechTitans.ViewModels;

namespace TechTitans.Views;

public partial class EndOfYearRecap : ContentPage
{
	public EndOfYearRecap()
	{
		var mockSongs = new List<SongBasicInfo>()
		{
			new()
			{
				SongId = 1,
				Name = "Roma1",
				Genre = "Manele",
				Subgenre = "Trapanele",
				Artist = "BDLP",
				Features = new[] {"Ian"},
				Language = "Romanian",
				Country = "Romania",
				Album = "Single",
				Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new()
            {
                SongId = 1,
                Name = "Roma2",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] {"Ian"},
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new()
            {
                SongId = 1,
                Name = "Roma3",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] {"Ian"},
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new()
            {
                SongId = 1,
                Name = "Roma4",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] {"Ian"},
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new SongBasicInfo()
            {
                SongId = 1,
                Name = "Roma5",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] {"Ian"},
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            }
        };

        var viewModel = new EndOfYearRecapViewModel()
        {
            Top5MostListenedSongs = mockSongs,
            MostPlayedSongPercentile = new Tuple<SongBasicInfo, decimal>(mockSongs.FirstOrDefault(), 0.1m),
            MostPlayedArtistPercentile = new Tuple<string, decimal>("BDLP", 0.01m),
            MinutesListened = 9000,
            Top5Genres = ["Manele", "Trap", "Rock", "Rap", "Pop"],
            NewGenresDiscovered = ["Jazz", "Populara", "Clasical", "R&B", "Country"],
            ListenerPersonality = ListenerPersonality.Adventurer
        };

        BindingContext = viewModel;

		InitializeComponent();
	}
}