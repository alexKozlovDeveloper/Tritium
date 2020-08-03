using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.Entityes
{
    public class StarshipContainer
    {
        public GameObject GameObject { get; private set; }

        public Timer RespawnTimer;
        public HealthController Health
        {
            get
            {
                return GameObject?.GetComponent<HealthController>();
            }
        }

        public StarshipContainer(GameObject starship)
        {
            GameObject = starship;

            RespawnTimer = new Timer();
        }
    }
}
