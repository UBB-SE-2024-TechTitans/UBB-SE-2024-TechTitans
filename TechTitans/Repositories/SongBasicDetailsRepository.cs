using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Dapper;
using TechTitans.Models;

namespace TechTitans.Repositories
{
    /// <summary>
    /// Represents a repository for managing song basic details,
    /// including operations for retrieving song information, top listened songs,
    /// and user playback behavior analysis.
    /// </summary>
    public class SongBasicDetailsRepository : Repository<SongDataBaseModel>
    {
        public SongBasicDetailsRepository(IDatabaseOperations databaseOperations) : base(databaseOperations)
        {
        }

        /// <summary>
        /// Converts song basic details to a simplified song information model.
        /// </summary>
        /// <param name="songBasicDetails">The song basic details to convert.</param>
        /// <returns>A simplified song information model.</returns>
        public SongBasicInformation TransformSongBasicDetailsToSongBasicInfo(SongDataBaseModel songBasicDetails)
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

        /// <summary>
        /// Retrieves the basic details of a song by its ID.
        /// </summary>
        /// <param name="songId">The ID of the song.</param>
        /// <returns>The song basic details.</returns>
        public SongDataBaseModel GetSongBasicDetails(int songId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT * FROM SongBasicDetails WHERE song_id = @songId");
            return DatabaseOperations.Query<SongDataBaseModel>(queryBuilder.ToString(), new { songId }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the top 5 most listened songs for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of the top 5 most listened songs.</returns>
        public List<SongDataBaseModel> GetTop5MostListenedSongs(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT * FROM SongBasicDetails WHERE song_id IN (SELECT TOP 5 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            return DatabaseOperations.Query<SongDataBaseModel>(queryBuilder.ToString(), new { userId }).ToList();
        }

        /// <summary>
        /// Retrieves the percentile of the most played song for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A tuple containing the most played song and its percentile.</returns>
        public Tuple<SongDataBaseModel, decimal> GetMostPlayedSongPercentile(int userId)
        {
            var mostPlayedSong = GetMostPlayedSong(userId);
            var totalSongs = GetTotalSongsPlayedByUser(userId);
            var mostListenedSongCount = GetMostListenedSongCount(userId);
            return new Tuple<SongDataBaseModel, decimal>(mostPlayedSong, (decimal)mostListenedSongCount / totalSongs);
        }

        /// <summary>
        /// Retrieves the most played song for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The most played song.</returns>
        private SongDataBaseModel GetMostPlayedSong(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT * FROM SongBasicDetails WHERE song_id IN (SELECT TOP 1 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            return DatabaseOperations.Query<SongDataBaseModel>(queryBuilder.ToString(), new { userId }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the total number of songs played by a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The total number of songs played.</returns>
        private int GetTotalSongsPlayedByUser(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT COUNT(*) FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE());");
            return DatabaseOperations.Query<int>(queryBuilder.ToString(), new { userId }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the count of the most listened song for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The count of the most listened song.</returns>
        private int GetMostListenedSongCount(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT COUNT(*) FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) AND song_id IN (SELECT TOP 1 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            return DatabaseOperations.Query<int>(queryBuilder.ToString(), new { userId }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the percentile of the most played artist for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Percentile of the most played artist.</returns>
        public Tuple<string, decimal> GetMostPlayedArtistPercentile(int userId)
        {
            var mostPlayedArtistInfo = GetMostPlayedArtistInfo(userId);
            var mostPlayedArtist = GetMostPlayedArtist(userId, mostPlayedArtistInfo);
            var totalSongs = GetTotalNumberOfSongs(userId);
            return new Tuple<string, decimal>(mostPlayedArtist, (decimal)mostPlayedArtistInfo.Start_Listen_Events / totalSongs);
        }

        /// <summary>
        /// Retrieves information about the most played artist for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Information about the most played artist.</returns>
        private MostPlayedArtistInformation GetMostPlayedArtistInfo(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT TOP 1 sd.artist_id as Artist_Id, COUNT(*) AS Start_Listen_Events FROM UserPlaybackBehaviour ub JOIN SongBasicDetails sd ON ub.song_id = sd.song_id WHERE ub.user_id = @userId AND ub.event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) GROUP BY sd.artist_id ORDER BY COUNT(*) DESC;");
            return DatabaseOperations.Query<MostPlayedArtistInformation>(queryBuilder.ToString(), new { userId }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the name of the most played artist for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="mostPlayedArtistInfo">Information about the most played artist.</param>
        /// <returns>The name of the most played artist.</returns>
        private string GetMostPlayedArtist(int userId, MostPlayedArtistInformation mostPlayedArtistInfo)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT name FROM AuthorDetails WHERE artist_id = @artist_Id");
            return DatabaseOperations.Query<string>(queryBuilder.ToString(), new { mostPlayedArtistInfo.Artist_Id }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the total number of songs for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The total number of songs.</returns>
        private int GetTotalNumberOfSongs(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT COUNT(*) FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE());");
            return DatabaseOperations.Query<int>(queryBuilder.ToString(), new { userId }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the top 5 genres for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of the top 5 genres.</returns>
        public List<string> GetTop5Genres(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT TOP 5 sb.genre FROM UserPlaybackBehaviour ub JOIN SongBasicDetails sb ON ub.song_id = sb.song_id WHERE ub.user_id = @userId AND ub.event_type = 2 AND YEAR(ub.timestamp) = YEAR(GETDATE()) GROUP BY sb.genre ORDER BY COUNT(*) DESC;");
            return DatabaseOperations.Query<string>(queryBuilder.ToString(), new { userId }).ToList();
        }

        /// <summary>
        /// Retrieves a list of distinct genres that have been played in the current year but not in the previous year for a specified user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom to retrieve the new genres.</param>
        /// <returns>A list of strings representing the new genres discovered by the user in the current year.</returns>
        public List<string> GetAllNewGenresDiscovered(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT DISTINCT genre FROM SongBasicDetails WHERE song_id IN (SELECT song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) GROUP BY song_id) AND genre NOT IN (SELECT genre FROM SongBasicDetails WHERE song_id IN (SELECT song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) - 1 GROUP BY song_id));");
            return DatabaseOperations.Query<string>(queryBuilder.ToString(), new { userId }).ToList();
        }
    }
}
