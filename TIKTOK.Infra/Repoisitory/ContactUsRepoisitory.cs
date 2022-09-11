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
    public class ContactUsRepoisitory : IContactUsRepoisitory
    {
        private readonly IDBContext _context;
        public ContactUsRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<List<ContactUs>> GetAll()
        {
            await Task.Delay(100);
            IEnumerable<ContactUs> resualt = await _context.dbConnection.QueryAsync<ContactUs>("ContactUS_PACKAGE.ContactUSGetAll", commandType: CommandType.StoredProcedure);
            return resualt.ToList();
        }

        public async Task<string> Important(ContactUs contact)
        {
            await Task.Delay(300);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_ID", contact.id, DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("P_important", contact.important, DbType.String, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("ContactUS_PACKAGE.ContactUSImportant", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Row Updated" : $"1 Row Updated";
        }

        public async Task<string> Insert(ContactUs contact)
        {
            Task.Delay(300).Wait();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_FullName", contact.fullName, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_email", contact.email, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_Subject", contact.subject, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_Message", contact.message, DbType.String, direction: ParameterDirection.Input);
            parameters.Add("P_createAt", contact.createAt, DbType.DateTime, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("ContactUS_PACKAGE.ContactUSInsert", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Row Inserted" : $"1 Row Inserted";
        }

        public async Task<string> Trash(ContactUs contact)
        {
            Task.Delay(300).Wait();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_ID", contact.id, DbType.Int32, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("ContactUS_PACKAGE.ContactUSTrash", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Row Trashed" : $"1 Row Trashed";
        }

        public async Task<string> TrashRemove(ContactUs contact)
        {
            Task.Delay(300).Wait();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_ID", contact.id, DbType.Int32, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("ContactUS_PACKAGE.ContactUSTrashRemove", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Row UnTrashed" : $"1 Row UnTrashed";
        }
        public async Task<string> ReadEmail(ContactUs contact)
        {
            Task.Delay(300).Wait();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_ID", contact.id, DbType.Int32, direction: ParameterDirection.Input);
            var resualt = await _context.dbConnection.ExecuteAsync("ContactUS_PACKAGE.ContactUSReadEmail", parameters, commandType: CommandType.StoredProcedure);
            return (resualt > 0) ? $"0 Row Read" : $"1 Row Read";
        }
        public async Task<ContactUs> GetById(ContactUs contact)
        {
            await Task.Delay(100);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_ID", contact.id, DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ContactUs> resualt = await _context.dbConnection.QueryAsync<ContactUs>("ContactUS_PACKAGE.ContactUSGetById", parameters, commandType: CommandType.StoredProcedure);
            return resualt.FirstOrDefault();
        }
    }
}
