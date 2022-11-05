using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TG.Abstract;

namespace TG;

public class DefaultMessageHandler : IActionHandler
{
    public UpdateType HandledType { get; init; } = UpdateType.Message;

    public async Task Handle(Update data, ITelegramBotClient client)
    {
        await client.SendTextMessageAsync(
            data.Message!.Chat.Id,
            "hello!",
            replyToMessageId: data.Message.MessageId
            );
        Console.WriteLine("this is a default message handler says hi to you");
    }
}