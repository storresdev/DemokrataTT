using System.Linq.Expressions;
using DemokrataTT.Data;
using DemokrataTT.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DemokrataTT.Repository
{
    /// <summary>
    /// Implementación del servicio generico para operaciones CRUD
    /// </summary>
    /// <typeparam name="T">Entidad a operar</typeparam>
    public class Repository<T>(DataContext data) : IRepository<T> where T : class
    {
        private readonly DataContext dataContext = data;
        internal DbSet<T> dbSet = data.Set<T>();

        /// <summary>
        /// Método de creación
        /// </summary>
        /// <param name="entity">Entidad a operar</param>
        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
        }

        /// <summary>
        /// Método de obtiención de datos
        /// </summary>
        /// <param name="expression">Entidad a operar</param>
        /// <param name="tracked">Identificador del rastreador de cambios</param>
        /// <returns>Resultado de la operación</returns>
        public async Task<T> GetData(Expression<Func<T, bool>>? expression = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Método de obtención de datos filtrado por una expresión
        /// </summary>
        /// <param name="expression">Expreción a filtrar</param>
        /// <returns>Resultado de la operación</returns>
        public async Task<List<T>> GetListData(Expression<Func<T, bool>>? expression = null)
        {
            IQueryable<T> query = dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Método de eliminación
        /// </summary>
        /// <param name="entity">Entidad a operar</param>
        /// <returns>Resultado de la operación</returns>
        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
            await Save();
        }

        /// <summary>
        /// Método para asegurar y guardar cambios
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        public async Task Save()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
