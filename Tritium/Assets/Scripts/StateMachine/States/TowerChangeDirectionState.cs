using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine.States
{
    class TowerChangeDirectionState : BaseState
    {
        public static string Name = "TowerChangeDirectionState";
        public override string StateName { get { return Name; } }

        private Timer _timer;
        private bool _direction;

        private readonly Vector2 _rotationTimeRange;

        public TowerChangeDirectionState(MonoBehaviour target, Vector2 rotationTimeRange) : base(target)
        {
            _rotationTimeRange = rotationTimeRange;

            Reset();
        }

        public override void Reset()
        {
            _timer = new Timer(UnityEngine.Random.Range(_rotationTimeRange.x, _rotationTimeRange.y));
            _direction = RandomHelper.RandomBool();
        }

        public override void Update()
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
                context.SetState(TowerHuntingState.Name);
            }
        }
    }
}
