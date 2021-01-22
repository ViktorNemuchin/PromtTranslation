using PromtTranslation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromtTranslation.Dtl.Repositories.Interface
{
    public interface IStatusRepository:IBaseRepository<StatusModel>
    {
        Task<StatusModel> GetStatusByValue(string statusValue);
    }
}
