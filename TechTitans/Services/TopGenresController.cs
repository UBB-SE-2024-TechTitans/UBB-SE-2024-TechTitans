using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TechTitans.Models;
using TechTitans.Repositories;
namespace TechTitans.Services
{
    /// <summary>
    /// Provides functionality for retrieving the top genres and subgenres based on song recommendations and playback details.
    /// </summary>
    public class TopGenresController
    {
        private static readonly IConfiguration Configuration = MauiProgram.Configuration;
        private static IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Configuration.GetConnectionString("TechTitansDev"));
        private static IDatabaseOperations databaseOperations = new DatabaseOperations(connection);
        private Repository<SongDataBaseModel> songRepo = new Repository<SongDataBaseModel>(databaseOperations);
        private Repository<SongRecommendationDetails> songRecommendationRepo = new Repository<SongRecommendationDetails>(databaseOperations);

        /// <summary>
        /// Retrieves the top 3 genres for a specified month and year,
        /// updating the provided labels with genre names, minutes listened,
        /// and percentages.
        /// </summary>
        public void GetTop3Genres(int month, int year, Label genre1, Label minutes1, Label percentage1, Label genre2, Label minutes2, Label percentage2, Label genre3, Label minutes3, Label percentage3)
        {
            int totalMinutes = 0;
            Dictionary<string, int> genreCount = new Dictionary<string, int>();
            foreach (SongDataBaseModel song in songRepo.GetAll())
            {
                foreach (SongRecommendationDetails songDetails in songRecommendationRepo.GetAll())
                {
                    if (songDetails.Song_Id == song.Song_Id && songDetails.Month == month && songDetails.Year == year)
                    {
                        totalMinutes += songDetails.Minutes_Listened;
                        if (genreCount.ContainsKey(song.Genre))
                        {
                            genreCount[song.Genre] += songDetails.Minutes_Listened;
                        }
                        else
                        {
                            genreCount.Add(song.Genre, songDetails.Minutes_Listened);
                        }
                    }
                }
            }

            var sortedGenres = from entry in genreCount orderby entry.Value descending select entry;
            int count = 0;
            foreach (KeyValuePair<string, int> entry in sortedGenres)
            {
                switch (count)
                {
                    case 0:
                        genre1.Text = entry.Key;
                        minutes1.Text = entry.Value.ToString();
                        percentage1.Text = ((entry.Value / totalMinutes) * 100).ToString();
                        break;
                    case 1:
                        genre2.Text = entry.Key;
                        minutes2.Text = entry.Value.ToString();
                        percentage2.Text = ((entry.Value / totalMinutes) * 100).ToString();
                        break;
                    case 2:
                        genre3.Text = entry.Key;
                        minutes3.Text = entry.Value.ToString();
                        percentage3.Text = ((entry.Value / totalMinutes) * 100).ToString();
                        break;
                }
                if (count == 2)
                {
                    break;
                }
                count++;
            }
        }

        /// <summary>
        /// Retrieves the top 3 subgenres for a specified month and year,
        /// updating the provided labels with subgenre names, minutes listened,
        /// and percentages.
        /// </summary>
        public void GetTop3SubGenres(int month, int year, Label genre1, Label minutes1, Label percentage1, Label genre2, Label minutes2, Label percentage2, Label genre3, Label minutes3, Label percentage3)
        {
               Dictionary<string, int> subgenreCount = new Dictionary<string, int>();
            int totalMinutes = 0;
            foreach (SongDataBaseModel song in songRepo.GetAll())
            {
                foreach (SongRecommendationDetails songDetails in songRecommendationRepo.GetAll())
                {
                    if (songDetails.Song_Id == song.Song_Id && songDetails.Month == month && songDetails.Year == year)
                    {
                        totalMinutes += songDetails.Minutes_Listened;
                        if (subgenreCount.ContainsKey(song.Subgenre))
                        {
                            subgenreCount[song.Subgenre] += songDetails.Minutes_Listened;
                        }
                        else
                        {
                            subgenreCount.Add(song.Subgenre, songDetails.Minutes_Listened);
                        }
                    }
                }
            }

            var sortedSubGenres = from entry in subgenreCount orderby entry.Value descending select entry;
            int count = 0;
            foreach (KeyValuePair<string, int> entry in sortedSubGenres)
            {
                switch (count)
                {
                    case 0:
                        genre1.Text = entry.Key;
                        minutes1.Text = entry.Value.ToString();
                        percentage1.Text = ((entry.Value / totalMinutes) * 100).ToString();
                        break;
                    case 1:
                        genre2.Text = entry.Key;
                        minutes2.Text = entry.Value.ToString();
                        percentage2.Text = ((entry.Value / totalMinutes) * 100).ToString();
                        break;
                    case 2:
                        genre3.Text = entry.Key;
                        minutes3.Text = entry.Value.ToString();
                        percentage3.Text = ((entry.Value / totalMinutes) * 100).ToString();
                        break;
                }
                if (count == 2)
                {
                    break;
                }
                count++;
                count++;
            }
        }
    }
}
