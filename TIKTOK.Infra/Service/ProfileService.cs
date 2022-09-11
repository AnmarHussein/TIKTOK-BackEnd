using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;

namespace TIKTOK.Infra.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepoisitory _profileRepoisitory;
        public ProfileService(IProfileRepoisitory profileRepoisitory)
        {
            _profileRepoisitory = profileRepoisitory;
        }
        public async Task<List<Followers>> GetAllFollowers(Followers follow)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetAllFollowers(follow);
        }

        public async Task<List<Followers>> GetAllFollowing(Followers follow)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetAllFollowing(follow);
        }

        public async Task<List<VIDEO>> GetAllVidoesToUser(VIDEO video)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetAllVidoesToUser(video);
        }
        public async Task<string> BlockUserAdmin(USER1 user)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.BlockUserAdmin(user);
        }
        public async Task<string> BlockVideoAdmin(VIDEO video)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.BlockVideoAdmin(video);
        }

        public async Task<List<ReplayVideo>> GetAllReplayVideo(VIDEO video)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetAllReplayVideo(video);
        }
        public async Task<List<LikeVideo>> GetAllLikeVideo(VIDEO video)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetAllLikeVideo(video);
        }

        public async Task<List<GetCount>> GetCountReplayVideo(VIDEO video)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetCountReplayVideo(video);
        }
        public async Task<List<GetCount>> GetCountLikeVideo(VIDEO video)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetCountLikeVideo(video);
        }
        public async Task<List<AllVideoAndCount>> GetAllVideoAndCount(USER1 user)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetAllVideoAndCount(user);
        }
        public async Task<VideoWithUser> GetVideoToBlock(VIDEO video)
        {
            await Task.Delay(300);
            return await _profileRepoisitory.GetVideoToBlock(video);
        }

    }
}
