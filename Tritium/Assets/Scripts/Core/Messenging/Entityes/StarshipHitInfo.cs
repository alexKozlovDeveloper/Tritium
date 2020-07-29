using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Messenging.Entityes
{
    class StarshipHitInfo
    {
        public GameObject Victim { get; set; }
        public GameObject DamageDealer { get; set; }
        public float Damage { get; set; }
    }
}
