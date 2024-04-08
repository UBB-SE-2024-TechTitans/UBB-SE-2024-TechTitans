using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;

namespace TechTitans.Repositories
{
    public class TestRepository : Repository<Test>
    {
        public Test TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM Test");
            return _connection.Query<Test>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestDemographicDetails : Repository<UserDemographicsDetails>
    {
        public UserDemographicsDetails TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM UserDemographicsDetails");
            return _connection.Query<UserDemographicsDetails>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestAuthorDetails : Repository<AuthorDetails>
    {
        public AuthorDetails TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM AuthorDetails");
            // return _connection.Query<Test>(cmd.ToString()).FirstOrDefault();
            return _connection.Query<AuthorDetails>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestAdDistributionData : Repository<AdDistributionData>
    {
        public AdDistributionData TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM AdDistributionData");
            return _connection.Query<AdDistributionData>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestSongBasicDetails : Repository<SongBasicDetails>
    {
        public SongBasicDetails TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM SongBasicDetails");
            return _connection.Query<SongBasicDetails>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestUserPlaybackBehaviour : Repository<UserPlaybackBehaviour>
    {
        public UserPlaybackBehaviour TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM UserPlaybackBehaviour");
            return _connection.Query<UserPlaybackBehaviour>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestSongRecommendationDetails : Repository<SongRecommendationDetails>
    {
        public SongRecommendationDetails TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM SongRecommendationDetails");
            return _connection.Query<SongRecommendationDetails>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestSongFeatures : Repository<SongFeatures>
    {
        public SongFeatures TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM SongFeatures");
            return _connection.Query<SongFeatures>(cmd.ToString()).FirstOrDefault();
        }
    }
    public class TestTrends : Repository<Trends>
    {
        public Trends TestMethod()
        {
            var cmd = new StringBuilder();
            cmd.Append("SELECT * FROM Trends");
            return _connection.Query<Trends>(cmd.ToString()).FirstOrDefault();
        }
    }
}
