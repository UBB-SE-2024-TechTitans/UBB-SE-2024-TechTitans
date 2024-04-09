using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Models
{
    public enum PlaybackEventType
    {
        like = 1,
        start_play = 2,
        end_play = 3,
        dislike = 4,
        skip = 5
    }
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

