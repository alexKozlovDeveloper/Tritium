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
            Vector2 rotationTimeRange = new Vector2(0.1f, 0.8f);
            Vector2 movingTimeRange = new Vector2(0.7f, 1.8f);
            float huntingDistance = 20f;
            Vector2 shootingBoxCastSize = new Vector2(5, 1);
            float shootingDistance = 20f;

            var states = new List<IState>()
            {
                new MovingState(target, movingTimeRange, huntingDistance),
                new ChangeDirectionState(target, rotationTimeRange),
                new HuntingState(target, shootingBoxCastSize, shootingDistance, huntingDistance),
            };

            var machine = new MachineContext(states, states.First().StateName);

            return machine;
        }

    }
}
