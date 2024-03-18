using System.Linq.Expressions;
using DemokrataTT.Models.Entities;
using DemokrataTT.Pagination;

namespace DemokrataTT.Repository.IRepository
{
    /// <summary>
    /// Interfaz para los servicios de Usario
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Update(User entity);

        Task<List<User>> GetPagination(Expression<Func<User, bool>> expression, PaginationParams request);
    }
}
