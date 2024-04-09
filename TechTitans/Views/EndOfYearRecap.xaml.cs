using TechTitans.Enums;
using TechTitans.Models;
using TechTitans.ViewModels;
using TechTitans.Views.Components.EndOfYearRecap;

namespace TechTitans.Views;

public partial class EndOfYearRecap : ContentPage
{
    private int _pageIndex = 0;
    private List<ProgressBar> _progressBar;
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
            MostPlayedSongPercentile = new Tuple<SongBasicInfo, float>(mockSongs.FirstOrDefault(), 0.1f),
            MostPlayedArtistPercentile = new Tuple<string, float>("BDLP", 0.01f),
            MinutesListened = 9000,
            Top5Genres = ["Manele", "Trap", "Rock", "Rap", "Pop"],
            NewGenresDiscovered = ["Jazz", "Populara", "Clasical", "R&B", "Country"],
            ListenerPersonality = ListenerPersonality.Adventurer
        };

        BindingContext = viewModel;
        InitializeComponent();
        _progressBar = [ProgressBar1, ProgressBar2, ProgressBar3, ProgressBar4, ProgressBar5, ProgressBar6, ProgressBar7];
        ChangeScreens();
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) {
        await _progressBar[_pageIndex - 1].ProgressTo(1,0,Easing.Linear);
    }

    private async void ChangeScreens()
    {
        _pageIndex++;
        var localIndex = _pageIndex;
        switch (_pageIndex)
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
            default:
                Application.Current.MainPage = new NavigationPage(new MainPage());
                return;
        }
        await _progressBar[_pageIndex - 1].ProgressTo(1, 5000, Easing.Linear);
        ChangeScreens();
    }
}