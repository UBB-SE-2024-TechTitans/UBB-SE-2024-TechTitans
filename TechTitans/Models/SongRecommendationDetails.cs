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
    /// Represents information about song recommendations stored in the database,
    /// including likes, dislikes, minutes listened, number of plays,
    /// and the time period.
    /// </summary>
    [Table("SongRecommendationDetails")]
    public class SongRecommendationDetails
    {
        [Key]
        [Column("song_id")]
        public int Song_Id { get; set; } = 0;

        [Column("likes")]
        public int Likes { get; set; } = 0;

        [Column("dislikes")]
        public int Dislikes { get; set; } = 0;

        [Column("minutes_listened")]
        public int Minutes_Listened { get; set; } = 0;

        [Column("number_of_plays")]
        public int Number_Of_Plays { get; set; } = 0;

        [Key]
        [Column("month")]
        public int Month { get; set; } = 0;

        [Key]
        [Column("year")]
        public int Year { get; set; } = 0;
    }
}
