using TechTitans.Models;
using TechTitans.ViewModels;

namespace TechTitans.Views.Components.Artist;

public partial class ArtistSongDashboard : ContentPage
{
	// alt domain song type cu mai multe detalii
	SongBasicInfo song;
	ArtistSongDashboardViewModel viewModel;
	public ArtistSongDashboard(SongBasicInfo song)
	{
		// song = service.GetSongById(songId);
		this.song = song;
		InitializeComponent();
		populateViewModel();
		LoadPage();
	}
	private void populateViewModel()
	{
		// viewModel = getArtistSongDashboardModel(int sondId)
		viewModel = getMockedViewModel();

	}
	private void LoadPage()
	{
		SongImage.Source = viewModel.SongInfo.Image;
		SongTitle.Text = viewModel.SongInfo.Name;
		SongArtist.Text = "by " + viewModel.ArtistInfo.Name;
		SongAlbum.Text = "from " + viewModel.SongInfo.Album;
	}

	private ArtistSongDashboardViewModel getMockedViewModel()
	{
		var mockedModel = new ArtistSongDashboardViewModel()
		{
			SongInfo = new SongBasicInfo(),
			SongDetails = new SongBasicDetails(),
			ArtistInfo = new AuthorDetails(),
		};
		return mockedModel;
	}


}