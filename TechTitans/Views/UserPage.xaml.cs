namespace TechTitans.Views;
using TechTitans.Views.Components.User;
using TechTitans.Views.Components;
using TechTitans.Models;
using TechTitans.Repositories;
using TechTitans.Services;
using Microsoft.Extensions.Configuration;
using System.Data;

    public partial class UserPage : ContentPage
    {
    private static readonly IConfiguration Configuration = MauiProgram.Configuration;
    private static IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("TechTitansDev"));
    private static IDatabaseOperations databaseOperations = new DatabaseOperations(connection);
    public UserController UserService = new UserController(new UserSongRepository(databaseOperations));
        public UserPage()
        {
            InitializeComponent();
            LoadSongs();
            LoadSongRecommandation();
            LoadAdvertisedSongs();
        }
    private void LoadSongs()
    {
        var recentlyPlayedSongs = UserService.GetRecentlyPlayed();

        int rowIndex = 0;
        int columnIndex = 0;
        SongsGrid.RowDefinitions.Add(new RowDefinition());
        foreach (var song in recentlyPlayedSongs)
        {
            var songGuiItem = new SongItem();
            songGuiItem.BindingContext = song;
            songGuiItem.Margin = new Thickness(0, 5, 0, 5);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += SongItem_Tapped;
            songGuiItem.GestureRecognizers.Add(tapGestureRecognizer);

            Grid.SetRow(songGuiItem, rowIndex);
            Grid.SetColumn(songGuiItem, columnIndex);
            SongsGrid.Children.Add(songGuiItem);
            columnIndex++;
            if (columnIndex == 2)
            {
                columnIndex = 0;
                rowIndex++;
                SongsGrid.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
        private void LoadAdvertisedSongs()
        {
            var songs = GetMockedSongs();
            int rowIndex = 0;
            int columnIndex = 0;
            SongsAdvertisedGrid.RowDefinitions.Add(new RowDefinition());
            foreach (var song in songs)
            {
                var songItem = new SongItem();
                songItem.BindingContext = song;
                songItem.Margin = new Thickness(0, 5, 0, 5);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += SongItem_Tapped;
                songItem.GestureRecognizers.Add(tapGestureRecognizer);

                Grid.SetRow(songItem, rowIndex);
                Grid.SetColumn(songItem, columnIndex);
                SongsAdvertisedGrid.Children.Add(songItem);
                columnIndex++;
                if (columnIndex == 2)
                {
                    columnIndex = 0;
                    rowIndex++;
                    SongsAdvertisedGrid.RowDefinitions.Add(new RowDefinition());
                }
            }
        }
    private void LoadSongRecommandation()
    {
        var songs = GetMockedSongs();
        int rowIndex = 0;
        int columnIndex = 0;
        SongsRecommandationGrid.RowDefinitions.Add(new RowDefinition());
        foreach (var song in songs)
        {
            var songItem = new SongItem();
            songItem.BindingContext = song;
            songItem.Margin = new Thickness(0, 5, 0, 5);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += SongItem_Tapped;
            songItem.GestureRecognizers.Add(tapGestureRecognizer);

            Grid.SetRow(songItem, rowIndex);
            Grid.SetColumn(songItem, columnIndex);
            SongsRecommandationGrid.Children.Add(songItem);
            columnIndex++;
            if (columnIndex == 2)
            {
                columnIndex = 0;
                rowIndex++;
                SongsRecommandationGrid.RowDefinitions.Add(new RowDefinition());
            }
        }
    }

    private void SongItem_Tapped(object sender, System.EventArgs e)
    {
        var songItem = (SongItem)sender;
        var songInfo = songItem.BindingContext as SongBasicInformation;
        Navigation.PushAsync(new UserSongDashboard(songInfo));
    }

    private List<SongBasicInformation> GetMockedSongs()
    {
        List<string> features = new List<string>();

        features.Add("feature1");

        return new List<SongBasicInformation>
            {
                new SongBasicInformation { SongId = 0, Name = "Song 1", Artist = "Artist 1", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features },
                new SongBasicInformation { SongId = 1, Name = "Song 2", Artist = "Artist 2", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features },
                new SongBasicInformation { SongId = 2, Name = "Song 3", Artist = "Artist 3", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features },
                new SongBasicInformation { SongId = 3, Name = "Song 4", Artist = "Artist 4", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features },
                new SongBasicInformation { SongId = 4, Name = "Song 5", Artist = "Artist 5", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features },
                new SongBasicInformation { SongId = 5, Name = "Song 6", Artist = "Artist 6", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features },
            };
    }
}
