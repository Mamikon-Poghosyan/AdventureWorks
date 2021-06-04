using AdventureWorks.Core.Abstractions.Repositories;
using AdventureWorks.Core.Entities;

namespace AdventureWorks.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AdventureWorksLT2012Context context)
            : base(context)
        {
        }
    }
}
