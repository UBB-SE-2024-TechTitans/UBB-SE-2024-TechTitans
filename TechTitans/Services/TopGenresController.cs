using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;
using TechTitans.Repositories;
namespace TechTitans.Services
{
    public class TopGenresController
    {
        private Repository<SongBasicDetails> SongRepo = new Repository<SongBasicDetails>();
        private Repository<SongRecommendationDetails> SongRecommendationRepo= new Repository<SongRecommendationDetails>();

        public void getTop3Genres(int month,int year,Label genre1,Label minutes1,Label percentage1 , Label genre2, Label minutes2,Label percentage2, Label genre3 ,Label minutes3, Label percentage3) {
            int totalMinutes = 0;
            Dictionary<String, int> genreCount = new Dictionary<String, int>();
            foreach (SongBasicDetails song in SongRepo.GetAll()) { 
                foreach (SongRecommendationDetails songDetails in SongRecommendationRepo.GetAll())
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

            var sortedDict = from entry in genreCount orderby entry.Value descending select entry;
            int count = 0;
            foreach (KeyValuePair<String, int> entry in sortedDict)
            {
                switch(count)
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
                if(count ==2)
                {
                    break;
                }
                count++;
            }
        }

        public void top3SubGenres(int month, int year, Label genre1, Label minutes1, Label percentage1, Label genre2, Label minutes2, Label percentage2, Label genre3, Label minutes3, Label percentage3) { 
               Dictionary<String, int> subgenreCount = new Dictionary<String, int>();
            int totalMinutes = 0;
            foreach (SongBasicDetails song in SongRepo.GetAll())
            {
                foreach (SongRecommendationDetails songDetails in SongRecommendationRepo.GetAll())
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

            var sortedDict = from entry in subgenreCount orderby entry.Value descending select entry;
            int count = 0;
            foreach (KeyValuePair<String, int> entry in sortedDict)
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
