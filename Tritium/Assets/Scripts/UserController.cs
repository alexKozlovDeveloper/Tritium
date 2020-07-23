using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingController))]
[RequireComponent(typeof(ShootingController))]
[RequireComponent(typeof(KeyStateController))]
public class UserController : MonoBehaviour
{
    private MovingController _movingController;
    private ShootingController _shootingController;
    private KeyStateController _keyStateController;

    void Start()
    {
        _movingController = GetComponent<MovingController>();
        _shootingController = GetComponent<ShootingController>();
        _keyStateController = GetComponent<KeyStateController>();
    }

    void Update()
    {
        if (_keyStateController[KeyCode.A])
        {
            _movingController.RotateLeft();
        }

        if (_keyStateController[KeyCode.D])
        {
            _movingController.RotateRight();
        }

        if (_keyStateController[KeyCode.W])
        {
            _movingController.MoveForward();
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            _shootingController.Shoot();
        }
    }
}
