using Dapper;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;

namespace TechTitans.Repositories
{
    internal class SongBasicDetailsRepository : Repository<SongBasicDetails>
    {
        public SongBasicInfo SongBasicDetailsToSongBasicInfo(SongBasicDetails songBasicDetails)
        {   
            var artistId = songBasicDetails.ArtistId;
            var cmd = new StringBuilder();
            cmd.Append("SELECT name FROM AuthorDetails WHERE artist_id = @artistId");
            var artistName = _connection.Query<string>(cmd.ToString(), new { artistId }).FirstOrDefault();
            return new SongBasicInfo
            {
                SongId = songBasicDetails.SongId,
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
        
        public SongBasicDetails GetSongBasicDetails(int songId)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM SongBasicDetails WHERE song_id = @songId");
            return _connection.Query<SongBasicDetails>(cmd.ToString(), new { songId }).FirstOrDefault();
        }

        public List<SongBasicDetails> GetTop5MostListenedSongs(int userId)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM SongBasicDetails WHERE song_id IN (SELECT TOP 5 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            return _connection.Query<SongBasicDetails>(cmd.ToString(), new { userId }).ToList();
        }

        public Tuple<SongBasicDetails, decimal> GetMostPlayedSongPercentile(int userId)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM SongBasicDetails WHERE song_id IN (SELECT TOP 1 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            var mostPlayedSong = _connection.Query<SongBasicDetails>(cmd.ToString(), new { userId }).FirstOrDefault();
            cmd.Clear();
            cmd.Append("SELECT COUNT(DISTINCT song_id) FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2;");
            var totalSongs = _connection.Query<int>(cmd.ToString(), new { userId }).FirstOrDefault();
            cmd.Clear();
            cmd.Append("SELECT COUNT(DISTINCT song_id) FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND song_id IN (SELECT TOP 1 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            var mostListenedSongCount = _connection.Query<int>(cmd.ToString(), new { userId }).FirstOrDefault();
            return new Tuple<SongBasicDetails, decimal>(mostPlayedSong, (decimal)mostListenedSongCount / totalSongs);
        }

        public Tuple<string, decimal> GetMostPlayedArtistPercentile(int userId)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT artist FROM SongBasicDetails WHERE song_id IN (SELECT TOP 1 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            var mostPlayedArtist = _connection.Query<string>(cmd.ToString(), new { userId }).FirstOrDefault();
            cmd.Clear();
            cmd.Append("SELECT COUNT(DISTINCT song_id) FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2;");
            var totalSongs = _connection.Query<int>(cmd.ToString(), new { userId }).FirstOrDefault();
            cmd.Clear();
            cmd.Append("SELECT COUNT(DISTINCT song_id) FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND song_id IN (SELECT TOP 1 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            var mostListenedSongCount = _connection.Query<int>(cmd.ToString(), new { userId }).FirstOrDefault();
            return new Tuple<string, decimal>(mostPlayedArtist, (decimal)mostListenedSongCount / totalSongs);
        }

        public List<string> GetTop5Genres(int userId)
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT genre FROM SongBasicDetails WHERE song_id IN (SELECT TOP 5 song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 GROUP BY song_id ORDER BY COUNT(song_id) DESC);");
            return _connection.Query<string>(cmd.ToString(), new { userId }).ToList();
        }

        public List<string> NewGenresDiscovered(int userId)
        {
            //new genres where first song was played for the first time in the current year
            //var cmd = new StringBuilder();
            //cmd.Append("SELECT genre FROM SongBasicDetails WHERE song_id IN (SELECT song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 1 AND YEAR(timestamp) = YEAR(GETDATE()) GROUP BY song_id HAVING COUNT(song_id) = 1);");

            //select all genres that have been played in current year but not in previous year
            var cmd = new StringBuilder();
            cmd.Append("SELECT genre FROM SongBasicDetails WHERE song_id IN (SELECT song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) GROUP BY song_id) AND genre NOT IN (SELECT genre FROM SongBasicDetails WHERE song_id IN (SELECT song_id FROM UserPlaybackBehaviour WHERE user_id = @userId AND event_type = 2 AND YEAR(timestamp) = YEAR(GETDATE()) - 1 GROUP BY song_id;");
            return _connection.Query<string>(cmd.ToString(), new { userId }).ToList();
        }
    }
}
