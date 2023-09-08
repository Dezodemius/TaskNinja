namespace TaskNinja.Interfaces.Entities;

public interface ITask
{
  public Guid Id { get; }

  public string Name { get; }

  public string Description { get; }

  public TaskStatus Status { get; }

  public IList<IResponsible> Responsible { get; }

  public IList<ITaskDiscussion> Discussions { get; }
}