namespace TechTitans.Views.Components.EndOfYearRecap;

public partial class MinutesListenedScreen : ContentView
{
	public MinutesListenedScreen()
	{
		InitializeComponent();
		CrazyFuckingAnimation();
	}

	public async void CrazyFuckingAnimation()
	{
		await RedHalfCircle.ScaleTo(0, 1000, Easing.CubicIn);
		await BlueHalfCircle.ScaleTo(1, 1000, Easing.CubicIn);
        await BlueHalfCircle.ScaleTo(0, 1000, Easing.CubicIn);
        await RedHalfCircle.ScaleTo(1, 1000, Easing.CubicIn);
		CrazyFuckingAnimation();
    }
}