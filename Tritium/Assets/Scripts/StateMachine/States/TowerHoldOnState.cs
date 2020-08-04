using Assets.Scripts.Core;
using Assets.Scripts.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine.States
{
    class TowerHoldOnState : BaseState
    {
        public static string Name = "TowerHoldOn";
        public override string StateName { get { return Name; } }

        private Timer _timer;

        private readonly Vector2 _holdOnTimeRange;
        private readonly float _huntingDistance;

        public TowerHoldOnState(MonoBehaviour target, Vector2 holdOnTimeRange, float huntingDistance) : base(target)
        {
            _holdOnTimeRange = holdOnTimeRange;
            _huntingDistance = huntingDistance;

            Reset();
        }

        public override void Reset()
        {
            _timer = new Timer(UnityEngine.Random.Range(_holdOnTimeRange.x, _holdOnTimeRange.y));
        }

        public override void Update()
        {
            _timer.AddPassedTime(Time.deltaTime);
        }

        public override void CheckTransition(MachineContext context)
        {
            var hits = Physics2D.CircleCastAll(_movingController.transform.position.ToVector2(), _huntingDistance, Vector2.up);

            if (hits.GetFirstHitForLayer(Consts.StarshipLayer, _target.gameObject) != null)
            {
                context.SetState(TowerHuntingState.Name);
                return;
            }

            if (_timer.IsTimeEnd)
            {
                context.SetState(TowerChangeDirectionState.Name);
                return;
            }
        }
    }
}
