using System;
using System.Collections.Generic;
using BotCommon.Scenarios;
using TaskNinja.Core;

namespace TaskNinja.TelegramBot.Scenarios;

public class AddTaskCommentScenario : AutoStepBotCommandScenarioWithTaskManager
{
  #region Overrides of BotCommandScenario

  public override Guid Id => new Guid("5853B43B-4970-4D5B-80A4-DD34F3648462");
  public override string ScenarioCommand => TaskNinjaBotChatCommand.AddTaskComment;

  #endregion

  public AddTaskCommentScenario(TaskManager taskManager) : base(taskManager)
  {
    this.steps = new List<BotCommandScenarioStep>()
    {

    }.GetEnumerator();
  }
}