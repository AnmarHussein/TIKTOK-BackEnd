using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;

namespace TIKTOK.Infra.Service
{
    public class GenericService<TModel> : IGenericService<TModel>
    {
        public IGenericRepoisitory<TModel> _genericRepoisitory;
        public GenericService(IGenericRepoisitory<TModel> genericRepoisitory)
        {
            _genericRepoisitory = genericRepoisitory;
        }
        public async Task<T> GenericCRUD<T>(string action, TModel model)
        {
            await Task.Delay(300);
            return await _genericRepoisitory.GenericCRUD<T>(action, model);
        }
    }
}
