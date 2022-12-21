using Example.SingletonAndHostedService.Api.Models;
using Example.SingletonAndHostedService.Api.Services;

namespace Example.SingletonAndHostedService.Api.Workers;
public class MyHostedBackroundWorker : BackgroundService
{
    private readonly IMyInMemorySingletonService _myInMemorySingletonService;

    public MyHostedBackroundWorker(IMyInMemorySingletonService myInMemorySingletonService)
    {
        _myInMemorySingletonService = myInMemorySingletonService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        do
        {
            MyChart myChart = new MyChart
            {
                SomeData = Random.Shared.Next(0, 100),
            };

            _myInMemorySingletonService.SetMyChartCache(myChart);

            //run every minute
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
        while (!stoppingToken.IsCancellationRequested);
    }
}
