using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TG.Abstract;

namespace TG;

public class PollingService : BackgroundService
{
    private readonly IReceiver _receiver;

    public PollingService(IReceiver receiver)
    {
        this._receiver = receiver;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested is false)
        {
            await _receiver.Receive();
        }
    }
}