using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    public float speed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        var velocity = transform.rotation * Vector3.up * speed * Time.deltaTime;

        transform.position += velocity;
    }
}
