using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TG.Abstract;

public interface IActionHandler
{
    public UpdateType HandledType { get; init; }
    public Task Handle(Update data, ITelegramBotClient client);
}