using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Enums;

namespace TechTitans.Models
{
    /// <summary>
    /// Represents detailed demographic information about a user stored in database,
    /// including their unique identifier, name, gender, date of birth,
    /// country, language, race, and whether they are a premium user.
    /// </summary>
    [Table("UserPlaybackBehaviour")]
    public class UserPlaybackBehaviour
    {
        [Key]
        [Column("user_id")]
        public int User_Id { get; set; }

        [Key]
        [Column("song_id")]
        public int Song_Id { get; set; }

        [Column("event_type")]
        public PlaybackEventType Event_Type { get; set; }

        [Key]
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}

