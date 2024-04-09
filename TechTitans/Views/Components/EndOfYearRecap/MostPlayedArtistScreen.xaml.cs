namespace TechTitans.Views.Components.EndOfYearRecap;

public partial class MostPlayedArtistScreen : ContentView
{
	public MostPlayedArtistScreen()
	{
		InitializeComponent();
		AnotherCrazyAnimation();
	}

	public async void AnotherCrazyAnimation()
	{
		var t1 = RedHalfCircle1.RotateTo(36000, 200000, Easing.Linear);
        var t2 = RedHalfCircle2.RotateTo(-36000, 200000, Easing.Linear);
		await Task.WhenAll(t1, t2);
		AnotherCrazyAnimation();
    }
}