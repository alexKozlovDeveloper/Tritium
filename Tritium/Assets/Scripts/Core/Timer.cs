using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core
{
    class Timer
    {
        private float _time;

        public float Time
        {
            get
            {
                return _time;
            }
        }

        public Timer(float time)
        {
            _time = time;
        }

        public bool IsTimeEnd
        {
            get
            {
                return _time <= 0;
            }
        }

        public void AddPassedTime(float delta)
        {
            _time -= delta;
        }

        public void ResetTime(float time)
        {
            _time = time;
        }
    }
}
