using Microsoft.AspNetCore.SignalR;

namespace Caluspire.Infrastructure.Services
{
    public class JobApplicationNotifier
    {
        private readonly IHubContext<JobApplicationHub> _hubContext;

        public JobApplicationNotifier(IHubContext<JobApplicationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyApplicationStatus(int candidateId, string status)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveJobApplicationStatus", candidateId, status);
        }

        public async Task NotifyApplicationStatusToCandidate(int candidateId, string status)
        {
            await _hubContext.Clients.User(candidateId.ToString()).SendAsync("ReceiveJobApplicationStatus", status);
        }
    }
}
