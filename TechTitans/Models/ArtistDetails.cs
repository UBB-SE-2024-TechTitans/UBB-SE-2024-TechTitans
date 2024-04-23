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
    /// Represents the details of an artist, including their unique identifier
    /// and name.
    /// </summary>
    [Table("AuthorDetails")]
    public class ArtistDetails
    {
        [Key]
        [Column("artist_id")]
        public int Artist_Id { get; set; } = 0;

        [Column("name")]
        public string Name { get; set; } = "DefaultName";
    }
}
