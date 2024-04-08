using Microsoft.VisualStudio.PlatformUI;
using System.Collections.ObjectModel;
using TechTitans.Models;

namespace TechTitans.Views
{

    public partial class UserPage : ContentPage
    {

        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song> { };
        public UserPage()
        {
            InitializeComponent();
            // Set the BindingContext
            BindingContext = this;
            PopulateSongs();

        }
        private void PopulateSongs()
        {
            //here we should make multiple functions that regarding what you select on filter or write in the search bar
            //populates the list with the first n songs (decision for later in beckend)
            // Create Song instances 
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
        
    }
}
