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
    class MovingState : BaseState
    {
        public static string Name = "Moving";
        public override string StateName { get { return Name; } }

        private Timer _timer;

        public MovingState(MonoBehaviour target) : base(target)
        {
            Reset();
        }

        public override void Reset()
        {
            _timer = new Timer(UnityEngine.Random.Range(0.7f, 1.8f));
        }

        public override void Update(MachineContext context)
        {
            _timer.AddPassedTime(Time.deltaTime);

            _movingController.MoveForward();
        }

        public override void CheckTransition(MachineContext context)
        {
            var results = Physics2D.CircleCastAll(_movingController.transform.position.ToVector2(), 20, Vector2.up);

            foreach (var item in results)
            {
                if (item.collider != null)
                {
                    if (item.collider.gameObject.layer == 8)
                    {
                        context.SetState(HuntingState.Name);
                    }
                }
            }

            if (_timer.IsTimeEnd)
            {
                context.SetState(ChangeDirectionState.Name);
            }
        }
    }
}
