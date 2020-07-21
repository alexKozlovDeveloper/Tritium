using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToDestroy = 1.0f;

    private float liveTime = 0;

    void Update()
    {
        liveTime += Time.deltaTime;

        if(liveTime >= timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
