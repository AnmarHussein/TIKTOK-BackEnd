using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;

namespace TIKTOK.Infra.Service
{
    public class ProfileUserService : IProfileUserService
    {
        private readonly IProfileUserRepoisitory _userProfileRepoisitory;
        private readonly IGenericRepoisitory<VISACARD> _visaCardService;
        private readonly IGenericRepoisitory<PROMOTE> _promoteService;
        public ProfileUserService(IProfileUserRepoisitory userProfileRepoisitory, IGenericRepoisitory<PROMOTE> promoteService, IGenericRepoisitory<VISACARD> visaCardService)
        {
            _userProfileRepoisitory = userProfileRepoisitory;
            _promoteService = promoteService;
            _visaCardService = visaCardService;
        }
        public async Task<List<GetFollowerBlockDto>> GetAllFollwerBlock(USER1 user)
        {
            await Task.Delay(300);
            return await _userProfileRepoisitory.GetAllFollwerBlock(user);
        }

        public async Task<List<GetFollowerBlockDto>> GetAllFollwingBlock(USER1 user)
        {
            await Task.Delay(300);
            return await _userProfileRepoisitory.GetAllFollwingBlock(user);
        }

        public async Task<UserStatsticDto> GetAllUserCountStatistic(USER1 user)
        {
            await Task.Delay(300);
            return await _userProfileRepoisitory.GetAllUserCountStatistic(user);
        }

        public async Task<List<VideosCountReplayLike>> GetAllVideoLikeReplayCount(USER1 user)
        {
            await Task.Delay(300);
            return await _userProfileRepoisitory.GetAllVideoLikeReplayCount(user);
        }

        public async Task<VisaCardCountSumSaelesDto> GetVisaCardCountSumSaeles(USER1 user)
        {
            await Task.Delay(300);
            return await _userProfileRepoisitory.GetVisaCardCountSumSaeles(user);
        }
        public async Task<List<VISACARD>> GetVisaCardByUser(USER1 user)
        {
            await Task.Delay(300);
            return await _userProfileRepoisitory.GetVisaCardByUser(user);
        }
        public async Task<List<PromotUserAll>> GetAllPromotVideoByUser(USER1 user)
        {
            await Task.Delay(300);
            return await _userProfileRepoisitory.GetAllPromotVideoByUser(user);
        }
        public async Task<string> InsertPromote(PromoteUserDto promote)
        {
            await Task.Delay(300);
            VISACARD itemVisa = new VISACARD();
            itemVisa.cardNumber = promote.cardNumber;
            var visa = await _visaCardService.GenericCRUD<VISACARD>("GETBYCARDNUMBER", itemVisa);
            if(visa == null || visa.securityCode != promote.securityCode)
            {
                return "The VisaCard has Erorr";
            }
            PROMOTE itemPromote = new PROMOTE();
            itemPromote.promoteTypeId = promote.promoteTypeId;
            itemPromote.cardId = visa.id;
            itemPromote.createAt = DateTime.Now;
            itemPromote.amount = promote.amount;
            itemPromote.videoId = promote.videoId;

            return await _promoteService.GenericCRUD<string>("INSERT", itemPromote);

        }
    }
}
