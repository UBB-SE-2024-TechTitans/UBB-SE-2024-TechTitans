using TechTitans.Models;
using TechTitans.Repositories;

namespace TechTitans.Services
{
    /// <summary>
    /// /// Provides functionality for managing and retrieving information
    /// about songs and artists, including song features and recommendations.
    /// </summary>
    public class ArtistSongDashboardController
    {
        private IRepository<SongDataBaseModel> songRepository;
        private IRepository<SongFeatures> featureRepository;
        private IRepository<SongRecommendationDetails> songRecommendationRepository;
        private IRepository<ArtistDetails> artistRepository;

        /// <summary>
        /// Transforms a song database model to a simplified song information model,
        /// including retrieving the artist's name and song features.
        /// </summary>
        /// <param name="song">The song database model to transform.</param>
        /// <returns>A simplified song information model with the artist's name
        /// and song features included.</returns>
        ///
        public ArtistSongDashboardController(IRepository<SongDataBaseModel> songRepository, IRepository<SongFeatures> featureRepository, IRepository<SongRecommendationDetails> songRecommendationRepository, IRepository<ArtistDetails> artistRepository)
        {
            this.songRepository = songRepository;
            this.featureRepository = featureRepository;
            this.songRecommendationRepository = songRecommendationRepository;
            this.artistRepository = artistRepository;
        }

        public SongBasicInformation TransformSongDataBaseModelToSongInfo(SongDataBaseModel song)
        {
            SongBasicInformation songInfo = new SongBasicInformation();
            songInfo.SongId = song.Song_Id;
            songInfo.Name = song.Name;
            songInfo.Genre = song.Genre;
            songInfo.Subgenre = song.Subgenre;
            songInfo.Language = song.Language;
            songInfo.Country = song.Country;
            songInfo.Album = song.Album;
            songInfo.Image = song.Image;
            foreach (ArtistDetails artist in artistRepository.GetAll())
            {
                if (artist.Artist_Id == song.Artist_Id)
                {
                    songInfo.Artist = artist.Name;
                }
            }
            foreach (SongFeatures feature in featureRepository.GetAll())
            {
                if (feature.Song_Id == song.Song_Id)
                {
                    songInfo.Features.Add(feature.ToString());
                }
            }
            return songInfo;
        }

        /// <summary>
        /// Retrieves all songs by a specific artist.
        /// </summary>
        /// <param name="artistId">The ID of the artist.</param>
        /// <returns>A list of simplified song information models
        /// for the specified artist.</returns>
        public List<SongBasicInformation> GetAllArtistSongs(int artistId)
        {
            List<SongBasicInformation> artistSongs = new List<SongBasicInformation>();
            foreach (SongDataBaseModel song in songRepository.GetAll())
            {
                if (song.Artist_Id == artistId)
                {
                    SongBasicInformation songInfo = TransformSongDataBaseModelToSongInfo(song);
                    artistSongs.Add(songInfo);
                }
            }
            return artistSongs;
        }

        /// <summary>
        /// Searches for songs by title.
        /// </summary>
        /// <param name="title">The title of the song to search for.</param>
        /// <returns>A list of simplified song information models
        /// that match the search title.</returns>
        public List<SongBasicInformation> SearchSongsByTitle(string title)
        {
            List<SongBasicInformation> songs = new List<SongBasicInformation>();
            foreach (SongDataBaseModel song in songRepository.GetAll())
            {
                if (song.Name.ToLower().Trim().Contains(title.ToLower()))
                {
                    SongBasicInformation songInfo = TransformSongDataBaseModelToSongInfo(song);
                    songs.Add(songInfo);
                }
            }
            return songs;
        }

        /// <summary>
        /// Retrieves detailed information about a specific song.
        /// </summary>
        /// <param name="songId">The ID of the song.</param>
        /// <returns>A simplified song information model for the specified song,
        /// or null if not found.</returns>
        public SongBasicInformation GetSongInformation(int songId)
        {
            foreach (SongDataBaseModel song in songRepository.GetAll())
            {
                if (song.Song_Id == songId)
                {
                    SongBasicInformation songInfo = TransformSongDataBaseModelToSongInfo(song);
                    return songInfo;
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves song recommendation details for a specific song.
        /// </summary>
        /// <param name="songId">The ID of the song.</param>
        /// <returns>Song recommendation details for the specified song.</returns>
        public SongRecommendationDetails GetSongRecommandationDetails(int songId)
        {
            foreach (SongRecommendationDetails songDetails in songRecommendationRepository.GetAll())
            {
                if (songDetails.Song_Id == songId)
                {
                    return songDetails;
                }
            }

            return new SongRecommendationDetails();
        }

        /// <summary>
        /// Retrieves artist information by a specific song.
        /// </summary>
        /// <param name="songId">The ID of the song.</param>
        /// <returns>Artist details for the specified song,
        /// or null if not found.</returns>
        public ArtistDetails GetArtistInfoBySong(int songId)
        {
            foreach (SongDataBaseModel song in songRepository.GetAll())
            {
                if (song.Song_Id == songId)
                {
                    foreach (ArtistDetails artist in artistRepository.GetAll())
                    {
                        if (artist.Artist_Id == song.Artist_Id)
                        {
                            return artist;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves the artist with the most published songs.
        /// </summary>
        /// <returns>Artist details for the artist
        /// with the most published songs.</returns>
        public ArtistDetails GetMostPublishedArtist()
        {
            Dictionary<int, int> artistSongCount = new Dictionary<int, int>();
            foreach (SongDataBaseModel song in songRepository.GetAll())
            {
                if (artistSongCount.ContainsKey(song.Artist_Id))
                {
                    artistSongCount[song.Artist_Id]++;
                }
                else
                {
                    artistSongCount.Add(song.Artist_Id, 1);
                }
            }
            int maximumSongCount = 0;
            int artistId = 0;
            foreach (KeyValuePair<int, int> entry in artistSongCount)
            {
                if (entry.Value > maximumSongCount)
                {
                    maximumSongCount = entry.Value;
                    artistId = entry.Key;
                }
            }
            foreach (ArtistDetails artist in artistRepository.GetAll())
            {
                if (artist.Artist_Id == artistId)
                {
                    return artist;
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves songs by the most published artist for the main page.
        /// </summary>
        /// <returns>A list of simplified song information
        /// models by the most published artist.</returns>
        public List<SongBasicInformation> GetSongsByMostPublishedArtistForMainPage()
        {
            List<SongBasicInformation> songsOfMostPublishedArtist = new List<SongBasicInformation>();
            var mostPublishedArtist = GetMostPublishedArtist();
            int artistId = mostPublishedArtist != null ? mostPublishedArtist.Artist_Id : -1;

            foreach (SongDataBaseModel song in songRepository.GetAll())
            {
                if (song.Artist_Id == artistId)
                {
                    SongBasicInformation songInfo = TransformSongDataBaseModelToSongInfo(song);
                    songsOfMostPublishedArtist.Add(songInfo);
                }
            }
            return songsOfMostPublishedArtist;
        }
    }
}
