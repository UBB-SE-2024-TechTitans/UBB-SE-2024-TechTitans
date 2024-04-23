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
    /// Represents demographic information stored in the database about a user,
    /// including their unique identifier, name, gender, date of birth, country,
    /// language, race, and whether they are a premium user.
    /// </summary>
    [Table("UserDemographicsDetails")]
    public class UserDemographicsDetails
    {
        [Key]
        [Column("user_id")]
        public int User_Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("gender")]
        public int Gender { get; set; }

        [Column("date_of_birth")]
        public DateTime Date_Of_fBirth { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("language")]
        public string Language { get; set; }

        [Column("race")]
        public string Race { get; set; }

        [Column("premium_user")]
        public bool Premium_User { get; set; }
    }
}
