using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Domain;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;

namespace TIKTOK.Infra.Repoisitory
{
    public class HomePageRepoisitory : IHomePageRepoisitory
    {
        private readonly IDBContext _context;
        public HomePageRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<HomePage> GetHomePage()
        {
            await Task.Delay(100);
            IEnumerable<HomePage> resualt = await _context.dbConnection.QueryAsync<HomePage>("HomePage_PACKAGE.GetHomePage", commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
        public async Task<List<Link1>> GetLik1()
        {
            await Task.Delay(100);
            IEnumerable<Link1> resualt = await _context.dbConnection.QueryAsync<Link1>("HomePage_PACKAGE.GetLik1", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<VideoHome>> GetAllVideoHome(USER1 user)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VideoHome> resualt = await _context.dbConnection.QueryAsync<VideoHome>("HomePage_PACKAGE.GetAllVideoHome", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<List<SuggestUser>> GetSuggestUser(USER1 user)
        {
            await Task.Delay(200);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<SuggestUser> resualt = await _context.dbConnection.QueryAsync<SuggestUser>("HomePage_PACKAGE.GetSuggestUser", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<LIKE1>> GetAllLikeByVideo(VIDEO video)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_video_id", video.id, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<LIKE1> resualt = await _context.dbConnection.QueryAsync<LIKE1>("HomePage_PACKAGE.GetAllLikeByVideo", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<string> DeletLike(LIKE1 like)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", like.USERID, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_video_id", like.VIDEOID, DbType.String, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("HomePage_PACKAGE.DeletLike", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Video Remove Like" : $"1 Video Remove Like";
        }
        public async Task<UserToPage> GetUserToPage(UserCurent user)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.userId, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_curent_id", user.userCurentId, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<UserToPage> resualt = await _context.dbConnection.QueryAsync<UserToPage>("HomePage_PACKAGE.GetUserToPage", parameters, commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
        public async Task<List<VideoToPage>> GetVideoToPage(UserCurent user)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_user_id", user.userId, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_curent_id", user.userCurentId, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VideoToPage> resualt = await _context.dbConnection.QueryAsync<VideoToPage>("HomePage_PACKAGE.GetVideoToPage", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<string> UpdateHomePage(HomePage home)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_id", home.id, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("P_CAPTUR1", home.captur1, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_CAPTUR2", home.captur2, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_CAPTUR3", home.captur3, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_PARGRAF1", home.pargraf1, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_BUTTON1", home.button1, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_PARGRAF2", home.pargraf2, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_COPYRIGTH", home.copyRigth, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_NAVLOGO", home.navLogo, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_NAVBUTTON1", home.navButton1, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_NAVBUTTON2", home.navButton2, DbType.String, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("HomePage_PACKAGE.UpdateHomePage", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Home Page Updated" : $"1 Home Page Updated";
        }
    }
}
