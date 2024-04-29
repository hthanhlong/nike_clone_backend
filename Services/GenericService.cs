using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reformation.UnitOfWork;

namespace Reformation.Services
{
    public class GenericService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

