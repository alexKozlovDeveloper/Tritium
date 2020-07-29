using Assets.Scripts.StateMachine;
using Assets.Scripts.StateMachine.Factory;
using Assets.Scripts.StateMachine.Interfaces;
using Assets.Scripts.StateMachine.States;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingController))]
[RequireComponent(typeof(ShootingController))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Vector2 rotationTimeRange = new Vector2(0.3f, 0.8f);
    [SerializeField] private Vector2 movingTimeRange = new Vector2(0.7f, 1.8f);
    [SerializeField] private float huntingDistance = 20f;
    [SerializeField] private Vector2 shootingBoxCastSize = new Vector2(5, 1);
    [SerializeField] private float shootingDistance = 20f;

    private MachineContext stateMachine;

    void Start()
    {
        //stateMachine = StateMachineFactory.GetEnemyMachine(this);

        var states = new List<IState>()
        {
            new MovingState(this, movingTimeRange, huntingDistance),
            new ChangeDirectionState(this, rotationTimeRange),
            new HuntingState(this, shootingBoxCastSize, shootingDistance, huntingDistance),
        };

        stateMachine = new MachineContext(states, states.First().StateName);
    }
    
    void Update()
    {
        stateMachine.Update();
    }
}
