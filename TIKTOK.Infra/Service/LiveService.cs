using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;

namespace TIKTOK.Infra.Service
{
    public class LiveService : ILiveService
    {
        private readonly ILiveRepoisitory _liveRepoisitory;
        public LiveService(ILiveRepoisitory liveRepoisitory)
        {
            _liveRepoisitory = liveRepoisitory;
        }
        public async Task<string> AddLive(Live live)
        {
            Task.Delay(1000).Wait();
            return await _liveRepoisitory.AddLive(live);
        }

        public async Task<string> EndLive(Live live)
        {

            return await _liveRepoisitory.EndLive(live);    
        }

        public async Task<List<Live>> GetActiveLive()
        {
            return await _liveRepoisitory.GetActiveLive();    
        }
    }
}
