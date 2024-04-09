using TechTitans.Models;

namespace TechTitans.Views.Components;

public partial class SongItem : ContentView
{
    public SongBasicInfo mockSong = new()
    {
        SongId = 1,
        Name = "Roma",
        Genre = "Manele",
        Subgenre = "Trapanele",
        Artist = "BDLP",
        Features = new[] { "Ian" },
        Language = "Romanian",
        Country = "Romania",
        Album = "Single",
        Image = "song_img_default.png"
    };

    public SongItem()
	{
        if (BindingContext == null)
            BindingContext = mockSong; 

		InitializeComponent();
	}
}