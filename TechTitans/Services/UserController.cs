using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TechTitans.Models;
using TechTitans.Repositories;
namespace TechTitans.Services
{
    /// <summary>
    /// Provides functionality for managing user-related data,
    /// including retrieving recently played songs.
    /// </summary>
    public class UserController
    {
        private readonly IUserSongRepository songRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="songRepository">The song repository.</param>
        public UserController(IUserSongRepository songRepository)
        {
            this.songRepository = songRepository;
        }

        /// <summary>
        /// Retrieves a list of the most recently played songs for the user.
        /// </summary>
        /// <returns>A list of <see cref="SongBasicInformation"/> objects
        /// representing the most recently played songs.</returns>
        public List<SongBasicInformation> GetRecentlyPlayed()
        {
            List<SongBasicInformation> groupOfSongsInformation = new List<SongBasicInformation>();
            foreach (SongDataBaseModel song in songRepository.GetAll())
            {
                SongBasicInformation song_info = songRepository.ConvertSongDataBaseModelToSongInfo(song);
                groupOfSongsInformation.Add(song_info);
            }
            return groupOfSongsInformation.Take(6).ToList();
        }
    }
}
