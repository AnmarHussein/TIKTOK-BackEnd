using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;

namespace TIKTOK.Infra.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepoisitory _adminRepoisitory;
        public AdminService(IAdminRepoisitory adminRepoisitory)
        {
           _adminRepoisitory = adminRepoisitory;
        }
        public async Task<List<SealesDto>> GetSelaesPromote()
        {
            Task.Delay(1000).Wait();
            return await _adminRepoisitory.GetSelaesPromote();  
        }
        public async Task<List<GenderCountDto>> GetGenderCount()
        {
            Task.Delay(1000).Wait();
            return await _adminRepoisitory.GetGenderCount();
        }

        public async Task<List<VideoCountMonthDto>> GetAllVideoCountInMonth(PassDataToProsudeDto monthDto)
        {
            Task.Delay(1000).Wait();
            return await _adminRepoisitory.GetAllVideoCountInMonth(monthDto);
        }
        public async Task<TableCountRowDto> GetAlltableCountRow(PassDataToProsudeDto monthDto)
        {
            Task.Delay(1000).Wait();
            return await _adminRepoisitory.GetAlltableCountRow(monthDto);
        }
        public async Task<List<TopFiveUserDto>> GetTopFiveFollowerdUser()
        {
            Task.Delay(1000).Wait();
            return await _adminRepoisitory.GetTopFiveFollowerdUser();
        }
        public async Task<List<TopFiveVideo>> GetTopFivelikevideo() 
        {
            Task.Delay(1000).Wait();
            return await _adminRepoisitory.GetTopFivelikevideo();   
        }
        public async Task<List<PromoteInner>> GetAllPromoteInner()
        {
            Task.Delay(1000).Wait();
            return await _adminRepoisitory.GetAllPromoteInner();
        }
    }
}
