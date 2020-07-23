using Assets.Scripts.Core;
using Assets.Scripts.StateMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.StateMachine.States
{
    class ChangeDirectionState : BaseState
    {
        public static string Name = "ChangeDirection";
        public override string StateName { get { return Name; } }

        //private readonly MovingController _movingController;        

        private Timer _timer;
        private bool _direction;

        public ChangeDirectionState(MonoBehaviour target) : base(target)
        {
            //_movingController = movingController;

            Reset();
        }

        public override void Reset()
        {
            _timer = new Timer(UnityEngine.Random.Range(0.1f, 0.8f));
            _direction = UnityEngine.Random.Range(0f, 1f) > 0.5f;

            //Debug.Log($"Reset {Name}, Timer: {_timer.Time}, direction: {_direction}");
        }

        public override void Update(MachineContext context)
        {
            _timer.AddPassedTime(Time.deltaTime);

            if (_direction)
            {
                _movingController.RotateRight();
            }
            else
            {
                _movingController.RotateLeft();
            }

            //Debug.Log($"State {Name}, Timer: {_timer.Time}, direction: {_direction}");
        }

        public override void CheckTransition(MachineContext context)
        {
            if (_timer.IsTimeEnd)
            {
                context.SetState(MovingState.Name);
                //context.SetState(HuntingState.Name);
            }
        }
    }
}
