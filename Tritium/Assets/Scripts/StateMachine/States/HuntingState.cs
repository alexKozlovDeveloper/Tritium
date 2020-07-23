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
    class HuntingState : BaseState
    {
        public static string Name = "Hunting";
        public override string StateName { get { return Name; } }

        private GameObject victim = null;

        public HuntingState(MonoBehaviour target) : base(target)
        {
            Reset();
        }

        public override void Update(MachineContext context)
        {
            IsShoot();
            IsRotate();
            IsMoving();
        }

        private void IsShoot()
        {
            var direction = VectorHelper.DegreeToVector2(_movingController.Angle);
            var size = new Vector2(5, 1);
            var distance = 20f;

            var hits = Physics2D.BoxCastAll(_shootingController.transform.position.ToVector2(), size, 0, direction, distance);

            if(hits.GetFirstHitForLayer(8) != null)
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

        private void IsMoving()
        {
            _movingController.MoveForward();
        }

        public override void CheckTransition(MachineContext context)
        {
            var distanceVector = victim.transform.position - _target.transform.position;
            float distance = distanceVector.sqrMagnitude;

            var halfDistance = Mathf.Sqrt(distance);

            if(halfDistance > 20f)
            {
                context.SetState(MovingState.Name);
            }
        }

        public override void Reset()
        {
            var hits = Physics2D.CircleCastAll(_target.transform.position.ToVector2(), 20, Vector2.up);

            victim = hits.GetFirstHitForLayer(8);            
        }             
    }
}
