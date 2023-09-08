namespace TaskNinja.Interfaces;

public interface IResponsible
{
  public Guid Id { get; }

  public string FullName { get; }
}