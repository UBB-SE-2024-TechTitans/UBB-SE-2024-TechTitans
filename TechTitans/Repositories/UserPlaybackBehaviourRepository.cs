using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using TechTitans.Models;
using Dapper;

[assembly: InternalsVisibleTo("TechTitansTesting")]

namespace TechTitans.Repositories
{
    /// <summary>
    /// Represents a repository for managing user playback behavior data,
    /// including operations for retrieving playback behavior records.
    /// </summary>
    internal class UserPlaybackBehaviourRepository : Repository<UserPlaybackBehaviour>, IUserPlaybackBehaviourRepository
    {
        public UserPlaybackBehaviourRepository(IDatabaseOperations databaseOperations) : base(databaseOperations)
        {
        }

        /// <summary>
        /// Retrieves a specific user's playback behavior record
        /// based on the provided criteria.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="songId">The optional ID of the song.</param>
        /// <param name="timestamp">The optional timestamp.</param>
        /// <returns>The user's playback behavior record matching
        /// the specified criteria, or null if no match is found.</returns>
        public UserPlaybackBehaviour GetUserPlaybackBehaviour(int userId, int? songId = null, DateTime? timestamp = null)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT * FROM UserPlaybackBehaviour WHERE user_id = @userId");
            if (songId.HasValue)
            {
                queryBuilder.Append(" AND song_id = @songId");
            }
            if (timestamp.HasValue)
            {
                queryBuilder.Append(" AND timestamp = @timestamp");
            }
            return DatabaseOperations.Query<UserPlaybackBehaviour>(queryBuilder.ToString(), new { userId, songId, timestamp }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves all playback behavior records for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of playback behavior records for the specified user.</returns>
        public List<UserPlaybackBehaviour> GetListOfUserPlaybackBehaviourEntities(int userId)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT user_id as User_Id, song_id as Song_Id, event_type as Event_Type, timestamp as Timestamp FROM UserPlaybackBehaviour WHERE user_id = @userId");
            return DatabaseOperations.Query<UserPlaybackBehaviour>(queryBuilder.ToString(), new { userId }).ToList();
        }
    }
}
