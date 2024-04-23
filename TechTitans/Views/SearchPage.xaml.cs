using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Views.Components.User;
using TechTitans.Views.Components;
using TechTitans.Models;
using TechTitans.Models;

namespace TechTitans.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }
        private int rowIndex = 0;
        private int columnIndex = 0;
        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            // here we should search from our database with some function (in repo/service) but will do
            // a mock function just for frontend development puposes
            // Clear existing children from SongsGrid
            SongsGrid.Children.Clear();
            string song_to_find = ((SearchBar)sender).Text;
            var songs = new ObservableCollection<SongBasicInformation>(GetSongs(song_to_find));
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
                    SongsGrid.RowDefinitions.Add(new RowDefinition());
                    rowIndex++;
                }
            }
        }
        public ObservableCollection<SongBasicInformation> GetSongs(string song_to_find)
        {
            // here a more complexe function should be implemented with the sont_to_find parameter that returns only songs that match
            return new ObservableCollection<SongBasicInformation>
            {
                new SongBasicInformation { SongId = 0, Name = "Song 1", Artist = "Artist 1", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album" },
                new SongBasicInformation { SongId = 1, Name = "Song 2", Artist = "Artist 2", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album" },
                new SongBasicInformation { SongId = 2, Name = "Song 3", Artist = "Artist 3", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album" },
                new SongBasicInformation { SongId = 3, Name = "Song 4", Artist = "Artist 4", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album" },
                new SongBasicInformation { SongId = 4, Name = "Song 5", Artist = "Artist 5", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album" },
                new SongBasicInformation { SongId = 5, Name = "Song 6", Artist = "Artist 6", Image = "song_img_default.png", Genre = "genre", Subgenre = "subgenre", Country = "country", Language = "language", Album = "album" },
            };
        }
        private void SongItem_Tapped(object sender, System.EventArgs e)
        {
            // open ArtistSongDashboard page with song details
            var songItem = (SongItem)sender;
            var songInfo = songItem.BindingContext as SongBasicInformation;
            Navigation.PushAsync(new UserSongDashboard(songInfo));
        }
    }
}
