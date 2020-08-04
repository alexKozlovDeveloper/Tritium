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
    public float mapRadius = 5f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var offset = (target.transform.position - centerTarget.transform.position);

        transform.localPosition = offset * scale;

        //Debug.Log($"[{target.gameObject.name}] {offset.magnitude} < {mapRadius}");

        if (target.gameObject.activeSelf != true || offset.magnitude > mapRadius) 
        {
            spriteRenderer.color = spriteRenderer.color.SetAlpha(0);
        }
        else
        {
            spriteRenderer.color = spriteRenderer.color.SetAlpha(1);
        }
    }
}
