namespace TechTitans.Views;
using TechTitans.Views.Components.User;
using TechTitans.Views.Components;
using TechTitans.Models;

    public partial class UserPage : ContentPage
    {

        public UserPage()
        {
            InitializeComponent();
            LoadSongs(); //here we load the most recently played songs
            LoadSongRecommandation(); //here we load song recommandation
            LoadAdvertisedSongs(); //here we load song advertised
        }
    private void LoadSongs()
    {
        var songs = GetSongs(); // Get your list of most recently played songs from somewhere (e.g., database, API, local storage)

        // Loop through each song and dynamically create SongItem controls
        int rowIndex = 0;
        int columnIndex = 0;
        SongsGrid.RowDefinitions.Add(new RowDefinition());
        foreach (var song in songs)
        {
            var songItem = new SongItem(); // Create a new instance of SongItem
            songItem.BindingContext = song; // Set the song as the binding context of the SongItem
            songItem.Margin = new Thickness(0, 5, 0, 5); // Set margin as needed

            // Add TapGestureRecognizer to handle tap event
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += SongItem_Tapped;
            songItem.GestureRecognizers.Add(tapGestureRecognizer);

            // Set the row and column of the SongItem in the grid
            Grid.SetRow(songItem, rowIndex);
            Grid.SetColumn(songItem, columnIndex);
            // Add the SongItem to the grid
            SongsGrid.Children.Add(songItem);
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
            var songs = GetSongs(); // Get your list of recommended songs from somewhere (e.g., database, API, local storage)
            //for now we use the same mock function for retreving songs for frontend building purposes
            // Loop through each song and dynamically create SongItem controls
            int rowIndex = 0;
            int columnIndex = 0;
            SongsAdvertisedGrid.RowDefinitions.Add(new RowDefinition());
            foreach (var song in songs)
            {
                var songItem = new SongItem(); // Create a new instance of SongItem
                songItem.BindingContext = song; // Set the song as the binding context of the SongItem
                songItem.Margin = new Thickness(0, 5, 0, 5); // Set margin as needed

                // Add TapGestureRecognizer to handle tap event
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += SongItem_Tapped;
                songItem.GestureRecognizers.Add(tapGestureRecognizer);

                // Set the row and column of the SongItem in the grid
                Grid.SetRow(songItem, rowIndex);
                Grid.SetColumn(songItem, columnIndex);
                // Add the SongItem to the grid
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
        var songs = GetSongs(); // Get your list of recommended songs from somewhere (e.g., database, API, local storage)
                                //for now we use the same mock function for retreving songs for frontend building purposes
                                //note: we will need multiple sql commands for retriving different type of recommandations
                                // Loop through each song and dynamically create SongItem controls
        int rowIndex = 0;
        int columnIndex = 0;
        SongsRecommandationGrid.RowDefinitions.Add(new RowDefinition());
        foreach (var song in songs)
        {
            var songItem = new SongItem(); // Create a new instance of SongItem
            songItem.BindingContext = song; // Set the song as the binding context of the SongItem
            songItem.Margin = new Thickness(0, 5, 0, 5); // Set margin as needed

            // Add TapGestureRecognizer to handle tap event
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += SongItem_Tapped;
            songItem.GestureRecognizers.Add(tapGestureRecognizer);

            // Set the row and column of the SongItem in the grid
            Grid.SetRow(songItem, rowIndex);
            Grid.SetColumn(songItem, columnIndex);
            // Add the SongItem to the grid
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
        // open ArtistSongDashboard page with song details
        var songItem = (SongItem)sender;
        var songInfo = songItem.BindingContext as SongBasicInfo;
        Navigation.PushAsync(new UserSongDashboard(songInfo));
    }

    private List<SongBasicInfo> GetSongs()
    {
        // Creating a list of strings
        List<string> features = new List<string>();

        // Adding strings to the list
        features.Add("feature1");

        // mocked songs, to be replaced with actual data retrieval from db
        return new List<SongBasicInfo>
            {
                
                new SongBasicInfo { SongId = 0, Name = "Song 1", Artist = "Artist 1", Image = "song_img_default.png", Genre="genre", Subgenre="subgenre", Country="country", Language="language", Album="album", Features=features },
                new SongBasicInfo { SongId = 1, Name = "Song 2", Artist = "Artist 2", Image = "song_img_default.png", Genre="genre", Subgenre="subgenre", Country="country", Language="language", Album="album", Features=features },
                new SongBasicInfo { SongId = 2, Name = "Song 3", Artist = "Artist 3", Image = "song_img_default.png", Genre="genre", Subgenre="subgenre", Country="country", Language="language", Album="album", Features=features },
                new SongBasicInfo {SongId = 3, Name = "Song 4", Artist = "Artist 4", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features},
                new SongBasicInfo { SongId = 4, Name = "Song 5", Artist = "Artist 5", Image = "song_img_default.png", Genre="genre", Subgenre="subgenre", Country="country", Language="language", Album="album", Features=features },
                new SongBasicInfo {SongId = 5, Name = "Song 6", Artist = "Artist 6", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album", Features = features},
            };
    }

}

