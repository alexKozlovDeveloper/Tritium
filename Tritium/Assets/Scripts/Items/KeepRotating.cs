using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotating : MonoBehaviour
{
    [SerializeField] private Transform target;


    void LateUpdate()
    {
        transform.rotation = target.rotation;
    }
}
