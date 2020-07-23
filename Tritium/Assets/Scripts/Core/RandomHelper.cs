using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core
{
    public static class RandomHelper
    {
        public static bool RandomBool()
        {
            return UnityEngine.Random.Range(0, 2) == 1;
        }
    }
}
