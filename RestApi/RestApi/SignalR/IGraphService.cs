using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.SignalR
{
    public interface IGraphService
    {
        Task ReceiveGraphData(IEnumerable<int> numbers);
    }
}