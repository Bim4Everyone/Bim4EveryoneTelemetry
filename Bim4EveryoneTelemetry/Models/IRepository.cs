namespace Bim4EveryoneTelemetry.Models;

public interface IRepository<T> {
    Task Create(T item);
    Task Save();
}