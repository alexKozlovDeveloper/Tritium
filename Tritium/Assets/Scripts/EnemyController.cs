using Assets.Scripts.StateMachine;
using Assets.Scripts.StateMachine.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingController))]
[RequireComponent(typeof(ShootingController))]
public class EnemyController : MonoBehaviour
{
    private MovingController _movingController;
    private ShootingController _shootingController;

    private MachineContext stateMachine;

    void Start()
    {
        _movingController = GetComponent<MovingController>();
        _shootingController = GetComponent<ShootingController>();

        stateMachine = StateMachineFactory.GetEnemyMachine(this);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
