using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 20f;
    [SerializeField] private float rotationSpeed = 20f;

    [SerializeField] private float decelerationSpeed = 0.35f;

    public float Angle { get; private set; }
    public float CurrentSpeed { get; private set; }

    public void RotateRight()
    {
        Angle -= rotationSpeed * Time.deltaTime;
    }

    public void RotateLeft()
    {
        Angle += rotationSpeed * Time.deltaTime;
    }

    public void MoveForward()
    {
        CurrentSpeed += movingSpeed * Time.deltaTime;
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, Angle);

        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0, movingSpeed);

        var velocity = transform.rotation * Vector3.up * CurrentSpeed * Time.deltaTime;

        transform.position += velocity;

        CurrentSpeed -= movingSpeed * Time.deltaTime * decelerationSpeed;

        //Debug.Log($"Moving angle {Angle}");
    }
}
