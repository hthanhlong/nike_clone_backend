using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;
using Reformation.Repositories;
using Reformation.Repositories.CategoryRepository;
using Reformation.Repositories.UserRepository;

namespace Reformation.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public CategoryRepository CategoryRepository { get; }
        public UserRepository UserRepository { get; }
        public Task SaveAsync();
    }
}

