using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PromtTranslation.Dtl.Repositories.Interface;

namespace PromtTranslation.Dtl.UnitOfWowrk.Interface
{
    public interface ITranslatioonUnitOfWork : IDisposable
    {
        IRouteRepository Routes { get; }
        IStatusRepository Status { get; }
        ITranslationRepository Translations { get; }
        Task Commit();
        Task RollBack();
    }
}
