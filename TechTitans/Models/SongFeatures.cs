using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    [Table("SongFeatures")]
    public class SongFeatures
    {
        [Key]
        [Column("song_id")]
        public int SongId { get; set; }
        [Key]
        [Column("artist_id")]
        public int ArtistId { get; set; }
    }
}
