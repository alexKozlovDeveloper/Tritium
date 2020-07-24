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
    class HuntingState : BaseState
    {
        public static string Name = "Hunting";
        public override string StateName { get { return Name; } }

        private GameObject victim = null;

        private readonly Vector2 _shootingBoxCastSize;
        private readonly float _shootingDistance;
        private readonly float _huntingDistance;

        public HuntingState(MonoBehaviour target, Vector2 shootingBoxCastSize, float shootingDistance, float huntingDistance) : base(target)
        {
            _shootingBoxCastSize = shootingBoxCastSize;
            _shootingDistance = shootingDistance;
            _huntingDistance = huntingDistance;

            //Reset();
        }

        public override void Update()
        {
            IsShoot();
            IsRotate();
            IsMoving();
        }

        private void IsShoot()
        {
            var direction = VectorHelper.DegreeToVector2(_movingController.Angle);

            var hits = Physics2D.BoxCastAll(_shootingController.transform.position.ToVector2(), _shootingBoxCastSize, 0, direction, _shootingDistance);

            if(hits.GetFirstHitForLayer(Consts.HeroLayer) != null)
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
            float distance = Mathf.Sqrt(distanceVector.sqrMagnitude);

            if(distance > _huntingDistance)
            {
                //Debug.Log($"HuntingState far distance, go to Moving State");
                context.SetState(MovingState.Name);
            }

            //Debug.Log($"HuntingState Distance: '{distance}'");
        }

        public override void Reset()
        {
            var hits = Physics2D.CircleCastAll(_target.transform.position.ToVector2(), _huntingDistance, Vector2.up);

            victim = hits.GetFirstHitForLayer(Consts.HeroLayer);   
            
            //if(victim != null)
            //{
                //Debug.Log($"Hunting reset, found an enemy '{victim.gameObject.name}'");
            //}
        }             
    }
}
