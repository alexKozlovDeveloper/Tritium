using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MapPointFollower : MonoBehaviour
{
    public GameObject target;
    public GameObject centerTarget;
    public float scale = 1f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.localPosition = (target.transform.position - centerTarget.transform.position) * scale;

        if (target.gameObject.activeSelf == true) 
        {
            spriteRenderer.color = spriteRenderer.color.SetAlpha(1);
        }
        else
        {
            spriteRenderer.color = spriteRenderer.color.SetAlpha(0);
        }
    }
}
