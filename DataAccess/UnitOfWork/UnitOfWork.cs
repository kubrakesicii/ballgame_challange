using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using DataAccess.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly TempContext _context;

        private readonly IPlayerRepository _playerRepository;
        public IPlayerRepository Players => _playerRepository ?? new PlayerRepository();


        //public UnitOfWork(TempContext context)
        //{
        //    if (context == null)
        //        throw new ArgumentNullException("dbContext can not be null.");
        //    _context = context;
        //}

        //public int SaveChanges()
        //{
        //    return _context.SaveChanges();
        //}
    }
}
