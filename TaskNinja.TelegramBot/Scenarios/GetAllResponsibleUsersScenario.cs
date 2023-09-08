using System;
using System.Collections.Generic;
using BotCommon.Scenarios;
using TaskNinja.Core;

namespace TaskNinja.TelegramBot.Scenarios;

public class GetAllResponsibleUsersScenario : AutoStepBotCommandScenarioWithTaskManager
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("E44166AC-7BF9-4DB0-839D-7F9D0E1FBA4A");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.GetAllResponsibleUsers;

  #endregion

  public GetAllResponsibleUsersScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}