using Assets.Scripts.StateMachine;
using Assets.Scripts.StateMachine.Interfaces;
using Assets.Scripts.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MovingController))]
[RequireComponent(typeof(HealthController))]
[RequireComponent(typeof(ShootingController))]
public class TowerController : MonoBehaviour
{
    [SerializeField] private Vector2 rotationTimeRange = new Vector2(0.3f, 0.8f);
    [SerializeField] private Vector2 holdOnTimeRange = new Vector2(0.7f, 1.8f);
    [SerializeField] private float huntingDistance = 20f;
    [SerializeField] private Vector2 shootingBoxCastSize = new Vector2(5, 1);

    private MachineContext stateMachine;

    private HealthController healthController;

    void Start()
    {
        healthController = GetComponent<HealthController>();

        var states = new List<IState>()
        {
            new TowerHoldOnState(this, holdOnTimeRange, huntingDistance),
            new TowerHuntingState(this, shootingBoxCastSize, huntingDistance),
            new TowerChangeDirectionState(this, rotationTimeRange),            
        };

        stateMachine = new MachineContext(states, states.First().StateName);
    }

    void Update()
    {
        stateMachine.Update();

        if (healthController.IsDead)
        {
            this.gameObject.SetActive(false);
        }
    }
}
