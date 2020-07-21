using Assets.Scripts.StateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine.States
{
    class HuntingState : IState
    {
        public static string Name = "Hunting";

        private readonly MonoBehaviour _target;

        public string StateName { get { return Name; } }

        public HuntingState(MonoBehaviour target)
        {
            _target = target;
        }

        public void Update(MachineContext context)
        {

        }

        public void CheckTransition(MachineContext context)
        {

        }

        public void Reset()
        {

        }
    }
}
