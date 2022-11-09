using CountdownTimer.Business.ApiResponses;
using CountdownTimer.Data;
using CountdownTimer.Data.Entities;
using CountdownTimer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Services
{
    public class TimerService : ITimerService
    {
        private readonly ITimerRepository _timerRepository;

        public TimerService(ITimerRepository timerRepository)
        {
            _timerRepository = timerRepository;
        }

        public GetTimersResponse GetTimers()
        {
            var response = new GetTimersResponse();
            var timers = _timerRepository.GetAll();

            response.Timers = timers.Select(t => new Business.Dto.Timer { Id = t.Id, Name = t.Name, StartTime = t.StartTime, EndTime = t.EndTime, Duration = t.DurationInSeconds, IsRunning = IsTimerRunning(t) }).ToList();

            return response;            
        }        

        public void EndTimer(int id)
        {
            var timer = _timerRepository.GetTimer(id);

            if (timer == null)
            {
                throw new ArgumentException($"Invalid timer id {id}", nameof(id));
            }

            timer.EndTime = DateTimeOffset.UtcNow;

            _timerRepository.UpdateTimer(id, timer);
        }

        public void StartTimer(int id)
        {
            var timer = _timerRepository.GetTimer(id);

            if (timer == null)
            {
                throw new ArgumentException($"Invalid timer id {id}", nameof(id));
            }

            timer.StartTime = DateTimeOffset.UtcNow;

            _timerRepository.UpdateTimer(id, timer);
        }

        private bool IsTimerRunning(Timer t)
        {
            return t.StartTime.HasValue && t.StartTime.Value.UtcDateTime <= DateTime.UtcNow && !t.EndTime.HasValue;
        }
    }
}
