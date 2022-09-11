using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Domain;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;

namespace TIKTOK.Infra.Repoisitory
{
    public class AdminRepoisitory : IAdminRepoisitory
    {
        private readonly IDBContext _context;
        public AdminRepoisitory(IDBContext context)
        {
            _context = context;
        }

        public async Task<List<GenderCountDto>> GetGenderCount()
        {
            Task.Delay(1000).Wait();
            IEnumerable<GenderCountDto> resualt = await _context.dbConnection.QueryAsync<GenderCountDto>("Admin_PACKAGE.GetGenderCount", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<List<SealesDto>> GetSelaesPromote()
        {
            Task.Delay(1000).Wait();
            IEnumerable<SealesDto> resualt = await _context.dbConnection.QueryAsync<SealesDto>("Admin_PACKAGE.GetSelaesPromote", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<VideoCountMonthDto>> GetAllVideoCountInMonth(PassDataToProsudeDto monthDto)
        {
            Task.Delay(1000).Wait();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("tablename", monthDto.tablename, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("cloname", monthDto.cloname, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_year", monthDto.year, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VideoCountMonthDto> resualt = await _context.dbConnection.QueryAsync<VideoCountMonthDto>("Admin_PACKAGE.GetAllVideoCountInMonth", parameters, commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<TableCountRowDto> GetAlltableCountRow(PassDataToProsudeDto monthDto)
        {
            Task.Delay(1000).Wait();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("tablename", monthDto.tablename, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("cloname", monthDto.cloname, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<TableCountRowDto> resualt = await _context.dbConnection.QueryAsync<TableCountRowDto>("Admin_PACKAGE.GetAlltableCountRow", parameters, commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
        public async Task<List<TopFiveUserDto>> GetTopFiveFollowerdUser()
        {
            Task.Delay(1000).Wait();
            IEnumerable<TopFiveUserDto> resualt = await _context.dbConnection.QueryAsync<TopFiveUserDto>("Admin_PACKAGE.GetTopFiveFollowerdUser", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<TopFiveVideo>> GetTopFivelikevideo()
        {
            Task.Delay(1000).Wait();
            IEnumerable<TopFiveVideo> resualt = await _context.dbConnection.QueryAsync<TopFiveVideo>("Admin_PACKAGE.GetTopFivelikevideo", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
        public async Task<List<PromoteInner>> GetAllPromoteInner()
        {
            Task.Delay(1000).Wait();
            IEnumerable<PromoteInner> resualt = await _context.dbConnection.QueryAsync<PromoteInner>("Admin_PACKAGE.GetAllPromoteInner", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }
    }
}
