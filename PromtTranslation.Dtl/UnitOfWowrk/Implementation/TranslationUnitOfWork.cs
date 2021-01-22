using PromtTranslation.Dtl.Repositories.Interface;
using PromtTranslation.Dtl.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PromtTranslation.Dtl.Repositories.Implementation;
using PromtTranslation.Dtl.UnitOfWowrk.Interface;

namespace PromtTranslation.Dtl.UnitOfWowrk.Implementation
{
    public class TranslationUnitOfWork : ITranslatioonUnitOfWork
    {
        private bool disposedValue;

        private readonly TranslationDbContext _translationDbContext;
        public TranslationUnitOfWork(TranslationDbContext translationDbContext) 
        {
            _translationDbContext = translationDbContext;
            Routes = new RouteRepository(_translationDbContext);
            Status = new StatusRepository(_translationDbContext);
            Translations = new TranslationRepository(_translationDbContext);
        }
        public IRouteRepository Routes { get; private set; }

        public IStatusRepository Status { get; private set; }

        public ITranslationRepository Translations { get; private set; }

        public async Task Commit()
        {
            await _translationDbContext.SaveChangesAsync();
        }

        public async Task RollBack()
        {
            await _translationDbContext.DisposeAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TranslationUnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
