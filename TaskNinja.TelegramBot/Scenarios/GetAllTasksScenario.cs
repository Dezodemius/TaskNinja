using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BotCommon.Scenarios;
using TaskNinja.Core;
using Telegram.Bot;
using Telegram.Bot.Types;
using Task = System.Threading.Tasks.Task;

namespace TaskNinja.TelegramBot.Scenarios;

public class GetAllTasksScenario : AutoStepBotCommandScenarioWithTaskManager
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("1387934F-068C-422F-89E7-09B43C99EC2A");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.GetAllTasks;

  #endregion

  private static async Task GetAllTasks(ITelegramBotClient bot, Update update, long chatId)
  {
    var allTaskBuilder = new StringBuilder();
    var allTasks = _taskManager.GetAll();
    if (!allTasks.Any())
    {
      await bot.SendTextMessageAsync(chatId, "Пока задач нет");
      return;
    }
    foreach (var task in allTasks)
    {
      allTaskBuilder.AppendLine($"{task.ToString()}");
      allTaskBuilder.AppendLine();
    }
    await bot.SendTextMessageAsync(chatId, allTaskBuilder.ToString());
  }

  public GetAllTasksScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>()
    {
      new (GetAllTasks)
    }.GetEnumerator();
  }
}