

using System.ComponentModel;
using TechTitans.Enums;
using TechTitans.Models;

namespace TechTitans.ViewModels
{
    public class EndOfYearRecapViewModel
    {
        public List<SongBasicInfo> Top5MostListenedSongs { get; set; }
        public Tuple<SongBasicInfo,decimal> MostPlayedSongPercentile { get; set; }
        public Tuple<string, decimal> MostPlayedArtistPercentile { get; set; }
        public int MinutesListened {  get; set; }
        public List<string> Top5Genres { get; set; }
        public List<string> NewGenresDiscovered { get; set; }
        public ListenerPersonality ListenerPersonality { get; set; }
    }
}
