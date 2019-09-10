using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace api.SignalR
{
    public class Notification : Hub<INotification> { }

    public interface INotification
    {
        Task BroadcastActualite(object o);
    }
}
