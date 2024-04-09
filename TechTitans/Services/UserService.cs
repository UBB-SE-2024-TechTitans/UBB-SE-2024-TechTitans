using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTitans.Models;
using TechTitans.Repositories;
namespace TechTitans.Services
{
    internal class UserService
    {
        private UserRepository SongRepo= new UserRepository();
        
        public List<SongBasicInfo> get_recently_played() {
            List<SongBasicInfo> list_song=new List<SongBasicInfo>();
            foreach (SongBasicDetails song in SongRepo.GetAll()){ 
                SongBasicInfo song_info = SongRepo.SongBasicDetailsToSongBasicInfo(song);
                list_song.Add(song_info);
            }
            return list_song;
        }
    }
}
