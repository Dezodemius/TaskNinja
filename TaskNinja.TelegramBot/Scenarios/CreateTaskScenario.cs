using System;
using System.Collections.Generic;
using BotCommon.Scenarios;
using TaskNinja.Core;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Task = System.Threading.Tasks.Task;

namespace TaskNinja.TelegramBot.Scenarios;

public class CreateTaskScenario : AutoStepBotCommandScenarioWithTaskManager
{
  private static Guid taskId;

  private static async Task ShowEnterTaskName(ITelegramBotClient bot, Update update, long chatId)
  {
    await bot.SendTextMessageAsync(chatId, "Введите название задачи");
  }

  private static async Task CreateTaskName(ITelegramBotClient bot, Update update, long chatId)
  {
    if (update is { Type: UpdateType.Message, Message: not null })
    {
      var taskName = update.Message.Text ?? string.Empty;
      var task = new Core.Task(taskName, string.Empty);
      taskId = task.Id;

      _taskManager.AddTask(task);
      await bot.SendTextMessageAsync(chatId, $"Введите описание задачи '{taskName}'");
    }
  }

  private static async Task FillTaskDescription(ITelegramBotClient bot, Update update, long chatId)
  {
    if (update.Type == UpdateType.Message && update.Message.Text != null)
    {
      var taskName = update.Message.Text;
      var createdTask = _taskManager.GetTask(taskId);
      if (createdTask == null)
      {
        await bot.SendTextMessageAsync(chatId, $"Задача с id {taskId} и именем {taskName} не найдена ");
        return;
      }
      createdTask.Description = update.Message.Text;
      _taskManager.UpdateTask(taskId, createdTask);
    }
  }

  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("3AAE6CD1-5F66-4F66-AFB4-485C4981CA93");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.CreateTask;

  #endregion

  public CreateTaskScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>
    {
      new (ShowEnterTaskName),
      new (CreateTaskName),
      new (FillTaskDescription)
    }.GetEnumerator();
  }
}