using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TG.Abstract;

namespace TG;

public class UpdateHandler : IUpdateHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly HandlerDirector _handlerDirector;

    public UpdateHandler(ITelegramBotClient botClient, HandlerDirector handlerDirector)
    {
        _botClient = botClient;
        this._handlerDirector = handlerDirector;
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        throw exception;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await _handlerDirector[update.Type].Handle(update, _botClient);
    }
}