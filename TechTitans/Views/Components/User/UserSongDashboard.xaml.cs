using TechTitans.Models;
using TechTitans.ViewModels;
namespace TechTitans.Views.Components.User
{
    public partial class UserSongDashboard : ContentPage 
    {
        // alt domain song type cu mai multe detalii
        int songId;
        ArtistSongDashboardViewModel viewModel;
        public UserSongDashboard(SongBasicInfo song)
        {
            // song = service.GetSongById(songId);
            songId = song.SongId;
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

        private SongBasicInfo getMockedSong()
        {
            return new SongBasicInfo();
        }

        private ArtistSongDashboardViewModel getMockedViewModel()
        {
            var mockedModel = new ArtistSongDashboardViewModel()
            {
                SongInfo = new SongBasicInfo(),
                SongDetails = new SongRecommendationDetails(),
                ArtistInfo = new AuthorDetails(),
            };
            return mockedModel;
        }
        private void OnInfoClick(object sender, EventArgs e)
        {
            InfoBoxView.Color = Color.FromArgb("#6E6E6E");
            label1.Text = "Genre:";
            content1.Text = viewModel.SongInfo.Genre;
            label2.Text = "Subgenre:";
            content2.Text = viewModel.SongInfo.Subgenre;
            label3.Text = "Country:";
            content3.Text = viewModel.SongInfo.Country;
            label4.Text = "Language:";
            content4.Text = viewModel.SongInfo.Language;
        }
    }
}
