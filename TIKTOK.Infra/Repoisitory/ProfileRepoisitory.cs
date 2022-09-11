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
    public class ProfileRepoisitory : IProfileRepoisitory
    {
        private readonly IDBContext _context;
        public ProfileRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<List<Followers>> GetAllFollowers(Followers follow)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", follow.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Followers> resualt = await _context.dbConnection.QueryAsync<Followers>("PROFILE_PACKAGE.GETALLFollowers", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<List<Followers>> GetAllFollowing(Followers follow)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", follow.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Followers> resualt = await _context.dbConnection.QueryAsync<Followers>("PROFILE_PACKAGE.GETALLFollowing", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<List<VIDEO>> GetAllVidoesToUser(VIDEO video)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", video.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VIDEO> resualt = await _context.dbConnection.QueryAsync<VIDEO>("PROFILE_PACKAGE.GETALLVidoesToUser", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<List<ReplayVideo>> GetAllReplayVideo(VIDEO video)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_video_id", video.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<ReplayVideo> resualt = await _context.dbConnection.QueryAsync<ReplayVideo>("PROFILE_PACKAGE.GetAllReplayVideo", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<string> BlockUserAdmin(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_isBlock", user.isBlock, DbType.String, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("PROFILE_PACKAGE.BlockUSerAdmin", parameters, commandType: CommandType.StoredProcedure);
            if (user.isBlock == 1)
                return (resualt > 0) ? $"0 User Block" : $"1 User Block";
            return (resualt > 0) ? $"0 USer Remove Block" : $"1 User Remove Block";
        }
        public async Task<string> BlockVideoAdmin(VIDEO video)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_video_id", video.id, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_isBlock", video.isBlock, DbType.String, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("PROFILE_PACKAGE.BlockVideoAdmin", parameters, commandType: CommandType.StoredProcedure);
            if(video.isBlock == 1)
                return (resualt > 0) ? $"0 Video Block" : $"1 Video Block";
            return (resualt > 0) ? $"0 Video Remove Block" : $"1 Video Remove Block Block";
        }

        public async Task<List<LikeVideo>> GetAllLikeVideo(VIDEO video)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_video_id", video.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<LikeVideo> resualt = await _context.dbConnection.QueryAsync<LikeVideo>("PROFILE_PACKAGE.GetAllLikeVideo", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<List<GetCount>> GetCountReplayVideo(VIDEO video)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_video_id", video.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GetCount> resualt = await _context.dbConnection.QueryAsync<GetCount>("PROFILE_PACKAGE.GetCountReplayVideo", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<GetCount>> GetCountLikeVideo(VIDEO video)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_video_id", video.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GetCount> resualt = await _context.dbConnection.QueryAsync<GetCount>("PROFILE_PACKAGE.GetCountLikeVideo", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<AllVideoAndCount>> GetAllVideoAndCount(USER1 user)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<AllVideoAndCount> resualt = await _context.dbConnection.QueryAsync<AllVideoAndCount>("PROFILE_PACKAGE.GetAllVideoAndCount",parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<VideoWithUser> GetVideoToBlock(VIDEO video)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_video_id", video.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VideoWithUser> resualt = await _context.dbConnection.QueryAsync<VideoWithUser>("PROFILE_PACKAGE.GetVideoToBlock", parameters, commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
    }
}
