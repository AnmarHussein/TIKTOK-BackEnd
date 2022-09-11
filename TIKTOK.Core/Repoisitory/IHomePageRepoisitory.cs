using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;

namespace TIKTOK.Core.Repoisitory
{
    public interface IHomePageRepoisitory
    {
        public Task<HomePage> GetHomePage();
        public Task<List<Link1>> GetLik1();
        public Task<List<SuggestUser>> GetSuggestUser(USER1 user);
        public Task<List<VideoHome>> GetAllVideoHome(USER1 user);
        public Task<List<LIKE1>> GetAllLikeByVideo(VIDEO video);
        public Task<string> DeletLike(LIKE1 like);
        public Task<UserToPage> GetUserToPage(UserCurent user);
        public Task<List<VideoToPage>> GetVideoToPage(UserCurent user);

        public Task<string> UpdateHomePage(HomePage home);
    }
}
