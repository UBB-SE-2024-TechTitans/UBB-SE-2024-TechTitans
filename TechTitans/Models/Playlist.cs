using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//a general class implementation for the album entity
namespace TechTitans.Models
{
    public class Playlist
    {
        public string TitleName { get; set; } = String.Empty;

        public string ArtistName { get; set; } = String.Empty;

        public string ImageUrl { get; set; }= String.Empty;
        public string Description { get; set; } = String.Empty;
    }

}
