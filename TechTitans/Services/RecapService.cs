using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Repositories;
using TechTitans.Models;
using Dapper;
using TechTitans.ViewModels;
using TechTitans.Enums;

namespace TechTitans.Services
{   
    internal class RecapService
    {
        SongBasicDetailsRepository songBasicDetailsRepository = new SongBasicDetailsRepository();
        UserPlaybackBehaviourRepository userPlaybackBehaviourRepository = new UserPlaybackBehaviourRepository();

        public List<SongBasicInfo> Top5MostListenedSongs(int userId)
        {
            var top5Songs = songBasicDetailsRepository.GetTop5MostListenedSongs(userId);
            List<SongBasicInfo> top5SongsInfo = new List<SongBasicInfo>();
            foreach (var song in top5Songs)
            {
                top5SongsInfo.Add(songBasicDetailsRepository.SongBasicDetailsToSongBasicInfo(song));
            }
            return top5SongsInfo;
        }

        public Tuple<SongBasicInfo, decimal> MostPlayedSongPercentile(int userId)
        {
            var mostPlayedSong = songBasicDetailsRepository.GetMostPlayedSongPercentile(userId);
            return new Tuple<SongBasicInfo, decimal>(songBasicDetailsRepository.SongBasicDetailsToSongBasicInfo(mostPlayedSong.Item1), mostPlayedSong.Item2);
        }

        public Tuple<string, decimal> MostPlayedArtistPercentile(int userId)
        {
            return songBasicDetailsRepository.GetMostPlayedArtistPercentile(userId);
        }

        public int MinutesListened(int userId)
        {
            //get list of all userplaybackbehaviour for a userid sorted ascending by timestamp and go over them calculating the difference between the timestamps and summing them up
            var userEvents = userPlaybackBehaviourRepository.GetUserPlaybackBehaviour(userId);
            int minutesListened = 0;
            //for every start and end event pair, calculate the difference in minutes and add it to the total
            for (int i = 0; i < userEvents.Count; i++)
            {
                if (userEvents[i].Event_Type == PlaybackEventType.start_play)
                {
                    for (int j = i + 1; j < userEvents.Count; j++)
                    {
                        if (userEvents[j].Event_Type == PlaybackEventType.end_play)
                        {
                            minutesListened += (int)(userEvents[j].Timestamp - userEvents[i].Timestamp).TotalMinutes;
                            i = j;
                            break;
                        }
                    }
                }
            }
            return minutesListened;
        }

        public List<string> Top5Genres(int userId)
        {
            return this.songBasicDetailsRepository.GetTop5Genres(userId);
        }

        public List<string> NewGenresDiscovered(int userId)
        {
            return this.songBasicDetailsRepository.NewGenresDiscovered(userId);
        }

        public ListenerPersonality ListenerPersonality(int userId)
        {
            var userEvents = userPlaybackBehaviourRepository.GetUserPlaybackBehaviour(userId);
            int playCount = 0;
            for(int i = 0; i < userEvents.Count; i++)
            {
                if ((userEvents[i].Event_Type == PlaybackEventType.start_play) && (userEvents[i].Timestamp.Year == DateTime.Now.Year))
                {
                    playCount++;
                }
            }
            if(playCount > 100)
            {
                return Enums.ListenerPersonality.Melophile;
            }
            var newGenres = NewGenresDiscovered(userId);
            if(newGenres.Count > 3)
            {
                return Enums.ListenerPersonality.Explorer;
            }
            if(playCount < 10)
            {
                return Enums.ListenerPersonality.Casual;
            }
            return Enums.ListenerPersonality.Vanilla;
        }

        public EndOfYearRecapViewModel GenerateEndOfYearRecap(int userId)
        {
            var recap = new EndOfYearRecapViewModel();
            recap.Top5MostListenedSongs = Top5MostListenedSongs(userId);
            recap.MostPlayedSongPercentile = MostPlayedSongPercentile(userId);
            recap.MostPlayedArtistPercentile = MostPlayedArtistPercentile(userId);
            recap.MinutesListened = MinutesListened(userId);
            recap.Top5Genres = Top5Genres(userId);
            recap.NewGenresDiscovered = NewGenresDiscovered(userId);
            recap.ListenerPersonality = ListenerPersonality(userId);
            return recap;
        }
    }
}
