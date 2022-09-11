using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;

namespace TIKTOK.Core.Service
{
    public interface IProfileUserService
    {
        public Task<List<GetFollowerBlockDto>> GetAllFollwerBlock(USER1 user);
        public Task<List<GetFollowerBlockDto>> GetAllFollwingBlock(USER1 user);
        public Task<UserStatsticDto> GetAllUserCountStatistic(USER1 user);
        public Task<List<VideosCountReplayLike>> GetAllVideoLikeReplayCount(USER1 user);

        public Task<VisaCardCountSumSaelesDto> GetVisaCardCountSumSaeles(USER1 user);
        public Task<List<VISACARD>> GetVisaCardByUser(USER1 user);
        public Task<List<PromotUserAll>> GetAllPromotVideoByUser(USER1 user);
        public Task<string> InsertPromote(PromoteUserDto promote);
    }
}
