using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    public float movingSpeed = 20f;
    public float rotationSpeed = 20f;

    public float decelerationSpeed = 0.35f;

    public float Angle { get; private set; }

    private float _currentSpeed = 0f;

    //private float LowSpeedCoefficient
    //{
    //    get
    //    {
    //        return  Mathf.Clamp(((movingSpeed - CurrentSpeed) / movingSpeed) * 2, 1, 2);
    //    }
    //}

    public float CurrentSpeed
    {
        get
        {
            return _currentSpeed;
        }
        private set
        {
            _currentSpeed = Mathf.Clamp(value, 0, movingSpeed);
        }
    }

    public void RotateRight()
    {
        Angle -= rotationSpeed * Time.deltaTime;// * LowSpeedCoefficient;
    }

    public void RotateLeft()
    {
        Angle += rotationSpeed * Time.deltaTime;// * LowSpeedCoefficient;
    }

    public void MoveForward()
    {
        CurrentSpeed += movingSpeed * Time.deltaTime;
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, Angle);

        var rigidbody = GetComponent<Rigidbody2D>();

        if(rigidbody != null)
        {
            var velocity = transform.rotation * Vector3.up * CurrentSpeed;
            rigidbody.velocity = velocity;
        }

        CurrentSpeed -= movingSpeed * Time.deltaTime * decelerationSpeed;
    }

    private void OnDisable()
    {
        CurrentSpeed = 0f;
    }
}
