using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float Health = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HEALTH_PACK!!!");

        var healthController = collision.gameObject.GetComponent<HealthController>();

        if(healthController != null)
        {
            healthController.Healing(Health);
            Destroy(this.gameObject);
        }        
    }
}
