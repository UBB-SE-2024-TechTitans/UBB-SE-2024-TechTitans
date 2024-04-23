using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;
using TechTitans.Repositories;

namespace TechTitansTesting.Services.Stubs
{
    public class TestUserSongRepository : IUserSongRepository
    {
        private List<SongDataBaseModel> _songs;
        private SongBasicInformation _songInfo;
        private SongDataBaseModel _testSong;

        public void Setup(List<SongDataBaseModel> songs, SongBasicInformation songInfo, SongDataBaseModel testSong)
        {
            _songs = songs;
            _songInfo = songInfo;
            _testSong = testSong;
        }

        public List<SongDataBaseModel> GetAll()
        {
            return _songs;
        }

        public SongBasicInformation ConvertSongDataBaseModelToSongInfo(SongDataBaseModel song)
        {
            // Assuming this method is supposed to return _songInfo for any input
            // Adjust this logic based on your actual implementation
            return _songInfo;
        }

        public SongDataBaseModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<SongDataBaseModel> IRepository<SongDataBaseModel>.GetAll()
        {
           return _songs;
        }

        public bool Add(SongDataBaseModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SongDataBaseModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SongDataBaseModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
