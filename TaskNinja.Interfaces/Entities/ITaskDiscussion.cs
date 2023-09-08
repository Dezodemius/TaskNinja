namespace TaskNinja.Interfaces.Entities;

public interface ITaskDiscussion
{
  public Guid Id { get; }

  public ITask Task { get; }

  public string Text { get; }
}