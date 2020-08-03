using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRotateToAngle : MonoBehaviour
{
    public float angle = 0;

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, angle);        
    }
}
