using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TG.Abstract;

namespace TG;

public class UnknownTypeHandler : IActionHandler
{
    public UpdateType HandledType { get; init; } = UpdateType.Unknown;

    public async Task Handle(Update data, ITelegramBotClient client)
    {
        Console.WriteLine("this is unknown message handler");
    }
}