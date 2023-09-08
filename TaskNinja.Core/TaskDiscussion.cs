using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskNinja.Core;

[Table("TaskDiscussion", Schema = "Tasks")]
[PrimaryKey(nameof(Id))]
public class TaskDiscussion
{
  #region Implementation of ITaskDiscussion

  public Guid Id { get; }
  public Task Task { get; }
  public string Text { get; }

  #endregion
}