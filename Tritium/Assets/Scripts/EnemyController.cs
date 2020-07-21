using Assets.Scripts.StateMachine;
using Assets.Scripts.StateMachine.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingController))]
public class EnemyController : MonoBehaviour
{
    private MovingController _movingController;

    private MachineContext stateMachine;

    void Start()
    {
        _movingController = GetComponent<MovingController>();

        stateMachine = StateMachineFactory.GetEnemyMachine(this);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
