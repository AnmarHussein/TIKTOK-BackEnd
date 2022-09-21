using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;

namespace TIKTOK.Core.Repoisitory
{
    public interface ILiveRepoisitory
    {
        public Task<string> AddLive(Live live);
        public Task<string> EndLive(Live live);
        public Task<List<Live>> GetActiveLive();
    }
}
