using Assets.Scripts.Core;
using Assets.Scripts.Core.Constants;
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

        private readonly Vector2 _movingTimeRange;
        private readonly float _huntingDistance;

        public MovingState(MonoBehaviour target, Vector2 movingTimeRange, float huntingDistance) : base(target)
        {
            _movingTimeRange = movingTimeRange;
            _huntingDistance = huntingDistance;

            Reset();
        }

        public override void Reset()
        {
            _timer = new Timer(UnityEngine.Random.Range(_movingTimeRange.x, _movingTimeRange.y));
        }

        public override void Update()
        {
            _timer.AddPassedTime(Time.deltaTime);

            _movingController.MoveForward();
        }

        public override void CheckTransition(MachineContext context)
        {
            var hits = Physics2D.CircleCastAll(_movingController.transform.position.ToVector2(), _huntingDistance, Vector2.up);

            if(hits.GetFirstHitForLayer(Consts.StarshipLayer, _target.gameObject) != null)
            {
                context.SetState(HuntingState.Name);
                return;
            }

            //foreach (var item in results)
            //{
            //    if (item.collider != null)
            //    {
            //        if (item.collider.gameObject.layer == Consts.StarshipLayer)
            //        {
            //            //Debug.Log($"MovingState found a anemy, go to Hunting State");
            //            context.SetState(HuntingState.Name);
            //            return;
            //        }
            //    }
            //}



            if (_timer.IsTimeEnd)
            {
                //Debug.Log($"MovingState time si over, go to ChangeDirection State");
                context.SetState(ChangeDirectionState.Name);
                return;
            }
        }
    }
}
