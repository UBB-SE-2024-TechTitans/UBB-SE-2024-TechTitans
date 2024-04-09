using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    [Table ("SongBasicDetails")]
    public class SongBasicDetails
    {
        [Key]
        [Column("song_id")]
        public int Song_Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("genre")]
        public string Genre { get; set; }

        [Column("subgenre")]
        public string Subgenre { get; set; }

        [Column("artist_id")]
        public int Artist_Id { get; set; }

        [Column("language")]
        public string Language { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("album")]
        public string Album { get; set; }

        [Column("image")]
        public string Image { get; set; }
    }
}
