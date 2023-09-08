using System;
using System.Collections.Generic;
using BotCommon.Scenarios;
using TaskNinja.Core;

namespace TaskNinja.TelegramBot.Scenarios;

public class GetMyCreatedTasksScenario : AutoStepBotCommandScenarioWithTaskManager
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("CBE879E2-BADB-4057-B77C-08621F3EB9E6");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.GetMyCreatedTasks;

  #endregion

  public GetMyCreatedTasksScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}