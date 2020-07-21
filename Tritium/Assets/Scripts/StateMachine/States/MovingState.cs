using Assets.Scripts.Core;
using Assets.Scripts.StateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine.States
{
    class MovingState : IState
    {
        public static string Name = "Moving";
        public string StateName { get { return Name; } }

        private Timer _timer;

        private MovingController _movingController;

        public MovingState(MovingController movingController)
        {
            _movingController = movingController;

            Reset();
        }

        public void Reset()
        {         
            _timer = new Timer(UnityEngine.Random.Range(0.7f, 1.8f));

            Debug.Log($"Reset {Name}, Timer: {_timer.Time}");
        }

        public void Update(MachineContext context)
        {
            _timer.AddPassedTime(Time.deltaTime);

            _movingController.MoveForward();

            Debug.Log($"State {Name}, Timer: {_timer.Time}");
        }

        public void CheckTransition(MachineContext context)
        {
            if (_timer.IsTimeEnd)
            {
                context.SetState(ChangeDirectionState.Name);
            }
        }
    }
}
