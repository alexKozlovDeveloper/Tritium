using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float duration = 6f;

    public GameObject boostPacticalSystemPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MovingController>() != null)
        {
            var effect = collision.gameObject.AddComponent<BoostSpeedEffect>();

            var ps = Instantiate(boostPacticalSystemPrefab);

            ps.AddComponent<AutoDestroy>().timeToDestroy = duration;
            ps.transform.SetParent(collision.gameObject.transform);
            ps.transform.localPosition = Vector3.zero;
            ps.transform.localEulerAngles = Vector3.zero;
            ps.transform.localScale = Vector3.one;

            effect.Init(speedMultiplier, duration);

            Destroy(this.gameObject);
        }
    }
}
