using CountdownTimer.Business.ApiResponses;
using System;
using System.Deployment.Internal;
using System.Threading.Tasks;

namespace CountdownTimer.Services
{
    public interface ITimerService
    {
        GetTimersResponse GetTimers();
        void EndTimer(int id);
        void StartTimer(int id);
    }
}