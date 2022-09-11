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
    public class HomePageService : IHomePageService
    {
        private readonly IHomePageRepoisitory _homepageRepoisitory;
        public HomePageService(IHomePageRepoisitory homepageRepoisitory)
        {
            _homepageRepoisitory = homepageRepoisitory;
        }

        public async Task<HomePage> GetHomePage()
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.GetHomePage();
        }
        public async Task<List<Link1>> GetLik1()
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.GetLik1();
        }
        public async Task<List<VideoHome>> GetAllVideoHome(USER1 user)
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.GetAllVideoHome(user);
        }

        public async Task<List<SuggestUser>> GetSuggestUser(USER1 user)
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.GetSuggestUser(user);
        }
        public async Task<List<LIKE1>> GetAllLikeByVideo(VIDEO video)
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.GetAllLikeByVideo(video);
        }

        public async Task<string> DeletLike(LIKE1 like)
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.DeletLike(like);
        }
        public async Task<UserToPage> GetUserToPage(UserCurent user)
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.GetUserToPage(user);
        }
        public async Task<List<VideoToPage>> GetVideoToPage(UserCurent user)
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.GetVideoToPage(user);
        }

        public async Task<string> UpdateHomePage(HomePage home)
        {
            await Task.Delay(100);
            return await _homepageRepoisitory.UpdateHomePage(home);
        }
    }
}
