using Microsoft.VisualStudio.PlatformUI;
using System.Collections.ObjectModel;
using TechTitans.Models;

namespace TechTitans.Views
{

    public partial class UserPage : ContentPage
    {

        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song> { };
        public ObservableCollection<Playlist> Playlists { get; set; } = new ObservableCollection<Playlist> { };
        public UserPage()
        {
            InitializeComponent();
            // Set the BindingContext
            BindingContext = this;
            PopulateSongs();
            PopulatePlaylis();

        }
        private void PopulateSongs()
        {
            //here we should make multiple functions that regarding what you select on filter or write in the search bar
            //populates the list with the first n songs (decision for later in beckend)
            // Create Song instances 
            //for now we use Song class only for frontend dev
            Song song1 = new()
            {
                TitleName = "Song 1",
                ArtistName = "Artist 1",
                ImageUrl = "song_img_default.png" // Add image URL if needed
            };

            Song song2 = new()
            {
                TitleName = "Song 2",
                ArtistName = "Artist 2",
                ImageUrl = "song_img_default.png" // Add image URL if needed
            };

            // Add songs to the Songs collection
            Songs.Add(song1);
            Songs.Add(song2);
        }
        private void PopulatePlaylis()
        {
            //here is the same situation from the songs, most recently played playlist, etc
            Playlist playlist1 = new()
            {
                TitleName = "title 1",
                ImageUrl = "song_img_default.png"
            };
            Playlist playlist2 = new()
            {
                TitleName = "title 2",
                ImageUrl = "song_img_default.png"
            };
            Playlists.Add(playlist1);
            Playlists.Add(playlist2);
        }
        
    }
}
