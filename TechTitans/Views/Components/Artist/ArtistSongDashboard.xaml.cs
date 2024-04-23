using System.Data;
using TechTitans.Models;
using TechTitans.ViewModels;
using TechTitans.Services;
using TechTitans.Repositories;
using Microsoft.Extensions.Configuration;
namespace TechTitans.Views.Components.Artist;

public partial class ArtistSongDashboard : ContentPage
{
    private static readonly IConfiguration Configuration = MauiProgram.Configuration;
    private static IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("TechTitansDev"));
    private static IDatabaseOperations databaseOperations = new DatabaseOperations(connection);
    public ArtistSongDashboardController Service = new ArtistSongDashboardController(new Repository<SongDataBaseModel>(databaseOperations), new Repository<SongFeatures>(databaseOperations), new Repository<SongRecommendationDetails>(databaseOperations), new Repository<ArtistDetails>(databaseOperations));
    // alt domain song type cu mai multe detalii
    public int SongId;
    public ArtistSongDashboardViewModel ViewModel;
	public ArtistSongDashboard(SongBasicInformation song)
	{
		SongId = song.SongId;
		InitializeComponent();
		PopulateViewModel(SongId);
		LoadPage();
	}
	private void PopulateViewModel(int songID)
	{
		ViewModel = new ArtistSongDashboardViewModel()
		{
			SongInfo = Service.GetSongInformation(songID),
			SongDetails = Service.GetSongRecommandationDetails(songID),
			ArtistInfo = Service.GetArtistInfoBySong(songID)
		};
	}
	private void LoadPage()
	{
		SongImage.Source = ViewModel.SongInfo.Image;
		SongTitle.Text = ViewModel.SongInfo.Name;
		SongArtist.Text = "by " + ViewModel.ArtistInfo.Name;
		SongAlbum.Text = "from " + ViewModel.SongInfo.Album;

		// set song info panel
        label1.Text = "Genre:";
        content1.Text = ViewModel.SongInfo.Genre;
		label2.Text = "Subgenre:";
		content2.Text = ViewModel.SongInfo.Subgenre;
		label3.Text = "Country:";
		content3.Text = ViewModel.SongInfo.Country;
		label4.Text = "Language:";
		content4.Text = ViewModel.SongInfo.Language;
    }

	// private ArtistSongDashboardViewModel getMockedViewModel()
	// {
	// var mockedModel = new ArtistSongDashboardViewModel()
	// {
	// SongInfo = new SongBasicInfo(),
	// SongDetails = new SongRecommendationDetails(),
	// ArtistInfo = new AuthorDetails(),
	// };
	// return mockedModel;
	// }
	private void OnInfoClick(object sender, EventArgs e)
	{
		InfoBoxView.Color = Color.FromArgb("#6E6E6E");
		PerformanceBoxView.Color = Color.FromArgb("#1E1E1E");

        label1.Text = "Genre:";
        content1.Text = ViewModel.SongInfo.Genre;
        label2.Text = "Subgenre:";
        content2.Text = ViewModel.SongInfo.Subgenre;
        label3.Text = "Country:";
        content3.Text = ViewModel.SongInfo.Country;
        label4.Text = "Language:";
        content4.Text = ViewModel.SongInfo.Language;
    }

	private void OnPerformanceCLick(object sender, EventArgs e)
	{
        PerformanceBoxView.Color = Color.FromArgb("#6E6E6E");
        InfoBoxView.Color = Color.FromArgb("#1E1E1E");

		label1.Text = "Minutes Listened:";
		content1.Text = ViewModel.SongDetails.Minutes_Listened.ToString();
		label2.Text = "Total Plays:";
		content2.Text = ViewModel.SongDetails.Number_Of_Plays.ToString();
		label3.Text = "Likes:";
		content3.Text = ViewModel.SongDetails.Likes.ToString();
		label4.Text = "Dislikes:";
		content4.Text = ViewModel.SongDetails.Dislikes.ToString();
    }
}