using System;
using System.Collections.Generic;
using BotCommon.Scenarios;

namespace TaskNinja.TelegramBot.Scenarios;

public class MainMenuScenario : AutoStepBotCommandScenario
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("7E448FC5-7E45-40EF-9BD1-A369E9E722A2");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.MainMenu;

  #endregion

  public MainMenuScenario()
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}