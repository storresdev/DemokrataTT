using System.Linq.Expressions;
using DemokrataTT.Data;
using DemokrataTT.Models.Entities;
using DemokrataTT.Pagination;
using DemokrataTT.Repository.IRepository;

namespace DemokrataTT.Repository
{
    /// <summary>
    /// Implementación del servicio para las operaciones especificas a la entidad Usuario
    /// </summary>
    public class UserRepository(DataContext data, IPagination? pagination) : Repository<User>(data), IUserRepository
    {
        private readonly DataContext dataContext = data;
        private readonly IPagination? _pagination = pagination;

        /// <summary>
        /// Método para actualizar usuario
        /// </summary>
        /// <param name="entity">Entidad usuario</param>
        /// <returns>Resultado de la operación</returns>
        public async Task<User> Update(User entity)
        {
            entity.ModificationDate = DateTime.Now;
            dataContext.Users.Update(entity);
            await dataContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Método para la cunsulta por nombre o por apellido y paginación de resultados
        /// </summary>
        /// <param name="expression">Expresión a filtrar</param>
        /// <param name="request">Paramaetros de páginación</param>
        /// <returns>Resultado de la busqueda paginada</returns>
        public async Task<List<User>> GetPagination(Expression<Func<User, bool>> expression, PaginationParams request)
        {
            IQueryable<User> query = dbSet;

            query = query.Where(expression);

            var resultPagination = await _pagination.CreatePagedGenericResult(query,
                request.PageNumber,
                request.PageSize,
                request.OrderBy!,
                request.OrderAsc);

            return [.. resultPagination.Result];
        }
    }
}
