using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core
{
    public class Timer
    {
        public float Time { get; private set; }

        public Timer(float time)
        {
            Time = time;
        }

        public Timer()
        {
            Time = 0f;
        }

        public bool IsTimeEnd
        {
            get
            {
                return Time <= 0;
            }
        }

        public void AddPassedTime(float delta)
        {
            Time -= delta;
        }

        public void ResetTime(float time)
        {
            Time = time;
        }
    }
}
