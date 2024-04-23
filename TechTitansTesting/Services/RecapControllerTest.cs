using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitansTesting.Services.Stubs;
using Xunit;
using TechTitans.Services;
using TechTitans.Repositories;
using TechTitans.Models;
using TechTitans.Enums;

namespace TechTitansTesting.Services
{
    public class RecapControllerTest
    {

        [Fact]
        public void GetTheTop5MostListenedSongs_WhenUserHasSongs_ReturnsListOfSongs()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId = 1;

            var top5Songs = songBasicDetailsRepository.GetTop5MostListenedSongs(userId);

            Assert.NotNull(top5Songs);
            Assert.Equal(5, top5Songs.Count);
        }

        [Fact]
        public void GetTheMostPlayedSongPercentile_ReturnsTuple()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId = 1;

            var mostPlayedSongPercentile = songBasicDetailsRepository.GetMostPlayedSongPercentile(userId);

            Assert.NotNull(mostPlayedSongPercentile);
            Assert.IsType<Tuple<SongDataBaseModel, decimal>>(mostPlayedSongPercentile);
            Assert.Equal("Test", mostPlayedSongPercentile.Item1.Name);
        }

        [Fact]
        public void GetTheMostPlayedArtistPercentile_ReturnsTuple()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId = 1;

            var mostPlayedArtistPercentile = songBasicDetailsRepository.GetMostPlayedArtistPercentile(userId);

            Assert.NotNull(mostPlayedArtistPercentile);
            Assert.IsType<Tuple<string, decimal>>(mostPlayedArtistPercentile);
            Assert.Equal("Test", mostPlayedArtistPercentile.Item1);
        }

        [Fact]
        public void GetTotalMinutesListened_ReturnsInt()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId = 1;

            var totalMinutesListened = recapController.GetTotalMinutesListened(userId);

            Assert.NotNull(totalMinutesListened);
            Assert.IsType<int>(totalMinutesListened);
        }

        [Fact]
        public void GetTheTop5Genres_WhenUserHasGenres_ReturnsListOfGenres()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId = 1;

            var top5Genres = songBasicDetailsRepository.GetTop5Genres(userId);

            Assert.NotNull(top5Genres);
            Assert.Equal(5, top5Genres.Count);
            Assert.Equal("Test1", top5Genres[0]);
            Assert.Equal("Test2", top5Genres[1]);
        }

        [Fact]
        public void GetTheNewGenresDiscovered_WhenUserHasNewGenres_ReturnsListOfGenres()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId = 1;

            var newGenres = songBasicDetailsRepository.GetAllNewGenresDiscovered(userId);

            Assert.NotNull(newGenres);
            Assert.Equal(5, newGenres.Count);
            Assert.Equal("Test1", newGenres[0]);
        }

        [Fact]
        public void GetListenerPersonality_WhenUserHasPlaybackBehaviour_ReturnsListenerPersonality()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId1 = 1;
            int userId2 = 2;
            int userId3 = 3;
            int userId4 = 4;

            var listenerPersonality1 = recapController.GetListenerPersonality(userId1);
            var listenerPersonality2 = recapController.GetListenerPersonality(userId2);
            var listenerPersonality3 = recapController.GetListenerPersonality(userId3);
            var listenerPersonality4 = recapController.GetListenerPersonality(userId4);

            Assert.NotNull(listenerPersonality1);
            Assert.IsType<ListenerPersonality>(listenerPersonality1);
            Assert.Equal(ListenerPersonality.Explorer, listenerPersonality1);

            Assert.NotNull(listenerPersonality2);
            Assert.IsType<ListenerPersonality>(listenerPersonality2);
            Assert.Equal(ListenerPersonality.Casual, listenerPersonality2);

            Assert.NotNull(listenerPersonality3);
            Assert.IsType<ListenerPersonality>(listenerPersonality3);
            Assert.Equal(ListenerPersonality.Melophile, listenerPersonality3);

            Assert.NotNull(listenerPersonality4);
            Assert.IsType<ListenerPersonality>(listenerPersonality4);
            Assert.Equal(ListenerPersonality.Vanilla, listenerPersonality4);
        }

        [Fact]
        public void GenerateEndOfTheYearRecap_WhenUserHasPlaybackBehaviour_ReturnsRecap()
        {
            var songBasicDetailsRepository = new TestSongBasicDetailsRepository();
            var userPlaybackBehaviourRepository = new TestUserPlaybackBehaviourRepository();
            var recapController = new RecapController(songBasicDetailsRepository, userPlaybackBehaviourRepository);
            int userId = 1;

            var recap = recapController.GenerateEndOfYearRecap(userId);

            Assert.NotNull(recap);
            Assert.Equal(5, recap.Top5Genres.Count);
            Assert.Equal("Test", recap.MostPlayedSongPercentile.Item1.Name);
            Assert.Equal("Test1", recap.NewGenresDiscovered[0]);
            Assert.Equal(ListenerPersonality.Explorer, recap.ListenerPersonality);
        }
    }
}
