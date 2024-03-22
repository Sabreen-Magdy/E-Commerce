using Domain.Entities;

namespace Domain.Repositories;

public interface ISallerRepository :
    IBaseRepository<Customer>, ILoginRepository
{

}
