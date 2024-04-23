using System.ComponentModel;
using TechTitans.Enums;
using TechTitans.Models;

namespace TechTitans.ViewModels
{
    /// <summary>
    /// Represents the view model for the end-of-year recap,
    /// including top songs, artist percentiles, minutes listened, genres,
    /// and listener personality.
    /// </summary>
    public class EndOfYearRecapViewModel
    {
        public List<SongBasicInformation> Top5MostListenedSongs { get; set; }
        public Tuple<SongBasicInformation, decimal> MostPlayedSongPercentile { get; set; }
        public Tuple<string, decimal> MostPlayedArtistPercentile { get; set; }
        public int MinutesListened { get; set; }
        public List<string> Top5Genres { get; set; }
        public List<string> NewGenresDiscovered { get; set; }
        public ListenerPersonality ListenerPersonality { get; set; }
    }
}
