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

        private Timer _timer;
        private bool _direction;

        private readonly Vector2 _rotationTimeRange;

        public ChangeDirectionState(MonoBehaviour target, Vector2 rotationTimeRange) : base(target)
        {
            _rotationTimeRange = rotationTimeRange;

            Reset();
        }

        public override void Reset()
        {
            _timer = new Timer(UnityEngine.Random.Range(_rotationTimeRange.x, _rotationTimeRange.y));
            _direction = RandomHelper.RandomBool();
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
        }

        public override void CheckTransition(MachineContext context)
        {
            if (_timer.IsTimeEnd)
            {
                context.SetState(MovingState.Name);
            }
        }
    }
}
