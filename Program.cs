using System.ComponentModel;
using System.Diagnostics;

namespace Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            VisualClock clock = new VisualClock(time);
            clock.ShowTime();
        }
    }
}
