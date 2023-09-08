using TaskNinja.Interfaces.Entities;

namespace TaskNinja.Interfaces.Managers;

public interface ITaskManager<T> where T : ITask
{
  public void AddTask(T task);

  public T? GetTask(Guid id);

  public void UpdateTask(Guid oldTaskId, T newTask);

  public void DeleteTask(Guid id);

  public IEnumerable<T> GetAll();
}