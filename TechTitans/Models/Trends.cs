using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    [Table("Trends")]
    public class Trends
    {
        [Key]
        [Column("genre")]
        public string Genre { get; set; }

        [Key]
        [Column("language")]
        public string Language { get; set; }

        [Key]
        [Column("country")]
        public string Country { get; set; }

        [Key]
        [Column("song_id")]
        public int SongId { get; set; }
    }
}
