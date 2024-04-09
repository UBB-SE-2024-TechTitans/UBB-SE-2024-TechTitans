using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    [Table("AuthorDetails")]
    public class AuthorDetails
    {
        [Key]
        [Column("artist_id")]
        public int ArtistId { get; set; } = 0;

        [Column("name")]
        public string Name { get; set; } = "DefaultName";
    }
}
