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
    /// Represents the features of a song stored in the database, including its
    /// unique identifier and the artist's unique identifier.
    /// </summary>
    [Table("SongFeatures")]
    public class SongFeatures
    {
        [Key]
        [Column("song_id")]
        public int Song_Id { get; set; }
        [Key]
        [Column("artist_id")]
        public int Artist_Id { get; set; }

        public override string ToString()
        {
            return $"Artist ID: {Artist_Id}";
        }
    }
}
