using Example.SingletonAndHostedService.Api.Models;

namespace Example.SingletonAndHostedService.Api.Services;
public interface IMyInMemorySingletonService
{
    MyChart? GetMyChartCache();
    void SetMyChartCache(MyChart chart);
}
public class MyInMemorySingletonService : IMyInMemorySingletonService
{
    private MyChart? MyChartCache;

    public MyChart? GetMyChartCache()
    {
        return MyChartCache;
    }

    public void SetMyChartCache(MyChart? chart)
    {
        MyChartCache = chart;
    }
}
