using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    /// <summary>
    /// Represents basic details of a song stored in the database,
    /// including its ID, name, genre, subgenre, artist ID, language, country,
    /// album, and image.
    /// </summary>
    [Table("SongBasicDetails")]
    public class SongDataBaseModel
    {
        [Key]
        [Column("song_id")]
        public int Song_Id { get; set; } = 0;

        [Column("name")]
        public string Name { get; set; } = "DefaultName";

        [Column("genre")]
        public string Genre { get; set; } = "DefaultGenre";

        [Column("subgenre")]
        public string Subgenre { get; set; } = "DefaultSubgenre";

        [Column("artist_id")]
        public int Artist_Id { get; set; } = 0;

        [Column("language")]
        public string Language { get; set; } = "DefaultLanguage";

        [Column("country")]
        public string Country { get; set; } = "DefaultCountry";

        [Column("album")]
        public string Album { get; set; } = "DefaultAlbum";

        [Column("image")]
        public string Image { get; set; } = "song_img_default.png";
    }
}
