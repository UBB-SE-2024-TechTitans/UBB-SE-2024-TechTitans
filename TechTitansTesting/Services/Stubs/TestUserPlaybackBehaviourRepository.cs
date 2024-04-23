using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;
using TechTitans.Repositories;
using TechTitans.Enums;

namespace TechTitansTesting.Services.Stubs
{
    internal class TestUserPlaybackBehaviourRepository : IUserPlaybackBehaviourRepository
    {
        public UserPlaybackBehaviour GetUserPlaybackBehaviour(int userId, int? songId = null, DateTime? timestamp = null)
        {
            return new UserPlaybackBehaviour()
            {
                User_Id = 1,
                Song_Id = 1,
                Timestamp = DateTime.Now
            };
        }

        public List<UserPlaybackBehaviour> GetListOfUserPlaybackBehaviourEntities(int userId)
        {
            if (userId == 3) {
                List<UserPlaybackBehaviour> userPlaybackBehaviourList = new List<UserPlaybackBehaviour>();
                for(int i = 0; i < 102; i++)
                {
                    UserPlaybackBehaviour userPlaybackBehaviour = new UserPlaybackBehaviour();
                    userPlaybackBehaviour.User_Id = 3;
                    userPlaybackBehaviour.Song_Id = i;
                    userPlaybackBehaviour.Event_Type = PlaybackEventType.StartSongPlayback;
                    userPlaybackBehaviour.Timestamp = DateTime.Now;
                    userPlaybackBehaviourList.Add(userPlaybackBehaviour);
                }
                return userPlaybackBehaviourList;
            }
            else
            {
                if (userId == 4) { 
                    List<UserPlaybackBehaviour> userPlaybackBehaviours = new List<UserPlaybackBehaviour>();

                    for (int i = 0; i < 12; i++)
                    {
                        UserPlaybackBehaviour userPlaybackBehaviour = new UserPlaybackBehaviour();
                        userPlaybackBehaviour.User_Id = 4;
                        userPlaybackBehaviour.Song_Id = i;
                        userPlaybackBehaviour.Event_Type = PlaybackEventType.StartSongPlayback;
                        userPlaybackBehaviour.Timestamp = DateTime.Now;
                        userPlaybackBehaviours.Add(userPlaybackBehaviour);
                    }
                    return userPlaybackBehaviours;
                }
                else
                {
                    return new List<UserPlaybackBehaviour>()
                    {
                        new UserPlaybackBehaviour()
                        {
                            User_Id = 1,
                            Song_Id = 1,
                            Timestamp = DateTime.Now
                        },
                        new UserPlaybackBehaviour()
                        {
                            User_Id = 1,
                            Song_Id = 2,
                            Timestamp = DateTime.Now
                        },
                        new UserPlaybackBehaviour()
                        {
                            User_Id = 1,
                            Song_Id = 3,
                            Timestamp = DateTime.Now
                        }
                    };
                }
            }
        }
    }
}
