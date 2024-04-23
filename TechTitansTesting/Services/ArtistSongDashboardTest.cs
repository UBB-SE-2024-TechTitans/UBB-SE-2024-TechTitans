﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;
using TechTitans.Repositories;
using TechTitans.Services;
using Moq;
using TechTitansTesting.Services.Stubs;
using Microsoft.Extensions.Hosting;

namespace TechTitansTesting.Services
{
    public class ArtistSongDashboardTest
    {
        [Fact]
        public void TransformSongDataBaseModelToSongInfo_TransformsCorrectly()
        {
            
            var song = new SongDataBaseModel
            {
                Song_Id = 1,
                Name = "Test Song",
                Genre = "Test Genre",
                Subgenre = "Test Subgenre",
                Artist_Id = 1,
                Language = "Test Language",
                Country = "Test Country",
                Album = "Test Album",
                Image = "test_image.png"
            };

            
            var artistDetailsData = new List<ArtistDetails>
            {
                new ArtistDetails { Artist_Id = 1, Name = "Test Artist" }
            };

            var songFeaturesDataTest = new List<SongFeatures>
            {
                new SongFeatures{ Song_Id = 1, Artist_Id = 2}
            };
           
            var songData = new List<SongDataBaseModel>
            {
                song 
            };

            
            var songRecommendationData = new List<SongRecommendationDetails>();
            var songRepositoryStub = new TestArtistSongDashboardRepository<SongDataBaseModel>(songData);
            var songRecommendationRepositoryStub = new TestArtistSongDashboardRepository<SongRecommendationDetails>(songRecommendationData);
            
            var artistRepositoryStub = new TestArtistSongDashboardRepository<ArtistDetails>(artistDetailsData);
            
            var songFeaturesData = new List<SongFeatures>(songFeaturesDataTest);

            var featureRepositoryStub = new TestArtistSongDashboardRepository<SongFeatures>(songFeaturesData);

            IEnumerable<ArtistDetails> x = artistRepositoryStub.GetAll();
            Console.WriteLine(x);

            var controller = new ArtistSongDashboardController(
            songRepositoryStub,
            featureRepositoryStub,
            songRecommendationRepositoryStub,
            artistRepositoryStub
            );

            
            SongBasicInformation result = controller.TransformSongDataBaseModelToSongInfo(song);

            
            Assert.Equal(song.Song_Id, result.SongId);
            Assert.Equal(song.Name, result.Name);
            Assert.Equal(song.Genre, result.Genre);
            Assert.Equal(song.Subgenre, result.Subgenre);
            Assert.Equal(song.Language, result.Language);
            Assert.Equal(song.Country, result.Country);
            Assert.Equal(song.Album, result.Album);
            Assert.Equal(song.Image, result.Image);
            Assert.Equal("Test Artist", result.Artist);
        }

        [Fact]
        public void GetAllArtistSongs_ReturnsCorrectSongs()
        {
            
            var artistId = 1;

            var songData = new List<SongDataBaseModel>
            {
                new SongDataBaseModel
                {
                    Song_Id = 1,
                    Name = "Test Song 1",
                    Genre = "Test Genre 1",
                    Subgenre = "Test Subgenre 1",
                    Artist_Id = artistId,
                    Language = "Test Language 1",
                    Country = "Test Country 1",
                    Album = "Test Album 1",
                    Image = "test_image1.png"
                },
                new SongDataBaseModel
                {
                    Song_Id = 2,
                    Name = "Test Song 2",
                    Genre = "Test Genre 2",
                    Subgenre = "Test Subgenre 2",
                    Artist_Id = artistId,
                    Language = "Test Language 2",
                    Country = "Test Country 2",
                    Album = "Test Album 2",
                    Image = "test_image2.png"
                }
            };

            var artistDetailsData = new List<ArtistDetails>
            {
                new ArtistDetails { Artist_Id = artistId, Name = "Test Artist" }
            };

            var songRepositoryMock = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryMock.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryMock = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryMock.Setup(repo => repo.GetAll()).Returns(artistDetailsData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var songRecommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryMock.Object,
                featureRepositoryStub,
                songRecommendationRepositoryStub,
                artistRepositoryMock.Object
            );

            var result = controller.GetAllArtistSongs(artistId);

            Assert.NotNull(result);
            Assert.Equal(songData.Count, result.Count);

            foreach (var song in result)
            {
                Assert.Equal("Test Artist", song.Artist);
            }
        }

        [Fact]
        public void SearchSongsByTitle_ReturnsMatchingSongs()
        {
            var titleToSearch = "Test";

            var songData = new List<SongDataBaseModel>
            {
                new SongDataBaseModel
                {
                    Song_Id = 1,
                    Name = "Test Song 1",
                    Genre = "Test Genre 1",
                    Subgenre = "Test Subgenre 1",
                    Artist_Id = 1,
                    Language = "Test Language 1",
                    Country = "Test Country 1",
                    Album = "Test Album 1",
                    Image = "test_image1.png"
                },
                new SongDataBaseModel
                {
                    Song_Id = 2,
                    Name = "Another Song",
                    Genre = "Test Genre 2",
                    Subgenre = "Test Subgenre 2",
                    Artist_Id = 2,
                    Language = "Test Language 2",
                    Country = "Test Country 2",
                    Album = "Test Album 2",
                    Image = "test_image2.png"
                }
            };

            var songRepositoryMock = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryMock.Setup(repo => repo.GetAll()).Returns(songData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var songRecommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;
            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryMock.Object,
                featureRepositoryStub,
                songRecommendationRepositoryStub,
                artistRepositoryStub
            );

            var result = controller.SearchSongsByTitle(titleToSearch);

            Assert.NotNull(result);
            Assert.Single(result); // Only one song should match the title
            Assert.Equal("Test Song 1", result[0].Name);
        }

        [Fact]
        public void GetSongInformation_ReturnsSongInfo_WhenSongExists()
        {
            // Arrange
            var songIdToSearch = 1;
            var expectedSong = new SongDataBaseModel
            {
                Song_Id = songIdToSearch,
                Name = "Test Song",
                Genre = "Test Genre",
                Subgenre = "Test Subgenre",
                Artist_Id = 1,
                Language = "Test Language",
                Country = "Test Country",
                Album = "Test Album",
                Image = "test_image.png"
            };

            var songRepositoryMock = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<SongDataBaseModel> { expectedSong });

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>().Object;
            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var songRecommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryMock.Object,
                featureRepositoryStub,
                songRecommendationRepositoryStub,
                artistRepositoryStub
            );

            // Act
            var result = controller.GetSongInformation(songIdToSearch);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedSong.Song_Id, result.SongId);
            Assert.Equal(expectedSong.Name, result.Name);
            Assert.Equal(expectedSong.Genre, result.Genre);
            Assert.Equal(expectedSong.Subgenre, result.Subgenre);
            Assert.Equal(expectedSong.Language, result.Language);
            Assert.Equal(expectedSong.Country, result.Country);
            Assert.Equal(expectedSong.Album, result.Album);
            Assert.Equal(expectedSong.Image, result.Image);
        }

        [Fact]
        public void GetSongInformation_ReturnsNull_WhenSongDoesNotExist()
        {
            // Arrange
            var songIdToSearch = 100; // Assuming ID that doesn't exist

            var songRepositoryMock = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<SongDataBaseModel>());

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>().Object;
            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var songRecommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryMock.Object,
                featureRepositoryStub,
                songRecommendationRepositoryStub,
                artistRepositoryStub
            );

            // Act
            var result = controller.GetSongInformation(songIdToSearch);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSongRecommandationDetails_ReturnsCorrectDetails()
        {
            var songIdToSearch = 1;

            var recommendationData = new List<SongRecommendationDetails>
            {
                new SongRecommendationDetails
                {
                    Song_Id = 1,
                    Likes = 100,
                    Dislikes = 10,
                    Minutes_Listened = 500,
                    Number_Of_Plays = 50,
                    Month = 4,
                    Year = 2024
                },
                new SongRecommendationDetails
                {
                    Song_Id = 2,
                    Likes = 50,
                    Dislikes = 5,
                    Minutes_Listened = 250,
                    Number_Of_Plays = 25,
                    Month = 4,
                    Year = 2024
                }
            };

            var recommendationRepositoryMock = new Mock<IRepository<SongRecommendationDetails>>();
            recommendationRepositoryMock.Setup(repo => repo.GetAll()).Returns(recommendationData);

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>().Object;
            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub,
                featureRepositoryStub,
                recommendationRepositoryMock.Object,
                artistRepositoryStub
            );


            var result = controller.GetSongRecommandationDetails(songIdToSearch);

       
            Assert.NotNull(result);
            Assert.Equal(100, result.Likes);
            Assert.Equal(10, result.Dislikes);
            Assert.Equal(500, result.Minutes_Listened);
            Assert.Equal(50, result.Number_Of_Plays);
            Assert.Equal(4, result.Month);
            Assert.Equal(2024, result.Year);
        }
        [Fact]
        public void GetSongInformation_ReturnsNull_WhenArtistNotFoundForSong()
        {
            // Arrange
            var songIdToSearch = 1;
            var expectedSong = new SongDataBaseModel
            {
                Song_Id = 2,
                Name = "Test Song",
                Genre = "Test Genre",
                Subgenre = "Test Subgenre",
                Artist_Id = 1,
                Language = "Test Language",
                Country = "Test Country",
                Album = "Test Album",
                Image = "test_image.png"
            };
            Assert.NotEqual(songIdToSearch, expectedSong.Song_Id);
            var songRepositoryMock = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryMock.Setup(repo => repo.GetAll()).Returns(new List<SongDataBaseModel> { expectedSong });

            // Empty artist data
            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(new List<ArtistDetails>());

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var songRecommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryMock.Object,
                featureRepositoryStub,
                songRecommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            // Act
            var result = controller.GetSongInformation(songIdToSearch);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSongRecommandationDetails_DefaultWhenSongIdNotFound()
        {
            var songIdToSearch = 3; 

            var recommendationData = new List<SongRecommendationDetails>
            {
                new SongRecommendationDetails
                {
                    Song_Id = 1,
                    Likes = 100,
                    Dislikes = 10,
                    Minutes_Listened = 500,
                    Number_Of_Plays = 50,
                    Month = 4,
                    Year = 2024
                },
                new SongRecommendationDetails
                {
                    Song_Id = 2,
                    Likes = 50,
                    Dislikes = 5,
                    Minutes_Listened = 250,
                    Number_Of_Plays = 25,
                    Month = 4,
                    Year = 2024
                }
            };

            var recommendationRepositoryMock = new Mock<IRepository<SongRecommendationDetails>>();
            recommendationRepositoryMock.Setup(repo => repo.GetAll()).Returns(recommendationData);

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>().Object;
            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub,
                featureRepositoryStub,
                recommendationRepositoryMock.Object,
                artistRepositoryStub
            );


            var result = controller.GetSongRecommandationDetails(songIdToSearch);

            Assert.NotNull(result); 
            Assert.Equal(0, result.Likes); 
            Assert.Equal(0, result.Dislikes); 
            Assert.Equal(0, result.Minutes_Listened); 
            Assert.Equal(0, result.Number_Of_Plays); 
            Assert.Equal(0, result.Month);
            Assert.Equal(0, result.Year); 
        }
        [Fact]
        public void GetArtistInfoBySong_ReturnsArtistDetails_WhenSongExists()
        {
            // Arrange
            var songIdToSearch = 1;
            var artistId = 1;
            var expectedArtistName = "Test Artist";

            // Mock song data
            var songData = new List<SongDataBaseModel>
            {
                new SongDataBaseModel { Song_Id = 1, Artist_Id = artistId }
            };

            // Mock artist data
            var artistData = new List<ArtistDetails>
            {
                new ArtistDetails { Artist_Id = artistId, Name = expectedArtistName }
            };

            // Mock repositories
            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            // Create the controller instance
            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            // Act
            var result = controller.GetArtistInfoBySong(songIdToSearch);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(artistId, result.Artist_Id);
            Assert.Equal(expectedArtistName, result.Name);
        }

        [Fact]
        public void GetArtistInfoBySong_ReturnsNull_WhenSongDoesNotExist()
        {
            // Arrange
            var songIdToSearch = 3;

            // Mock empty song data
            var songData = new List<SongDataBaseModel>();

            // Mock artist data
            var artistData = new List<ArtistDetails>
    {
        new ArtistDetails { Artist_Id = 1, Name = "Test Artist" }
    };

            // Mock repositories
            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            // Create the controller instance
            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            // Act
            var result = controller.GetArtistInfoBySong(songIdToSearch);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetArtistInfoBySong_ReturnsNull_WhenArtistNotFoundForSong()
        {
            // Arrange
            var songIdToSearch = 1;
            var artistId = 2; // Artist ID that doesn't exist in the artist data

            // Mock song data
            var songData = new List<SongDataBaseModel>
    {
        new SongDataBaseModel { Song_Id = 1, Artist_Id = artistId }
    };

            // Mock artist data with different artist ID
            var artistData = new List<ArtistDetails>
    {
        new ArtistDetails { Artist_Id = 3, Name = "Test Artist 3" }
    };

            // Mock repositories
            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            // Create the controller instance
            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            // Act
            var result = controller.GetArtistInfoBySong(songIdToSearch);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetArtistInfoBySong_ReturnsNull_WhenArtistNotFound()
        {
            // Arrange
            var songIdToSearch = 1;
            var artistId = 2; // Artist ID that doesn't exist in the artist data

            // Mock song data
            var songData = new List<SongDataBaseModel>
    {
        new SongDataBaseModel { Song_Id = 1, Artist_Id = artistId }
    };

            // Mock empty artist data
            var artistData = new List<ArtistDetails>();

            // Mock repositories
            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            // Create the controller instance
            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            // Act
            var result = controller.GetArtistInfoBySong(songIdToSearch);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetMostPublishedArtist_ReturnsArtistWithMostPublishedSongs()
        {
            var expectedArtistId = 1;
            var expectedArtistName = "Test Artist";
            var expectedSongCount = 3;

            var songData = new List<SongDataBaseModel>
    {
        new SongDataBaseModel { Artist_Id = expectedArtistId },
        new SongDataBaseModel { Artist_Id = expectedArtistId },
        new SongDataBaseModel { Artist_Id = expectedArtistId },
        new SongDataBaseModel { Artist_Id = 2 },
        new SongDataBaseModel { Artist_Id = 3 }
    };

            var artistData = new List<ArtistDetails>
    {
        new ArtistDetails { Artist_Id = expectedArtistId, Name = expectedArtistName },
        new ArtistDetails { Artist_Id = 2, Name = "Artist 2" },
        new ArtistDetails { Artist_Id = 3, Name = "Artist 3" }
    };

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            var result = controller.GetMostPublishedArtist();

            Assert.NotNull(result);
            Assert.Equal(expectedArtistId, result.Artist_Id);
            Assert.Equal(expectedArtistName, result.Name);
        }

        [Fact]
        public void GetMostPublishedArtist_ReturnsNull_WhenNoSongsPublished()
        {
            var songData = new List<SongDataBaseModel>();
            var artistData = new List<ArtistDetails>();

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            var result = controller.GetMostPublishedArtist();

            Assert.Null(result);
        }

        [Fact]
        public void GetMostPublishedArtist_ReturnsFirstArtistWithMostPublishedSongs_WhenMultipleArtistsHaveSameNumberOfPublishedSongs()
        {
            var expectedArtistId1 = 1;
            var expectedArtistName1 = "Test Artist 1";

            var expectedArtistId2 = 2;
            var expectedArtistName2 = "Test Artist 2";

            var songData = new List<SongDataBaseModel>
            {
                new SongDataBaseModel { Artist_Id = expectedArtistId1 },
                new SongDataBaseModel { Artist_Id = expectedArtistId1 },
                new SongDataBaseModel { Artist_Id = expectedArtistId2 },
                new SongDataBaseModel { Artist_Id = expectedArtistId2 }
            };

                    var artistData = new List<ArtistDetails>
            {
                new ArtistDetails { Artist_Id = expectedArtistId1, Name = expectedArtistName1 },
                new ArtistDetails { Artist_Id = expectedArtistId2, Name = expectedArtistName2 }
            };

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            var result = controller.GetMostPublishedArtist();

            Assert.NotNull(result);
            Assert.Equal(expectedArtistId1, result.Artist_Id);
            Assert.Equal(expectedArtistName1, result.Name);
        }

        [Fact]
        public void GetSongsByMostPublishedArtistForMainPage_ReturnsSongsByMostPublishedArtist()
        {
            var mostPublishedArtistId = 1;
            var expectedSongCount = 3; 

            var songData = new List<SongDataBaseModel>
            {
                new SongDataBaseModel { Artist_Id = mostPublishedArtistId },
                new SongDataBaseModel { Artist_Id = mostPublishedArtistId },
                new SongDataBaseModel { Artist_Id = mostPublishedArtistId },
                new SongDataBaseModel { Artist_Id = 2 },
                new SongDataBaseModel { Artist_Id = 3 }
            };

            var artistData = new List<ArtistDetails>
            {
                new ArtistDetails { Artist_Id = mostPublishedArtistId, Name = "Most Published Artist" },
                new ArtistDetails { Artist_Id = 2, Name = "Artist 2" },
                new ArtistDetails { Artist_Id = 3, Name = "Artist 3" }
            };

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            var result = controller.GetSongsByMostPublishedArtistForMainPage();

            Assert.NotNull(result); 
            Assert.Equal(expectedSongCount, result.Count);
            Assert.All(result, song => Assert.Equal("Most Published Artist", song.Artist));
        }

        [Fact]
        public void GetSongsByMostPublishedArtistForMainPage_ReturnsEmptyList_WhenNoSongsPublished()
        {
            var songData = new List<SongDataBaseModel>(); 
            var artistData = new List<ArtistDetails>(); 

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            var result = controller.GetSongsByMostPublishedArtistForMainPage();

            Assert.NotNull(result); 
            Assert.Empty(result);
        }

        [Fact]
        public void GetSongsByMostPublishedArtistForMainPage_ReturnsEmptyList_WhenNoSongsPublishedByMostPublishedArtist()
        {
            var mostPublishedArtistId = 1;

            var songData = new List<SongDataBaseModel>
            {
                new SongDataBaseModel { Artist_Id = 2 },
                new SongDataBaseModel { Artist_Id = 3 }
            };

            var artistData = new List<ArtistDetails>
            {
                new ArtistDetails { Artist_Id = mostPublishedArtistId, Name = "Most Published Artist" },
                new ArtistDetails { Artist_Id = 2, Name = "Artist 2" },
                new ArtistDetails { Artist_Id = 3, Name = "Artist 3" }
            };

            var songRepositoryStub = new Mock<IRepository<SongDataBaseModel>>();
            songRepositoryStub.Setup(repo => repo.GetAll()).Returns(songData);

            var artistRepositoryStub = new Mock<IRepository<ArtistDetails>>();
            artistRepositoryStub.Setup(repo => repo.GetAll()).Returns(artistData);

            var featureRepositoryStub = new Mock<IRepository<SongFeatures>>().Object;
            var recommendationRepositoryStub = new Mock<IRepository<SongRecommendationDetails>>().Object;

            var controller = new ArtistSongDashboardController(
                songRepositoryStub.Object,
                featureRepositoryStub,
                recommendationRepositoryStub,
                artistRepositoryStub.Object
            );

            var result = controller.GetSongsByMostPublishedArtistForMainPage();

            Assert.NotNull(result);
        }
    }
}
