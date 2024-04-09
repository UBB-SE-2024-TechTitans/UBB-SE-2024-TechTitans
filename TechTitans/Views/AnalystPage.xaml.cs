using TechTitans.Services;

namespace TechTitans.Views;

public partial class AnalystPage : ContentPage
{
	public AnalystPage()
	{
		InitializeComponent();
		TopGenresController topGenresController = new TopGenresController();
		topGenresController.getTop3Genres(10, 2023);
	}
}