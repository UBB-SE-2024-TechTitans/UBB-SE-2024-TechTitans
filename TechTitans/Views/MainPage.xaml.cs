using TechTitans.Repositories;

namespace TechTitans.Views;

public partial class MainPage : ContentPage
{
    int count = 0;
    public TestRepository Repository { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Repository = new TestRepository();
/*        var dbData = Repository.TestMethod();
        TestId.Text = dbData.Id.ToString();
        TestName.Text = dbData.Name;*/

    }

    private void OnUserCLicked(object sender, EventArgs e) => Application.Current.MainPage = new NavigationPage(new UserPage());
    private void OnArtistClicked(object sender, EventArgs e) => Application.Current.MainPage = new NavigationPage(new ArtistPage());
    private void OnAnalystClicked(object sender, EventArgs e) => Application.Current.MainPage = new NavigationPage(new AnalystPage());
}


