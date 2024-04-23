using System.ComponentModel;
using TechTitans.Enums;
using TechTitans.Models;

namespace TechTitans.ViewModels
{
    /// <summary>
    /// Represents the view model for the artist song dashboard,
    /// including song information, artist details, and song recommendation details.
    /// </summary>
    public class ArtistSongDashboardViewModel
    {
        public SongBasicInformation SongInfo { get; set; }
        public ArtistDetails ArtistInfo { get; set; }
        public SongRecommendationDetails SongDetails { get; set; }
    }
}
