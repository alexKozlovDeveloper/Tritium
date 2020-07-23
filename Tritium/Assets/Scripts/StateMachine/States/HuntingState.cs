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

        //private readonly ShootingController _shootingController;

        private GameObject victim = null;

        //private Timer _timer;

        public HuntingState(MonoBehaviour target) : base(target)
        {
            //_shootingController = shootingController;

            Reset();
        }

        public override void Update(MachineContext context)
        {
            // _timer.AddPassedTime(Time.deltaTime);

            //_shootingController.Shoot();

            var result2 = Physics2D.BoxCast(_shootingController.transform.position.ToVector2(), new Vector2(5, 1), 0, VectorHelper.DegreeToVector2(_movingController.Angle), 20f);

            if (result2.collider != null)
            {
                _shootingController.Shoot();

                //Debug.Log($"Hit object '{result.collider.gameObject.name}' layer '{LayerMask.LayerToName(result.collider.gameObject.layer)}'");
            }


            var localVictimPos = _target.transform.InverseTransformPoint(victim.transform.position);

            //var distanceVector =  - ;

            Debug.Log($"localVictimPos: {localVictimPos}");

            if(localVictimPos.x > 0)
            {
                _movingController.RotateRight();
            }
            else
            {
                _movingController.RotateLeft();
            }

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

            //Debug.Log($"Distance: {distance}:half-{halfDistance}[{distanceVector}] pos: '{_target.transform.position}' victim: '{victim.transform.position}'");

            //if (_timer.IsTimeEnd)
            //{
            //    context.SetState(MovingState.Name);
            //}


        }

        public override void Reset()
        {
            //_timer = new Timer(UnityEngine.Random.Range(0.7f, 1.1f));

            var results = Physics2D.CircleCastAll(_shootingController.transform.position.ToVector2(), 20, Vector2.up);

            foreach (var item in results)
            {
                if (item.collider != null)
                {
                    if (item.collider.gameObject.layer == 8)
                    {
                        victim = item.collider.gameObject;
                    }
                }
            }
        }
    }
}
