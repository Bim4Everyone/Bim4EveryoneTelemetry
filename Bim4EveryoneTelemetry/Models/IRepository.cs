namespace Bim4EveryoneTelemetry.Models;

/// <summary>
/// Base interface for repositories.
/// </summary>
/// <typeparam name="T">Model class.</typeparam>
public interface IRepository<T> {
    /// <summary>
    /// Async create row in DB.
    /// </summary>
    /// <param name="item">Creation element.</param>
    /// <returns>Returns creation element task.</returns>
    Task CreateAsync(T item);
    
    /// <summary>
    /// Save information to DB.
    /// </summary>
    /// <returns>Returns save task.</returns>
    Task Save();
}