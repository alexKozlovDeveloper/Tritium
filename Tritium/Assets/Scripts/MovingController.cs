using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 20f;
    [SerializeField] private float rotationSpeed = 20f;

    [SerializeField] private float decelerationSpeed = 0.35f;

    private float angle = 0f;
    private float currentSpeed = 0f;

    public void RotateRight()
    {
        angle -= rotationSpeed * Time.deltaTime;
    }

    public void RotateLeft()
    {
        angle += rotationSpeed * Time.deltaTime;
    }

    public void MoveForward()
    {
        currentSpeed += movingSpeed * Time.deltaTime;        
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, angle);

        currentSpeed = Mathf.Clamp(currentSpeed, 0, movingSpeed);        

        var velocity = transform.rotation * Vector3.up * currentSpeed * Time.deltaTime;

        transform.position += velocity;

        currentSpeed -= movingSpeed * Time.deltaTime * decelerationSpeed;
    }
}
