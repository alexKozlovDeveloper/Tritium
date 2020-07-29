using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveContainer : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        transform.position = target.transform.position + _offset;
    }
}
