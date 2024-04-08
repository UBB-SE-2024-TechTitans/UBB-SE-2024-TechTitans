namespace TechTitans.Views.Components.EndOfYearRecap;

public partial class FirstScreen : ContentView
{
	public FirstScreen()
	{
		InitializeComponent();
		ChangeImageAndBackgraound();
	}

	private async void ChangeImageAndBackgraound()
	{
		await Task.Delay(3000);
        var imagesource = new FileImageSource
        {
            File = "first_screen_2.jpg"
        };
        GenericImage.Source = imagesource;
        Background.BackgroundColor = new Color(200, 20, 200);
        await Task.Delay(3000);
        imagesource = new FileImageSource
        {
            File = "first_screen_3.jpg"
        };
        GenericImage.Source = imagesource;
        Background.BackgroundColor = new Color(100, 200, 100);
        await Task.Delay(3000);
        imagesource = new FileImageSource
        {
            File = "first_screen_4.jpg"
        };
        GenericImage.Source = imagesource;
        Background.BackgroundColor = new Color(200, 200, 20);
        await Task.Delay(3000);
        imagesource = new FileImageSource
        {
            File = "first_screen_1.jpg"
        };
        GenericImage.Source = imagesource;
        Background.BackgroundColor = new Color(10, 20, 200);
        ChangeImageAndBackgraound();

    }
}