using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float duration = 6f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MovingController>() != null)
        {
            var effect = collision.gameObject.AddComponent<BoostSpeedEffect>();

            effect.Init(speedMultiplier, duration);

            Destroy(this.gameObject);
        }
    }
}
