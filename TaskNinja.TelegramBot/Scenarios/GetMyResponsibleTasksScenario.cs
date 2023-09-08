using System;
using System.Collections.Generic;
using BotCommon.Scenarios;
using TaskNinja.Core;

namespace TaskNinja.TelegramBot.Scenarios;

public class GetMyResponsibleTasksScenario : AutoStepBotCommandScenarioWithTaskManager
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("A400A6FD-317A-4F2C-B748-4C1940A1AC88");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.GetMyResponsibleTasks;

  #endregion

  public GetMyResponsibleTasksScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}