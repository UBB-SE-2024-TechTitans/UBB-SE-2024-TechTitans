using System.ComponentModel;
using TechTitans.Enums;
using TechTitans.Models;

namespace TechTitans.ViewModels
{
    class ArtistSongDashboardViewModel
    {
        public SongBasicInfo SongInfo { get; set; }
        public AuthorDetails ArtistInfo { get; set; }
        public SongBasicDetails SongDetails { get; set; }
    }
}
