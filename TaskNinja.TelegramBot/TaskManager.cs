using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace TaskNinja.Core;

public sealed class TaskManager : DbContext
{
  private DbSet<Task> _tasks => Set<Task>();

  private readonly string _connectionString;

  #region Implementation of ITaskManager

  public void AddTask(Task task)
  {
    this._tasks.Add(task);
    this.SaveChanges();
  }

  public Task? GetTask(Guid id)
  {
    return this._tasks.SingleOrDefault(t => t.Id == id);
  }

  public void UpdateTask(Guid oldTaskId, Task newTask)
  {
    var task = this._tasks.SingleOrDefault(t => t.Id == oldTaskId);
    if (task != null)
    {
      task = newTask;
      this.SaveChanges();
    }
  }

  public void DeleteTask(Guid id)
  {
    var taskToRemove = this.GetTask(id);
    if (taskToRemove != null)
      this._tasks.Remove(taskToRemove);
    this.SaveChanges();
  }

  public IEnumerable<Task> GetAll()
  {
    return this._tasks;
  }

  #endregion

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite(this._connectionString, builder => builder.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: "Tasks") );
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("Tasks");
  }

  public TaskManager(string connectionString)
  {
    this._connectionString = connectionString;

    this.Database.EnsureCreated();

    var creator = this.GetService<IRelationalDatabaseCreator>();
    if (!creator.Exists())
      creator.CreateTables();
  }

  public TaskManager()
  {
    
  }
}