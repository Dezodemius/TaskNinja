using System.Text;

namespace TaskNinja.Core;

public static class TaskExtensions
{
  public static string GetAllTaskResponsible(this Task task)
  {
    var responsible = new StringBuilder("<без исполнителей>");
    for (var i = 0; i < task.Responsible.Count; i++)
    {
      responsible.Append(task.Responsible[i].FullName);

      if (i < task.Responsible.Count - 1)
        responsible.Append(',');
    }

    return responsible.ToString();
  }

  public static string GetAllTaskDiscussions(this Task task)
  {
    var responsible = new StringBuilder("<без обсуждений>");
    for (var i = 0; i < task.Discussions.Count; i++)
    {
      responsible.Append(task.Discussions[i]);

      if (i < task.Discussions.Count - 1)
        responsible.Append(',');
    }

    return responsible.ToString();
  }
}