using AutoMapper;
using Nike_clone_Backend.UnitOfWork;

namespace Nike_clone_Backend.Services
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

