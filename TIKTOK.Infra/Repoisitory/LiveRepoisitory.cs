using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Domain;
using TIKTOK.Core.Repoisitory;

namespace TIKTOK.Infra.Repoisitory
{
    public class LiveRepoisitory : ILiveRepoisitory
    {
        private readonly IDBContext _context;
        public LiveRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<string> AddLive(Live live)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_RoomName",live.roomName , DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_startLive", live.startLive, DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("P_userId", live.userId, DbType.Int32, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("Live_PACKAGE.AddLive", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Live Add" : $"1 Live Add";
        }

        public async Task<string> EndLive(Live live)
        {
            Task.Delay(100).Wait();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_endLive", live.endLive, DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("P_userId", live.userId, DbType.Int32, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("Live_PACKAGE.EndLive", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Live End" : $"1 Live End";
        }

        public async Task<List<Live>> GetActiveLive()
        {
            IEnumerable<Live> resualt = await _context.dbConnection.QueryAsync<Live>("Live_PACKAGE.GetActiveLive", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
    }
}
