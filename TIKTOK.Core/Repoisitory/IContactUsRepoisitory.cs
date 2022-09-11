using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;

namespace TIKTOK.Core.Repoisitory
{
    public interface IContactUsRepoisitory
    {
        public Task<string> Insert(ContactUs contact);
        public Task<string> Important(ContactUs contact);
        public Task<string> Trash(ContactUs contact);
        public Task<string> TrashRemove(ContactUs contact);
        public Task<string> ReadEmail(ContactUs contact);
        public Task<List<ContactUs>> GetAll();
        public Task<ContactUs> GetById(ContactUs contact);
    }
}
