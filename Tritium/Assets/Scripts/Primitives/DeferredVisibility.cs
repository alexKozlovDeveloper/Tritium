using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DeferredVisibility : MonoBehaviour
{
    public float deferringTime = 1.0f;

    private SpriteRenderer spriteRenderer;

    private Timer timer;

    void Start()
    {
        timer = new Timer(deferringTime);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = spriteRenderer.color.SetAlpha(0);
    }

    void Update()
    {
        timer.AddPassedTime(Time.deltaTime);

        var alpha = Mathf.Lerp(0f, 1f, (deferringTime - timer.Time) / deferringTime);        

        spriteRenderer.color = spriteRenderer.color.SetAlpha(alpha);

        if (timer.IsTimeEnd)
        {
            spriteRenderer.color = spriteRenderer.color.SetAlpha(255);
            Destroy(this);
        }
    }    
}
