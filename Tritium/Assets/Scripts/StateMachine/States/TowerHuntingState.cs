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
    class TowerHuntingState : BaseState
    {
        public static string Name = "TowerHuntingState";
        public override string StateName { get { return Name; } }

        private GameObject victim = null;

        private readonly Vector2 _shootingBoxCastSize;
        private readonly float _huntingDistance;

        public TowerHuntingState(MonoBehaviour target, Vector2 shootingBoxCastSize, float huntingDistance) : base(target)
        {
            _shootingBoxCastSize = shootingBoxCastSize;
            _huntingDistance = huntingDistance;
        }

        public override void Update()
        {
            if (victim == null)
            {
                return;
            }

            IsShoot();
            IsRotate();
        }

        private void IsShoot()
        {
            var direction = VectorHelper.DegreeToVector2(_movingController.Angle);

            var hits = Physics2D.BoxCastAll(_shootingController.transform.position.ToVector2(), _shootingBoxCastSize, 0, direction, _huntingDistance);

            if (hits.GetFirstHitForLayer(Consts.StarshipLayer, _target.gameObject) != null)
            {
                _shootingController.Shoot();
            }
        }

        private void IsRotate()
        {
            var localVictimPos = _target.transform.InverseTransformPoint(victim.transform.position);

            if (localVictimPos.x > 0)
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
            if (victim == null || victim.activeSelf == false)
            {
                context.SetState(TowerHoldOnState.Name);
                return;
            }

            var distanceVector = victim.transform.position - _target.transform.position;
            float distance = Mathf.Sqrt(distanceVector.sqrMagnitude);

            if (distance > _huntingDistance)
            {
                context.SetState(TowerHoldOnState.Name);
                return;
            }
        }

        public override void Reset()
        {
            var hits = Physics2D.CircleCastAll(_target.transform.position.ToVector2(), _huntingDistance, Vector2.up);

            victim = hits.GetFirstHitForLayer(Consts.StarshipLayer, _target.gameObject);
        }
    }
}
