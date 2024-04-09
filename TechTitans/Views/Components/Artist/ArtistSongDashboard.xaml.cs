using TechTitans.Models;

namespace TechTitans.Views.Components.Artist;

public partial class ArtistSongDashboard : ContentPage
{
	// alt domain song type cu mai multe detalii
	SongBasicInfo song;
	public ArtistSongDashboard(SongBasicInfo song)
	{
		// song = service.GetSongById(songId);
		this.song = song;
		InitializeComponent();
		LoadPage();
	}

	private void LoadPage()
	{
		SongImage.Source = song.Image;
		SongTitle.Text = song.Name;
		SongArtist.Text = song.Artist;
	}

	private SongBasicInfo getMockedSong()
	{
		return new SongBasicInfo();
	}
}