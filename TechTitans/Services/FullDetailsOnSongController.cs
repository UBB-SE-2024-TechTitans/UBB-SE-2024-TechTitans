using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TechTitans.Models;
using TechTitans.Repositories;
using TechTitans.Enums;
using Microsoft.Extensions.Configuration;

namespace TechTitans.Services
{
    /// <summary>
    /// Provides functionality for retrieving detailed information about songs,
    /// including playback behavior and ad distribution data.
    /// </summary>
    public class FullDetailsOnSongController
    {
        private readonly IRepository<UserPlaybackBehaviour> userPlaybackBehaviourRepo;
        private readonly IRepository<AdDistributionData> adDistributionDataRepo;

        public FullDetailsOnSongController(IRepository<UserPlaybackBehaviour> userPlaybackBehaviourRepo,
            IRepository<AdDistributionData> adDistributionDataRepo)
        {
            this.userPlaybackBehaviourRepo = userPlaybackBehaviourRepo;
            this.adDistributionDataRepo = adDistributionDataRepo;
        }

        /// <summary>
        /// Retrieves full details on a song, including total minutes listened,
        /// total plays, likes, dislikes, and skips.
        /// </summary>
        /// <param name="songId">The ID of the song.</param>
        /// <returns>A <see cref="FullDetailsOnSong"/> object containing the detailed
        /// information about the song, or null if the song is not found.</returns>
        public FullDetailsOnSong GetFullDetailsOnSong(int songId)
        {
            FullDetailsOnSong currentSongDetails = new ();
            DateTime start = new ();
            bool foundSongCheck = false;
            foreach (UserPlaybackBehaviour action in userPlaybackBehaviourRepo.GetAll())
            {
                if (action.Song_Id == songId)
                {
                    foundSongCheck = true;

                    switch (action.Event_Type)
                    {
                        case PlaybackEventType.StartSongPlayback:
                            start = action.Timestamp;
                            break;
                        case PlaybackEventType.EndSongPlayback:
                            int minutes = (action.Timestamp - start).Minutes;
                            currentSongDetails.TotalMinutesListened += minutes;
                            currentSongDetails.TotalPlays++;
                            break;
                        case PlaybackEventType.Like:
                            currentSongDetails.TotalLikes++;
                            break;
                        case PlaybackEventType.Dislike:
                            currentSongDetails.TotalDislikes++;
                            break;
                        case PlaybackEventType.Skip:
                            currentSongDetails.TotalSkips++;
                            break;
                    }
                }
            }
            if (!foundSongCheck)
            {
                return null;
            }
            return currentSongDetails;
        }

        /// <summary>
        /// Retrieves the details of a song for the current month,
        /// including total minutes listened, total plays, likes, dislikes,
        /// and skips.
        /// </summary>
        /// <param name="songId">The ID of the song.</param>
        /// <returns>A <see cref="FullDetailsOnSong"/> object containing the
        /// detailed information about the song for the current month.</returns>
        public FullDetailsOnSong GetCurrentMonthDetails(int songId)
        {
            FullDetailsOnSong currentSongDetails = new ();
            foreach (UserPlaybackBehaviour action in userPlaybackBehaviourRepo.GetAll())
            {
                if (action.Song_Id == songId && action.Timestamp.Month == DateTime.Now.Month && action.Timestamp.Year == DateTime.Now.Year)
                {
                    switch (action.Event_Type)
                    {
                        case PlaybackEventType.StartSongPlayback:
                            break;
                        case PlaybackEventType.EndSongPlayback:
                            int minutes = (action.Timestamp - DateTime.Now).Minutes;
                            currentSongDetails.TotalMinutesListened += minutes;
                            currentSongDetails.TotalPlays++;
                            break;
                        case PlaybackEventType.Like:
                            currentSongDetails.TotalLikes++;
                            break;
                        case PlaybackEventType.Dislike:
                            currentSongDetails.TotalDislikes++;
                            break;
                        case PlaybackEventType.Skip:
                            currentSongDetails.TotalSkips++;
                            break;
                    }
                }
            }
            return currentSongDetails;
        }

        /// <summary>
        /// Retrieves the active ad distribution data for a specific song.
        /// </summary>
        /// <param name="songId">The ID of the song.</param>
        /// <returns>An <see cref="AdDistributionData"/> object containing
        /// the active ad distribution data for the song, or null
        /// if no active ad is found.</returns>
        public AdDistributionData GetActiveAd(int songId)
        {
            foreach (AdDistributionData ad in adDistributionDataRepo.GetAll())
            {
                if (ad.Song_Id == songId && ad.Month == DateTime.Now.Month && ad.Year == DateTime.Now.Year)
                {
                    return ad;
                }
            }
            return null;
        }
    }
}
