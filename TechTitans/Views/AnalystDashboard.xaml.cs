using TechTitans.Models;
using TechTitans.Services;
//using System.IO;
namespace TechTitans.Views;

public partial class AnalystDashboard : ContentPage
{
	public AnalystDashboard()
	{
		InitializeComponent();
        FullDetailsOnSongController fullDetailsOnSongController = new FullDetailsOnSongController();
        FullDetailsOnSong FullDetails = fullDetailsOnSongController.GetFullDetailsOnSong(201);
        FullDetailsOnSong CurrentMonth = fullDetailsOnSongController.GetCurrentMonthDetails(201);
        this.BindingContext = CurrentMonth;
    }
}