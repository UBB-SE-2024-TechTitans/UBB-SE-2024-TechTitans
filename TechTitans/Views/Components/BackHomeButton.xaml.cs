namespace TechTitans.Views.Components;

public partial class BackHomeButton : ContentView
{
	public BackHomeButton()
	{
        InitializeComponent();
	}

    private void OnBackClick(object sender, EventArgs e) => Application.Current.MainPage = new NavigationPage(new MainPage());
}