using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    /// <summary>
    /// Represents information about the most played artist, including their
    /// unique identifier and the number of start listen events.
    /// </summary>
    public class MostPlayedArtistInformation
    {
        [Column("artist_id")]
        public int Artist_Id { get; set; }

        [Column("start_listen_events")]
        public int Start_Listen_Events { get; set; }
    }
}
