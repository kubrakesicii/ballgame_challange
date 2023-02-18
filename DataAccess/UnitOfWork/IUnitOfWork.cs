using DataAccess.Abstract;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPlayerRepository Players { get; }
        //int SaveChanges();
    }
}
