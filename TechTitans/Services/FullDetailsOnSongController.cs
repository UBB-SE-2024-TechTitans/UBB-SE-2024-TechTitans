using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using TechTitans.Models;
using TechTitans.Repositories;
using TechTitans.Enums;

namespace TechTitans.Services
{
    internal class FullDetailsOnSongController
    {
        //private readonly Repository<SongBasicDetails> SongRepo = new();
        //private readonly Repository<SongRecommendationDetails> SongRecommendationRepo = new();
        private readonly Repository<UserPlaybackBehaviour> UserPlaybackBehaviourRepo = new();
        private readonly Repository<AdDistributionData> AdDistributionDataRepo = new();
        public FullDetailsOnSong GetFullDetailsOnSong(int songId) {
            FullDetailsOnSong currentSongDetails = new();
            DateTime start = new(); 
            bool found = false;
            foreach (UserPlaybackBehaviour action in UserPlaybackBehaviourRepo.GetAll()) {

                if (action.Song_Id == songId) {
                    found = true;
                    // string message;
                    // message = action.Event_Type.ToString() + " " + action.Timestamp.ToString() + " " + action.Song_Id.ToString() + " " + action.User_Id.ToString() + "\n";
                    // MessageBox.Show(message);

                    switch (action.Event_Type) {
                        case PlaybackEventType.start_play:
                            start = action.Timestamp;
                            break;
                        case PlaybackEventType.end_play:
                            int minutes = (action.Timestamp - start).Minutes;
                            currentSongDetails.TotalMinutesListened += minutes;
                            currentSongDetails.TotalPlays++;
                            break;
                        case PlaybackEventType.like:
                            currentSongDetails.TotalLikes++;
                            break;
                        case PlaybackEventType.dislike:
                            currentSongDetails.TotalDislikes++;
                            break;
                        case PlaybackEventType.skip:
                            currentSongDetails.TotalSkips++;
                            break;
                        
                    }
                }
            }
            // MessageBox.Show(currentSongDetails.TotalMinutesListened.ToString());
            if (!found) {
                // MessageBox.Show("Song not found");
                return null;
            }
            return currentSongDetails;
        }
        public FullDetailsOnSong GetCurrentMonthDetails(int songId) {
            FullDetailsOnSong currentSongDetails = new();
            foreach (UserPlaybackBehaviour action in UserPlaybackBehaviourRepo.GetAll()) {
                if (action.Song_Id == songId && action.Timestamp.Month == DateTime.Now.Month && action.Timestamp.Year == DateTime.Now.Year) {
                    switch (action.Event_Type) {
                        case PlaybackEventType.start_play:
                            break;
                        case PlaybackEventType.end_play:
                            int minutes = (action.Timestamp - DateTime.Now).Minutes;
                            currentSongDetails.TotalMinutesListened += minutes;
                            currentSongDetails.TotalPlays++;
                            break;
                        case PlaybackEventType.like:
                            currentSongDetails.TotalLikes++;
                            break;
                        case PlaybackEventType.dislike:
                            currentSongDetails.TotalDislikes++;
                            break;
                        case PlaybackEventType.skip:
                            currentSongDetails.TotalSkips++;
                            break;
                    }
                }
            }
            return currentSongDetails;
        }
        public AdDistributionData GetActiveAd(int songId) {
            foreach (AdDistributionData ad in AdDistributionDataRepo.GetAll()) {
                if (ad.Song_Id == songId && ad.Month == DateTime.Now.Month && ad.Year == DateTime.Now.Year) {
                    return ad;
                }
            }
            return null;
        }
    }
}
