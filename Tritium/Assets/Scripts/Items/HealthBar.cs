using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;

    private Transform _bar;

    void Start()
    {
        _bar = transform.Find("Bar");
    }

    void Update()
    {
        if(targetCamera != null)
        {
            transform.eulerAngles = new Vector3(0, 0, targetCamera.transform.eulerAngles.z);
        }
    }

    public void SetHealth01(float health)
    {
        health = Mathf.Clamp01(health);

        _bar.localScale = new Vector3(health, 1f);
    }
}
