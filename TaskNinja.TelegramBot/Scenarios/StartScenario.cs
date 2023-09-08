using System;
using System.Collections.Generic;
using BotCommon.Scenarios;

namespace TaskNinja.TelegramBot.Scenarios;

public class StartScenario : AutoStepBotCommandScenario
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("99C71A1A-8552-4A2A-9EA0-B04E96AC41B8");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.Start;

  #endregion

  public StartScenario()
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}