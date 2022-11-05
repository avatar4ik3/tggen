// See https://aka.ms/new-console-template for more information
using TG;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TG.Abstract;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<BotConfiguration>(
            context.Configuration.GetSection(BotConfiguration.Configuration));

        services.AddHttpClient("telegram_bot_client")
               .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
               {
                   BotConfiguration? botConfig = sp.GetConfiguration<BotConfiguration>();
                   TelegramBotClientOptions options = new(botConfig.BotToken);
                   return new TelegramBotClient(options, httpClient);
               });
        services.AddSingleton<HandlerDirector>();
        services.AddSingleton<IUpdateHandler, UpdateHandler>();
        services.AddSingleton<IReceiver, Receiver>();
        services.AddHostedService<PollingService>();
    })
    .Build();

await host.RunAsync();

public class BotConfiguration
{
    public static readonly string Configuration = "BotConfiguration";

    public string BotToken { get; set; } = "";
}