using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;

namespace TIKTOK.Infra.Service
{
    public class ContactUsServicecs: IContactUsService
    {
        private readonly IContactUsRepoisitory _contactUs;
        public ContactUsServicecs(IContactUsRepoisitory contactUs)
        {
            _contactUs = contactUs;
        }

        public async Task<List<ContactUs>> GetAll()
        {
            return await _contactUs.GetAll();
        }

        public async Task<string> Important(ContactUs contact)
        {
            return await _contactUs.Important(contact);
        }

        public async Task<string> Insert(ContactUs contact)
        {
            return await _contactUs.Insert(contact);
        }

        public async Task<string> Trash(ContactUs contact)
        {
            return await _contactUs.Trash(contact);
        }

        public async Task<string> TrashRemove(ContactUs contact)
        {
            return await _contactUs.TrashRemove(contact);
        }
        public async Task<string> ReadEmail(ContactUs contact)
        {
            return await _contactUs.ReadEmail(contact);
        }
        public async Task<ContactUs> GetById(ContactUs contact)
        {
            return await _contactUs.GetById(contact);
        }
    }
}
