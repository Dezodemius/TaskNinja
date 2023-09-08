using System.Threading;
using BotCommon;
using BotCommon.Scenarios;
using NLog;
using TaskNinja.Core;
using TaskNinja.TelegramBot.Scenarios;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TaskNinja.TelegramBot;

public class TaskNinjaBotUpdateHandler : BotUpdateHandler
{
  private readonly ILogger log = LogManager.GetCurrentClassLogger();
  private TaskManager _taskManager;

  protected override void HandleUpdate(ITelegramBotClient bot, Update update, ref UserCommandScenario scenario, CancellationToken cancellationToken)
  {
    var userId = this.GetUserId(update);

    switch (this.GetMessage(update))
    {
      case TaskNinjaBotChatCommand.Start:
      {
        scenario = new UserCommandScenario(userId, new StartScenario());
        break;
      }
      case TaskNinjaBotChatCommand.MainMenu:
      {
        scenario = new UserCommandScenario(userId, new MainMenuScenario());
        break;
      }
      case TaskNinjaBotChatCommand.GetMyCreatedTasks:
      {
        scenario = new UserCommandScenario(userId, new GetMyCreatedTasksScenario(_taskManager));
        break;
      }
      case TaskNinjaBotChatCommand.GetMyResponsibleTasks:
      {
        scenario = new UserCommandScenario(userId, new GetMyResponsibleTasksScenario(_taskManager));
        break;
      }
      case TaskNinjaBotChatCommand.GetAllTasks:
      {
        scenario = new UserCommandScenario(userId, new GetAllTasksScenario(_taskManager));
        break;
      }
      case TaskNinjaBotChatCommand.GetAllResponsibleUsers:
      {
        scenario = new UserCommandScenario(userId, new GetAllResponsibleUsersScenario(_taskManager));
        break;
      }
      case TaskNinjaBotChatCommand.CreateTask:
      {
        scenario = new UserCommandScenario(userId, new CreateTaskScenario(_taskManager));
        break;
      }
      case TaskNinjaBotChatCommand.DeleteMyTask:
      {
        scenario = new UserCommandScenario(userId, new DeleteMyTaskScenario(_taskManager));
        break;
      }
      case TaskNinjaBotChatCommand.ChangeMyTaskStatus:
      {
        scenario = new UserCommandScenario(userId, new ChangeMyTaskStatusScenario(_taskManager));
        break;
      }
      case TaskNinjaBotChatCommand.AddTaskComment:
      {
        scenario = new UserCommandScenario(userId, new AddTaskCommentScenario(_taskManager));
        break;
      }
    }
  }

  public TaskNinjaBotUpdateHandler() : base()
  {
    this._taskManager = new TaskManager(_configManager.Config.DbConnectionString);
  }
}