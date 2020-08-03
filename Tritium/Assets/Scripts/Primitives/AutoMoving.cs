using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoving : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        var velocity = transform.rotation * Vector3.up * speed * Time.deltaTime;

        transform.position += velocity;
    }
}
