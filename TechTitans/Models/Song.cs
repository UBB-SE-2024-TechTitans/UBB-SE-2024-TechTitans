using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//a general class implementation for the song entity
namespace TechTitans.Models
{
    public class Song
    {
        public string TitleName { get; set; } = String.Empty;

        public string ArtistName { get; set; } = String.Empty;

        public string ImageUrl { get; set; } = String.Empty;

        public int SongId { get; set; } = 0;
        public string Description { get; set; } = String.Empty;
        public string Subgenre { get; set; } = String.Empty;
        public List<string> Features { get; set; }= new List<string>();
        public string Language { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string Album { get; set; } = String.Empty;


    }

}
