namespace TechTitans.Models
{
    /// <summary>
    /// Represents the full details of a song, including total minutes listened,
    /// total plays, likes, dislikes, and skips.
    /// </summary>
    public class FullDetailsOnSong
    {
        public int TotalMinutesListened { get; set; }
        public int TotalPlays { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
        public int TotalSkips { get; set; }
        public FullDetailsOnSong()
        {
            TotalMinutesListened = 0;
            TotalPlays = 0;
            TotalLikes = 0;
            TotalDislikes = 0;
            TotalSkips = 0;
        }
    }
}