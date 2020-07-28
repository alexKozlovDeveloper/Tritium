using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorEffect : MonoBehaviour
{
    [SerializeField] private Color effectColor = Color.red;
    [SerializeField] private float effectTime = 0.4f;

    private Color defaultColor;
    //private Timer timer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultColor = spriteRenderer.color;

        //ActivateColorEffect();
        //timer = new Timer();
    }

    void Update()
    {
        //timer.AddPassedTime(Time.deltaTime);

        //if (timer.IsTimeEnd == false)
        //{
        //    var currentColor = Color.Lerp(defaultColor, effectColor, effectTime - timer.Time);

        //    spriteRenderer.color = currentColor;
        //}
    }

    private IEnumerator EffectFunc()
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

    public void ActivateColorEffect()
    {
        StartCoroutine("EffectFunc");
        //timer.ResetTime(effectTime);
    }
}
