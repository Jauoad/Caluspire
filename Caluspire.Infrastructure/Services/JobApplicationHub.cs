using Microsoft.AspNetCore.SignalR;

namespace Caluspire.Infrastructure.Services
{
    public class JobApplicationHub : Hub
    {
        public async Task SendJobApplicationStatus(int candidateId, string status)
        {
            await Clients.All.SendAsync("ReceiveJobApplicationStatus", candidateId, status);
        }
    }
}
