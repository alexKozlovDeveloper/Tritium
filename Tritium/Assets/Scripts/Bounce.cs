using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
    }
}
