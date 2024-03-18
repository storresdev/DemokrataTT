using System.Linq.Expressions;

namespace DemokrataTT.Repository.IRepository
{
    /// <summary>
    /// Interfaz generica de servicios CRUD
    /// </summary>
    /// <typeparam name="T">Entidad a operar</typeparam>
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);

        Task<List<T>> GetListData(Expression<Func<T, bool>>? expression = null);

        Task<T> GetData(Expression<Func<T, bool>>? expression = null, bool tracked = true);

        Task Remove(T entity);

        Task Save();
    }
}
