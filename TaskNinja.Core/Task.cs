using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskNinja.Core;

[Table("Tasks", Schema = "Tasks")]
[PrimaryKey(nameof(Id))]
public class Task
{
  #region Implementation of ITask

  public Guid Id { get; }
  public string Name { get; set; }
  public string Description { get; set; }
  public TaskStatus Status { get; set; }
  public IList<Responsible> Responsible { get; }
  public IList<TaskDiscussion> Discussions { get; }

  #endregion

  #region Overrides of Object

  public override string ToString()
  {
    var responsible = this.GetAllTaskResponsible();
    var discussions = this.GetAllTaskDiscussions();
    return @$"{this.Name} [{responsible}]
    {this.Description}

    Обсуждение: {discussions}";
  }

  public override bool Equals(object? obj)
  {
    if (obj is Task task)
      return this.Id == task.Id;

    return false;
  }

  public override int GetHashCode()
  {
    return this.Id.GetHashCode();
  }

  #endregion

  public Task(string name, string description, IList<Responsible> responsible, TaskStatus status)
  {
    this.Id = Guid.NewGuid();
    this.Name = name;
    this.Description = description;
    this.Responsible = responsible;
    this.Discussions = new List<TaskDiscussion>();
    this.Status = status;
  }

  public Task(string name, string description)
    : this(name, description, new List<Responsible>(), TaskStatus.Todo)
  {
  }

  public Task(string name)
    : this(name, string.Empty)
  {
  }

  public Task() : this(string.Empty)
  {
  }
}