namespace Bim4EveryoneTelemetry.Models;

public interface IRepository<T> {
    Task CreateAsync(T item);
    Task Save();
}