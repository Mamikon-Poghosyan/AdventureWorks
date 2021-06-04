using System;

namespace AdventureWorks.Core.Abstractions
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
