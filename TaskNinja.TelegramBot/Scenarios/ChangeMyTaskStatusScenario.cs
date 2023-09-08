using System;
using System.Collections.Generic;
using BotCommon.Scenarios;
using TaskNinja.Core;

namespace TaskNinja.TelegramBot.Scenarios;

public class ChangeMyTaskStatusScenario : AutoStepBotCommandScenarioWithTaskManager
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("6D6412F4-00B9-43EC-B8B7-2D4EF9771F6D");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.ChangeMyTaskStatus;

  #endregion

  public ChangeMyTaskStatusScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}