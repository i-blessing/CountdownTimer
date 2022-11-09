using CountdownTimer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Data
{
    public class CountdownTimerDbContext : DbContext
    {
        public CountdownTimerDbContext()
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Timer> Timers { get; set; }
    }
}
