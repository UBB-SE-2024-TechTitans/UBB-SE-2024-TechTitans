using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    [Table("AdDistributionData")]
    public class AdDistributionData
    {
        [Key]
        [Column("song_id")]
        public int Song_Id { get; set; }

        [Key]
        [Column("ad_campaign")]
        public int Ad_Campaign { get; set; }

        [Column("genre")]
        public string Genre { get; set; }

        [Column("language")]
        public string Language { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("year")]
        public int Year { get; set; }
    }
}
