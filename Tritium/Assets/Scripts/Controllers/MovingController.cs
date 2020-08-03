using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 20f;
    [SerializeField] private float rotationSpeed = 20f;

    [SerializeField] private float decelerationSpeed = 0.35f;

    public float Angle { get; private set; }

    private float _currentSpeed = 0f;
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

        var velocity = transform.rotation * Vector3.up * CurrentSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;      

        CurrentSpeed -= movingSpeed * Time.deltaTime * decelerationSpeed;
    }

    private void OnDisable()
    {
        CurrentSpeed = 0f;
    }
}
