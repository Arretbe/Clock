using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class VisualClock
    {
        private TimeOnly time;

        public VisualClock(TimeOnly time)
        {
            this.time = time;
        }

        public void ShowTime()
        {
            while (true)
            {
                time = TimeOnly.FromDateTime(DateTime.Now);
                Draw();
                Thread.Sleep(1000);
            }
        }

        private void Draw()
        {
            Console.Clear();
            int radius = 10;
            int centerX = 20;
            int centerY = 10;

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    if (x * x + y * y <= radius * radius)
                    {
                        Console.SetCursorPosition(centerX + x, centerY + y);
                    }
                }
            }

            DrawHand(centerX, centerY, radius - 1, time.Hour % 12 * 30, time.Hour);
            DrawHand(centerX, centerY, radius, time.Minute * 6, time.Minute);
            DrawHand(centerX, centerY, radius, time.Second * 6, time.Second);
        }

        private void DrawHand(int centerX, int centerY, int length, int angle, int timeValue)
        {
            double radian = Math.PI * angle / 180.0;
            for (int i = 1; i <= length; i++)
            {
                int x = (int)(centerX + i * Math.Sin(radian));
                int y = (int)(centerY - i * Math.Cos(radian));

                Console.SetCursorPosition(x, y);
                Console.Write(timeValue);
            }
        }
    }
}
