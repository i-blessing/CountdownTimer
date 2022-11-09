using CountdownTimer.Data.Entities;
using System.Collections.Generic;

namespace CountdownTimer.Data.Repository
{
    public interface ITimerRepository
    {
        List<Timer> GetAll();
        void StartTimer(int id);
        void StopTimer(int id);
        Timer GetTimer(int id);
        void UpdateTimer(int id, Timer timer);
    }
}