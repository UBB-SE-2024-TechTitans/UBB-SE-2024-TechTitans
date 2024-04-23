using TechTitans.Models;
using TechTitans.Services;
// using System.IO;
namespace TechTitans.Views;
using TechTitans.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;

public partial class AnalystDashboard : ContentPage
{
    private static readonly IConfiguration Configuration = MauiProgram.Configuration;
    private static IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("TechTitansDev"));
    private static IDatabaseOperations databaseOperations = new DatabaseOperations(connection);
    public FullDetailsOnSongController FullDetailsController = new FullDetailsOnSongController(new Repository<UserPlaybackBehaviour>(databaseOperations), new Repository<AdDistributionData>(databaseOperations));
    public AnalystDashboard()
	{
		InitializeComponent();
        FullDetailsOnSong fullDetails = FullDetailsController.GetFullDetailsOnSong(201);
        FullDetailsOnSong currentMonth = FullDetailsController.GetCurrentMonthDetails(201);
        this.BindingContext = currentMonth;
    }
}