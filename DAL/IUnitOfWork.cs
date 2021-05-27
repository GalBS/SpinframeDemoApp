using DAL.Repositories;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }

        int Complete();
    }
}
