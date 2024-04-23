using TechTitans.Models;
using TechTitans.ViewModels;
namespace TechTitans.Views.Components.User
{
    public partial class UserSongDashboard : ContentPage
    {
        // alt domain song type cu mai multe detalii
        public int SongId;
        public ArtistSongDashboardViewModel ViewModel;
        public UserSongDashboard(SongBasicInformation song)
        {
            // song = service.GetSongById(songId);
            SongId = song.SongId;
            InitializeComponent();
            PopulateViewModel();
            LoadPage();
        }

        private void PopulateViewModel()
        {
            // viewModel = getArtistSongDashboardModel(int sondId)
            ViewModel = GetMockedViewModel();
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

        private SongBasicInformation GetMockedSong()
        {
            return new SongBasicInformation();
        }

        private ArtistSongDashboardViewModel GetMockedViewModel()
        {
            var mockedModel = new ArtistSongDashboardViewModel()
            {
                SongInfo = new SongBasicInformation(),
                SongDetails = new SongRecommendationDetails(),
                ArtistInfo = new ArtistDetails(),
            };
            return mockedModel;
        }
        private void OnInfoClick(object sender, EventArgs e)
        {
            InfoBoxView.Color = Color.FromArgb("#6E6E6E");
            label1.Text = "Genre:";
            content1.Text = ViewModel.SongInfo.Genre;
            label2.Text = "Subgenre:";
            content2.Text = ViewModel.SongInfo.Subgenre;
            label3.Text = "Country:";
            content3.Text = ViewModel.SongInfo.Country;
            label4.Text = "Language:";
            content4.Text = ViewModel.SongInfo.Language;
        }
    }
}
