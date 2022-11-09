using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Data.Entities
{
    public class Timer
    {
        /// <summary>
        /// Id of the timer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the timer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Start time of the timer
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Length of timer in seconds
        /// </summary>
        public int DurationInSeconds { get; set; }

        /// <summary>
        /// End time of the timer
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }
    }
}
