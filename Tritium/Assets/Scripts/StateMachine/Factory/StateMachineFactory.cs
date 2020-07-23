using Assets.Scripts.StateMachine.Interfaces;
using Assets.Scripts.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine.Factory
{
    class StateMachineFactory
    {
        public static MachineContext GetEnemyMachine(MonoBehaviour target)
        {
            var states = new List<IState>()
            {
                new MovingState(target),
                new ChangeDirectionState(target),
                new HuntingState(target),                
            };

            var machine = new MachineContext(states, states.First().StateName);

            return machine;
        }

    }
}
