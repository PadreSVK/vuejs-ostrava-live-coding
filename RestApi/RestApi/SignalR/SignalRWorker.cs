using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Faker;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RestApi.SignalR
{
    public class SignalRWorker : BackgroundService
    {
        private readonly IHubContext<GraphHub, IGraphService> graphHub;
        private readonly ILogger<SignalRWorker> logger;

        public SignalRWorker(IHubContext<GraphHub, IGraphService> aGraphHub, ILogger<SignalRWorker> aLogger)
        {
            graphHub = aGraphHub;
            logger = aLogger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var numbers = Enumerable.Range(0, 15).Select(i => RandomNumber.Next(-5, 80));
                logger.LogInformation("push new data to clients");
                await graphHub.Clients.All.ReceiveGraphData(numbers);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}