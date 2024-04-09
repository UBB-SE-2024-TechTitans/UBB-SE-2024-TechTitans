using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;

namespace TechTitans.Repositories
{
    internal class UserPlaybackBehaviourRepository : Repository<UserPlaybackBehaviour>
    {
        public UserPlaybackBehaviour GetUserPlaybackBehaviour(int userId, int songId, DateTime timestamp)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM UserPlaybackBehaviour WHERE user_id = @userId AND song_id = @songId AND timestamp = @timestamp");
            return _connection.Query<UserPlaybackBehaviour>(cmd.ToString(), new { userId, songId, timestamp }).FirstOrDefault();
        }

        public List<UserPlaybackBehaviour> GetUserPlaybackBehaviour(int userId, int songId)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM UserPlaybackBehaviour WHERE user_id = @userId AND song_id = @songId");
            return _connection.Query<UserPlaybackBehaviour>(cmd.ToString(), new { userId, songId }).ToList();
        }

        public List<UserPlaybackBehaviour> GetUserPlaybackBehaviour(int userId)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT user_id as User_Id, song_id as Song_Id, event_type as EventType, timestamp as Timestamp FROM UserPlaybackBehaviour WHERE user_id = @userId");
            return _connection.Query<UserPlaybackBehaviour>(cmd.ToString(), new { userId }).ToList();
        }
    }
}
