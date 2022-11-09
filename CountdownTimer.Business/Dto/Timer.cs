using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Business.Dto
{
    public class Timer
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public bool IsRunning { get; set; }
        public int Duration { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
    }
}
