using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Domain;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;

namespace TIKTOK.Infra.Repoisitory
{
    public class ProfileUserRepoisitory : IProfileUserRepoisitory
    {
        private readonly IDBContext _context;
        public ProfileUserRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<List<GetFollowerBlockDto>> GetAllFollwerBlock(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GetFollowerBlockDto> resualt = await _context.dbConnection.QueryAsync<GetFollowerBlockDto>("UserProfile_PACKAGE.GetAllFollwerBlock", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<List<GetFollowerBlockDto>> GetAllFollwingBlock(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GetFollowerBlockDto> resualt = await _context.dbConnection.QueryAsync<GetFollowerBlockDto>("UserProfile_PACKAGE.GetAllFollwingBlock", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<UserStatsticDto> GetAllUserCountStatistic(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserStatsticDto> resualt = await _context.dbConnection.QueryAsync<UserStatsticDto>("UserProfile_PACKAGE.GetAllUserCountStatistic", parameters, commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
        public async Task<List<VideosCountReplayLike>> GetAllVideoLikeReplayCount(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VideosCountReplayLike> resualt = await _context.dbConnection.QueryAsync<VideosCountReplayLike>("UserProfile_PACKAGE.GetAllVideoLikeReplayCount", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<VisaCardCountSumSaelesDto> GetVisaCardCountSumSaeles(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VisaCardCountSumSaelesDto> resualt = await _context.dbConnection.QueryAsync<VisaCardCountSumSaelesDto>("UserProfile_PACKAGE.GetVisaCardCountSumSaeles", parameters, commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
        public async Task<List<VISACARD>> GetVisaCardByUser(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VISACARD> resualt = await _context.dbConnection.QueryAsync<VISACARD>("UserProfile_PACKAGE.GetVisaCardByUser", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<PromotUserAll>> GetAllPromotVideoByUser(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<PromotUserAll> resualt = await _context.dbConnection.QueryAsync<PromotUserAll>("UserProfile_PACKAGE.GetAllPromotVideoByUser", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
    }
}
