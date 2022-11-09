using CountdownTimer.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Business.ApiResponses
{
    public class GetTimersResponse
    {
        public List<Timer> Timers { get; set; }
    }
}
