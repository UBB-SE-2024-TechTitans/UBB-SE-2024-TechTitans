using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    [Table("SongRecommendationDetails")]
    public class SongRecommendationDetails
    {
        [Key]
        [Column("song_id")]
        public int SongId { get; set; }

        [Column("likes")]
        public int Likes { get; set; }

        [Column("dislikes")]
        public int Dislikes { get; set; }

        [Column("minutes_listened")]
        public int MinutesListened { get; set; }

        [Column("number_of_plays")]
        public int NumberOfPlays { get; set; }

        [Key]
        [Column("month")]
        public int Month { get; set; }

        [Key]
        [Column("year")]
        public int Year { get; set; }
    }
}
