using TechTitans.Models;
using TechTitans.Services;
// using System.IO;
namespace TechTitans.Views;

public partial class AnalystDashboard : ContentPage
{
	public AnalystDashboard()
	{
		InitializeComponent();
        FullDetailsOnSongController fullDetailsOnSongController = new FullDetailsOnSongController();
        FullDetailsOnSong fullDetails = fullDetailsOnSongController.GetFullDetailsOnSong(201);
        FullDetailsOnSong currentMonth = fullDetailsOnSongController.GetCurrentMonthDetails(201);
        this.BindingContext = currentMonth;
    }
}