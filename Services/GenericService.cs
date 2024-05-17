using Nike_clone_Backend.Repositories;

namespace Nike_clone_Backend.Services;
public class GenericService
{
    protected readonly IUnitOfWork _unitOfWork;
    public GenericService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}

