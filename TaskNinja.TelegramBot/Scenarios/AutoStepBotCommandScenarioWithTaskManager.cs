using BotCommon.Scenarios;
using TaskNinja.Core;

namespace TaskNinja.TelegramBot.Scenarios;

public abstract class AutoStepBotCommandScenarioWithTaskManager : AutoStepBotCommandScenario
{
  protected static TaskManager _taskManager;

  public AutoStepBotCommandScenarioWithTaskManager(TaskManager taskManager)
  {
    _taskManager = taskManager;
  }
}