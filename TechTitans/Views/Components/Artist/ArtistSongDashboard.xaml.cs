using TechTitans.Models;
using TechTitans.ViewModels;
using TechTitans.Services;
namespace TechTitans.Views.Components.Artist;

public partial class ArtistSongDashboard : ContentPage
{
	public ArtistSongDashboardController service = new ();
	// alt domain song type cu mai multe detalii
	int songId;
	ArtistSongDashboardViewModel viewModel;
	public ArtistSongDashboard(SongBasicInfo song)
	{
		songId = song.SongId;
		InitializeComponent();
		populateViewModel(songId);
		LoadPage();
	}
	private void populateViewModel(int songID)
	{
		viewModel = new ArtistSongDashboardViewModel() {
			SongInfo = service.getSongInfo(songID),
			SongDetails = service.getSongDetails(songID),
			ArtistInfo = service.getArtistInfo(songID)
		};
	}
	private void LoadPage()
	{
		SongImage.Source = viewModel.SongInfo.Image;
		SongTitle.Text = viewModel.SongInfo.Name;
		SongArtist.Text = "by " + viewModel.ArtistInfo.Name;
		SongAlbum.Text = "from " + viewModel.SongInfo.Album;

		// set song info panel
        label1.Text = "Genre:";
        content1.Text = viewModel.SongInfo.Genre;
		label2.Text = "Subgenre:";
		content2.Text = viewModel.SongInfo.Subgenre;
		label3.Text = "Country:";
		content3.Text = viewModel.SongInfo.Country;
		label4.Text = "Language:";
		content4.Text = viewModel.SongInfo.Language;
    }

 //   private ArtistSongDashboardViewModel getMockedViewModel()
	//{
	//	var mockedModel = new ArtistSongDashboardViewModel()
	//	{
	//		SongInfo = new SongBasicInfo(),
	//		SongDetails = new SongRecommendationDetails(),
	//		ArtistInfo = new AuthorDetails(),
	//	};
	//	return mockedModel;
	//}

	private void OnInfoClick(object sender, EventArgs e)
	{
		InfoBoxView.Color = Color.FromArgb("#6E6E6E");
		PerformanceBoxView.Color = Color.FromArgb("#1E1E1E");

        label1.Text = "Genre:";
        content1.Text = viewModel.SongInfo.Genre;
        label2.Text = "Subgenre:";
        content2.Text = viewModel.SongInfo.Subgenre;
        label3.Text = "Country:";
        content3.Text = viewModel.SongInfo.Country;
        label4.Text = "Language:";
        content4.Text = viewModel.SongInfo.Language;
    }

	private void OnPerformanceCLick(object sender, EventArgs e)
	{
        PerformanceBoxView.Color = Color.FromArgb("#6E6E6E");
        InfoBoxView.Color = Color.FromArgb("#1E1E1E");

		label1.Text = "Minutes Listened:";
		content1.Text = viewModel.SongDetails.Minutes_Listened.ToString();
		label2.Text = "Total Plays:";
		content2.Text = viewModel.SongDetails.Number_Of_Plays.ToString();
		label3.Text = "Likes:";
		content3.Text = viewModel.SongDetails.Likes.ToString();
		label4.Text = "Dislikes:";
		content4.Text = viewModel.SongDetails.Dislikes.ToString();
    }
}