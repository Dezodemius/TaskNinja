using System;
using System.Collections.Generic;
using BotCommon.Scenarios;
using TaskNinja.Core;

namespace TaskNinja.TelegramBot.Scenarios;

public class DeleteMyTaskScenario : AutoStepBotCommandScenarioWithTaskManager
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("CD8D294B-2914-464A-839E-CFB8F9FB18E5");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.DeleteMyTask;

  #endregion

  public DeleteMyTaskScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}