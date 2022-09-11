using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Dto;

namespace TIKTOK.Core.Repoisitory
{
    public interface IAdminRepoisitory
    {
        public Task<List<SealesDto>> GetSelaesPromote();
        public Task<List<GenderCountDto>> GetGenderCount();
        public Task<List<VideoCountMonthDto>> GetAllVideoCountInMonth(PassDataToProsudeDto monthDto);
        public Task<TableCountRowDto> GetAlltableCountRow(PassDataToProsudeDto monthDto);
        public Task<List<TopFiveUserDto>> GetTopFiveFollowerdUser();
        public Task<List<TopFiveVideo>> GetTopFivelikevideo();
        public Task<List<PromoteInner>> GetAllPromoteInner();

    }
}
