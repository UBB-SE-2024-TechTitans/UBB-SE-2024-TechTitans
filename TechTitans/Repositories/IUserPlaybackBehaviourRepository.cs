using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;

namespace TechTitans.Repositories
{
    internal interface IUserPlaybackBehaviourRepository
    {
        UserPlaybackBehaviour GetUserPlaybackBehaviour(int userId, int? songId = null, DateTime? timestamp = null);
        List<UserPlaybackBehaviour> GetListOfUserPlaybackBehaviourEntities(int userId);
    }
}
