using Assets.Scripts.StateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine.States
{
    abstract class BaseState : IState
    {
        public abstract string StateName { get; }

        protected MonoBehaviour _target;

        protected readonly MovingController _movingController;
        protected readonly ShootingController _shootingController;

        public BaseState(MonoBehaviour target)
        {
            _target = target;

            _movingController = _target.GetComponent<MovingController>();
            _shootingController = _target.GetComponent<ShootingController>();
        }

        public abstract void CheckTransition(MachineContext context);
        public abstract void Reset();
        public abstract void Update(MachineContext context);
    }
}
