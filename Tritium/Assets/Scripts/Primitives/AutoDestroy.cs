using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToDestroy = 1.0f;

    private Timer _timer;

    private void Start()
    {
        _timer = new Timer(timeToDestroy);
    }

    void Update()
    {
        _timer.AddPassedTime(Time.deltaTime);

        if(_timer.IsTimeEnd)
        {
            Destroy(this.gameObject);
        }
    }
}
