
namespace TechTitans.Models
{
    public class SongBasicInfo
    {
        public int SongId { get; set; } = 0;
        public string Name { get; set; } = "DefaultName";
        public string Genre { get; set; } = "DefaultGenre";
        public string Subgenre { get; set; } = "DefaultSubgenre";
        public string Artist { get; set; } = "DefaultArtist";
        public IList<string> Features { get; set; } = new List<string>();
        public string Language { get; set; } = "DefaultLanguage";
        public string Country { get; set; } = "DefaultCountry";
        public string Album { get; set; } = "DefaultAlbum";
        public string Image {  get; set; } = "song_img_default.png";
    }
}
