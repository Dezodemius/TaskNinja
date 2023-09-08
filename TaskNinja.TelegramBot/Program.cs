using System.Threading;
using BotCommon;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace TaskNinja.TelegramBot;

public class Program
{
  public static void Main(string[] args)
  {
    var cancellationTokenSource = new CancellationTokenSource();
    var botOptions = new ReceiverOptions
    {
        AllowedUpdates = new []
        {
            UpdateType.Message,
            UpdateType.CallbackQuery
        },
        ThrowPendingUpdates = true
    };
    BotRunner.Run<TaskNinjaBotUpdateHandler>(
      botToken: new BotConfigManager().Config.BotToken,
      botOptions: botOptions,
      cancellationToken: cancellationTokenSource.Token);
  }
}