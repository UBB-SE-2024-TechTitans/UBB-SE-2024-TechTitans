using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TechTitans.Repositories;
using TechTitans.Models;
using Dapper;

namespace TechTitans.Repositories
{
    /// <summary>
    /// Represents a repository for managing user song data,
    /// including operations for converting song database models
    /// to simplified song information.
    /// </summary>
    internal class UserSongRepository : Repository<SongDataBaseModel>, IUserSongRepository
    {
        public UserSongRepository(IDatabaseOperations databaseOperations) : base(databaseOperations)
        {
        }

        /// <summary>
        /// Converts a song database model to a simplified song information model,
        /// including retrieving the artist's name.
        /// </summary>
        /// <param name="songBasicDetails">The song database model to convert.</param>
        /// <returns>A simplified song information model with
        /// the artist's name included.</returns>
        public SongBasicInformation ConvertSongDataBaseModelToSongInfo(SongDataBaseModel songBasicDetails)
            {
                var artistId = songBasicDetails.Artist_Id;
                var queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT name FROM AuthorDetails WHERE artist_id = @artistId");
                var artistName = DatabaseOperations.Query<string>(queryBuilder.ToString(), new { artistId }).FirstOrDefault();
                return new SongBasicInformation
                {
                    SongId = songBasicDetails.Song_Id,
                    Name = songBasicDetails.Name,
                    Genre = songBasicDetails.Genre,
                    Subgenre = songBasicDetails.Subgenre,
                    Artist = artistName,
                    Language = songBasicDetails.Language,
                    Country = songBasicDetails.Country,
                    Album = songBasicDetails.Album,
                    Image = songBasicDetails.Image
                };
            }
        }
    }

