using TechTitans.Models;
using TechTitans.Repositories;

namespace TechTitans.Views;

public partial class MainPage : ContentPage
{
    int count = 0;
    public TestRepository Repository { get; set; }
    public TestDemographicDetails RepositoryDemographic { get; set; }
    public TestAuthorDetails RepositoryAuthorDetails { get; set; }
    public TestSongBasicDetails RepositorySongBasicDetails { get; set; }
    public TestTrends RepositoryTestTrends { get; set; }
    public TestUserPlaybackBehaviour RepositoryUserPlaybackBehaviour { get; set; }
    public TestAdDistributionData RepositoryAdDistributionData { get; set; }
    public TestSongRecommendationDetails RepositorySongRecommendationDetails { get; set; }
    public TestSongFeatures RepositorySongFeatures { get; set; }
    // public TestRepositoryDemographic Repository { get; set; }

    public MainPage()
    {
        InitializeComponent();
        //Repository = new TestRepository();
        //var dbData = Repository.TestMethod();
        //TestId.Text = dbData.Id.ToString();
        //TestName.Text = dbData.Name;

        // RepositoryDemographic = new TestDemographicDetails();
        // var dbDataDemographic = RepositoryDemographic.TestMethod();
        // TestId.Text = dbDataDemographic.UserId.ToString();
        // TestName.Text = dbDataDemographic.Name;

        //RepositoryAuthorDetails = new TestAuthorDetails();
        //var dbDataAuthorDetails = RepositoryAuthorDetails.TestMethod();

        // RepositorySongBasicDetails = new TestSongBasicDetails();
        // var dbDataSongBasicDetails = RepositorySongBasicDetails.TestMethod();
        // TestId.Text = dbDataSongBasicDetails.SongId.ToString();
        // TestName.Text = dbDataSongBasicDetails.Name;

        // RepositoryTestTrends = new TestTrends();
        // var dbDataTestTrends = RepositoryTestTrends.TestMethod();
        // TestId.Text = dbDataTestTrends.SongId.ToString();
        // TestName.Text = dbDataTestTrends.Genre;

        // RepositoryAdDistributionData = new TestAdDistributionData();
        // var dbDataAdDistributionData = RepositoryAdDistributionData.TestMethod();
        // TestId.Text = dbDataAdDistributionData.SongId.ToString();
        // TestName.Text = dbDataAdDistributionData.AdCampaign.ToString();

        // RepositoryUserPlaybackBehaviour = new TestUserPlaybackBehaviour();
        // var dbDataUserPlaybackBehaviour = RepositoryUserPlaybackBehaviour.TestMethod();
        // TestId.Text = dbDataUserPlaybackBehaviour.UserId.ToString();
        // TestName.Text = dbDataUserPlaybackBehaviour.EventType.ToString();

        // RepositorySongRecommendationDetails = new TestSongRecommendationDetails();
        // var dbDataSongRecommendationDetails = RepositorySongRecommendationDetails.TestMethod();
        // TestId.Text = dbDataSongRecommendationDetails.SongId.ToString();
        // TestName.Text = dbDataSongRecommendationDetails.Likes.ToString();

        // RepositorySongFeatures = new TestSongFeatures();
        // var dbDataSongFeatures = RepositorySongFeatures.TestMethod();
        // TestId.Text = dbDataSongFeatures.SongId.ToString();
        // TestName.Text = dbDataSongFeatures.ArtistId.ToString();


    }

    private void OnUserCLicked(object sender, EventArgs e) => Navigation.PushAsync(new UserPage());
    private void OnArtistClicked(object sender, EventArgs e) => Navigation.PushAsync(new ArtistPage());
    private void OnAnalystClicked(object sender, EventArgs e) => Navigation.PushAsync(new AnalystPage());
    private void OnEndOfYearRecapClicked(object sender, EventArgs e) => Navigation.PushAsync(new EndOfYearRecap());
}