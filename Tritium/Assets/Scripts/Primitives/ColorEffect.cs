using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorEffect : MonoBehaviour
{
    private Color defaultColor;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultColor = spriteRenderer.color;
    }

    private void OnDisable()
    {
        if (defaultColor != null && spriteRenderer != null)
        {
            spriteRenderer.color = defaultColor;
        }        
    }

    public void ActivateColorEffect(Color effectColor, float effectTime)
    {
        StartCoroutine(EffectFunc(effectColor, effectTime));        
    }

    private IEnumerator EffectFunc(Color effectColor, float effectTime)
    {
        var timer = new Timer(effectTime);

        while (timer.IsTimeEnd == false)
        {
            timer.AddPassedTime(Time.deltaTime);

            var currentColor = Color.Lerp(effectColor, defaultColor, timer.Time / effectTime);

            spriteRenderer.color = currentColor;

            yield return null;
        }

        timer.ResetTime(effectTime);

        while (timer.IsTimeEnd == false)
        {
            timer.AddPassedTime(Time.deltaTime);

            var currentColor = Color.Lerp(defaultColor, effectColor, timer.Time / effectTime);

            spriteRenderer.color = currentColor;

            yield return null;
        }
    }
}
