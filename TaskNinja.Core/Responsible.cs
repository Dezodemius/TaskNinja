using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskNinja.Core;

[Table("Responsible", Schema = "Tasks")]
[PrimaryKey(nameof(Id))]
public class Responsible
{
  #region Implementation of IResponsible

  public Guid Id { get; }
  public string FullName { get; }

  #endregion
}