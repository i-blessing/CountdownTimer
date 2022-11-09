using CountdownTimer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Data.Repository
{
    public class TimerRepository : ITimerRepository
    {
        private readonly List<Timer> _items;

        public TimerRepository()
        {
            _items = new List<Timer>();
            var utcDateTime = DateTime.UtcNow;
            _items.Add(new Timer { Id = 1, Name = "Timer 1", DurationInSeconds = 120 });
            _items.Add(new Timer { Id = 1, Name = "Timer 2", DurationInSeconds = 30 });
            _items.Add(new Timer { Id = 1, Name = "Timer 3", DurationInSeconds = 259200 });
        }

        public List<Timer> GetAll()
        {
            return _items;
        }

        public Timer GetTimer(int id)
        {
            return _items.Find(i => i.Id == id);
        }

        public void StartTimer(int id)
        {
            var timer = _items.FirstOrDefault(x => x.Id == id);

            if (timer == null)
            {
                throw new ArgumentException("Invalid timer id.");
            }

            timer.StartTime = DateTime.UtcNow;
        }

        public void StopTimer(int id)
        {
            var timer = _items.FirstOrDefault(x => x.Id == id);

            if (timer == null)
            {
                throw new ArgumentException("Invalid timer id.");
            }

            timer.EndTime = DateTime.UtcNow;
        }

        public void UpdateTimer(int id, Timer timer)
        {
            var oldTimer = _items.FirstOrDefault(x => x.Id == id);

            if (oldTimer == null)
            {
                throw new ArgumentException("Invalid timer id.");
            }

            _items.Remove(oldTimer);
            _items.Add(timer);
        }
    }
}
