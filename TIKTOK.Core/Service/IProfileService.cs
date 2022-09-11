using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;

namespace TIKTOK.Core.Service
{
    public interface IProfileService
    {
        public Task<List<Followers>> GetAllFollowers(Followers follow);
        public Task<List<Followers>> GetAllFollowing(Followers follow);
        public Task<List<VIDEO>> GetAllVidoesToUser(VIDEO video);
        public Task<string> BlockUserAdmin(USER1 user);
        public Task<string> BlockVideoAdmin(VIDEO video);

        public Task<List<ReplayVideo>> GetAllReplayVideo(VIDEO video);
        public Task<List<LikeVideo>> GetAllLikeVideo(VIDEO video);
        public Task<List<GetCount>> GetCountReplayVideo(VIDEO video);
        public Task<List<AllVideoAndCount>> GetAllVideoAndCount(USER1 user);
        public Task<List<GetCount>> GetCountLikeVideo(VIDEO video);
        public Task<VideoWithUser> GetVideoToBlock(VIDEO video);
    }
}
