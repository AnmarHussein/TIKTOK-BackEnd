using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Domain;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;

namespace TIKTOK.Infra.Repoisitory
{
    public class AuthenticationRepoisitory : IAuthenticationRepoisitory
    {
        private readonly IDBContext _context;
        public AuthenticationRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<AuthUserDto> GetUserAuth(LoginDto login)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_UserName", login.userName, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_password", login.password, DbType.String, direction: ParameterDirection.Input);
            IEnumerable<AuthUserDto> resualt = await _context.dbConnection.QueryAsync<AuthUserDto>("AUTHUNTICATION_PACKAGE.GetUserAuth", parameters, commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
        public async Task<string> ConfirmEmail(string userName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_UserName", userName, DbType.String, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("AUTHUNTICATION_PACKAGE.ConfirmEmail", parameters, commandType: CommandType.StoredProcedure);
            return (resualt < 0) ? $" 1 Email Confirm" : $"0 Email Confirm Plz Contact Me !! ";
        }
        public async Task<string> ForgetPassWord(AuthUserDto user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("p_email", user.email, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("p_PASSWORD", user.newPassword, DbType.String, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("AUTHUNTICATION_PACKAGE.ForgetPassWord", parameters, commandType: CommandType.StoredProcedure);
            return (resualt < 0) ? $"Forget Password Sucessfly" : $"Cant Change Password Plz Contact Me !! ";
        }
    }
}
