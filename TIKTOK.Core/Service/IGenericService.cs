using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TIKTOK.Core.Service
{
    public interface IGenericService<TModel>
    {
        public Task<T> GenericCRUD<T>(string action, TModel model);
    }
}
