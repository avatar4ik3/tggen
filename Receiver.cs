using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TG.Abstract;

namespace TG;

public class Receiver : IReceiver
{
    private readonly ITelegramBotClient _botClient;
    private readonly IUpdateHandler _updateHandler;

    public Receiver(
        ITelegramBotClient botClient,
        IUpdateHandler updateHandler
    )
    {
        this._botClient = botClient;
        this._updateHandler = updateHandler;
    }
    public async Task Receive()
    {
        // ToDo: we can inject ReceiverOptions through IOptions container
        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = null,
            ThrowPendingUpdates = false,
        };

        // Start receiving updates
        await _botClient.ReceiveAsync(
            updateHandler: _updateHandler,
            receiverOptions: receiverOptions);
    }
}