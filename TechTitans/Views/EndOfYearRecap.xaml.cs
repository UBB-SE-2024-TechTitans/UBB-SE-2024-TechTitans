using TechTitans.Enums;
using TechTitans.Models;
using TechTitans.Services;
using TechTitans.ViewModels;
using TechTitans.Views.Components.EndOfYearRecap;

namespace TechTitans.Views;

public partial class EndOfYearRecap : ContentPage
{
    private int pageIndex = 0;
    private List<ProgressBar> progressBar;
    private EndOfYearRecapViewModel viewModel;
	public EndOfYearRecap()
	{
		var mockSongs = new List<SongBasicInformation>()
		{
			new ()
			{
				SongId = 1,
				Name = "Roma1",
				Genre = "Manele",
				Subgenre = "Trapanele",
				Artist = "BDLP",
				Features = new[] { "Ian" },
				Language = "Romanian",
				Country = "Romania",
				Album = "Single",
				Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new ()
            {
                SongId = 1,
                Name = "Roma2",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] { "Ian" },
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new ()
            {
                SongId = 1,
                Name = "Roma3",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] { "Ian" },
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new ()
            {
                SongId = 1,
                Name = "Roma4",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] { "Ian" },
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            },
            new SongBasicInformation()
            {
                SongId = 1,
                Name = "Roma5",
                Genre = "Manele",
                Subgenre = "Trapanele",
                Artist = "BDLP",
                Features = new[] { "Ian" },
                Language = "Romanian",
                Country = "Romania",
                Album = "Single",
                Image = "https://i.ytimg.com/vi/Ovbn5mPit8o/sddefault.jpg?v=64c3f573"
            }
        };

        List<string> top5gen = new List<string>();
        List<string> newgen = new List<string>();
        top5gen.AddRange(["Manele", "Trap", "Rock", "Rap", "Pop"]);
        newgen.AddRange(["Jazz", "Populara", "Clasical", "R&B", "Country"]);

        var viewModel = new EndOfYearRecapViewModel()
        {
            Top5MostListenedSongs = mockSongs,
            MostPlayedSongPercentile = new Tuple<SongBasicInformation, decimal>(mockSongs.FirstOrDefault(), 0.1m),
            MostPlayedArtistPercentile = new Tuple<string, decimal>("BDLP", 0.01m),
            MinutesListened = 9000,
            Top5Genres = top5gen,
            NewGenresDiscovered = newgen,
            ListenerPersonality = ListenerPersonality.Explorer
        };

        viewModel = new RecapController().GenerateEndOfYearRecap(1001);

        BindingContext = viewModel;
        this.viewModel = viewModel;
        InitializeComponent();
        progressBar.AddRange([ProgressBar1, ProgressBar2, ProgressBar3, ProgressBar4, ProgressBar5, ProgressBar6, ProgressBar7, ProgressBar8]);
        ChangeScreens();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await progressBar[pageIndex - 1].ProgressTo(1, 0, Easing.Linear);
    }

    private async void ChangeScreens()
    {
        pageIndex++;
        switch (pageIndex)
        {
            case 1:
                MainContentWindow.Content = new FirstScreen();
                break;
            case 2:
                MainContentWindow.Content = new MinutesListenedScreen()
                {
                    BindingContext = BindingContext
                };
                break;
            case 3:
                MainContentWindow.Content = new Top5SongsScreen()
                {
                    BindingContext = BindingContext
                };
                break;
            case 4:
                MainContentWindow.Content = new MostPlayedSongScreen()
                {
                    BindingContext = BindingContext
                };
                break;
            case 5:
                MainContentWindow.Content = new MostPlayedArtistScreen()
                {
                    BindingContext = BindingContext
                };
                break;
            case 6:
                MainContentWindow.Content = new MostListenedGenresScreen()
                {
                    BindingContext = BindingContext
                };
                break;
            case 7:
                MainContentWindow.Content = new NewGenresScreen()
                {
                    BindingContext = BindingContext
                };
                break;
            case 8:
                MainContentWindow.Content = new ListenerPersonalityScreen(viewModel)
                {
                    BindingContext = BindingContext,
                };
                break;
            default:
                await Navigation.PopAsync();
                return;
        }
        await progressBar[pageIndex - 1].ProgressTo(1, 5000, Easing.Linear);
        ChangeScreens();
    }
}