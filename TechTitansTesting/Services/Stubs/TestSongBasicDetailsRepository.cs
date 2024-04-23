using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;
using TechTitans.Repositories;

namespace TechTitansTesting.Services.Stubs
{
    internal class TestSongBasicDetailsRepository : ISongBasicDetailsRepository
    {
        public bool Add(SongDataBaseModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SongDataBaseModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SongDataBaseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllNewGenresDiscovered(int userId)
        {
            if (userId == 1)
            {
                return new List<string>()
                {
                    "Test1",
                    "Test2",
                    "Test3",
                    "Test4",
                    "Test5"
                };
            }
            else
            {
                return new List<string>();
            }
        }

        public SongDataBaseModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Tuple<string, decimal> GetMostPlayedArtistPercentile(int userId)
        {
            return new Tuple<string, decimal>("Test", 10);
        }

        public SongDataBaseModel GetMostPlayedSong(int userId)
        {
            throw new NotImplementedException();
        }

        public Tuple<SongDataBaseModel, decimal> GetMostPlayedSongPercentile(int userId)
        {
            return new Tuple<SongDataBaseModel, decimal>(
                new SongDataBaseModel()
                {
                    Name = "Test"
                }, 10);
        }

        public SongDataBaseModel GetSongBasicDetails(int songId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTop5Genres(int userId)
        {
            return new List<string>()
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4",
                "Test5"
            };
        }

        public List<SongDataBaseModel> GetTop5MostListenedSongs(int userId)
        {
            return new List<SongDataBaseModel>()
            {
                new SongDataBaseModel(),
                new SongDataBaseModel(),
                new SongDataBaseModel(),
                new SongDataBaseModel(),
                new SongDataBaseModel()               
            };
        }

        public SongBasicInformation TransformSongBasicDetailsToSongBasicInfo(SongDataBaseModel song)
        {
            return new SongBasicInformation()
            {
                Name = song.Name
            };
        }

        public bool Update(SongDataBaseModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
