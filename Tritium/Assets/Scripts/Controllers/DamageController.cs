using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float damage = 20f;

    public GameObject Creator;

    public float Damage
    {
        get 
        { 
            return damage; 
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if(Creator != null)
        {
            if(collision.gameObject == Creator)
            {
                return;
            }
        }

        var healthController = collision.gameObject.GetComponent<HealthController>();

        if(healthController != null)
        {
            var teamController = Creator.GetComponent<TeamController>();

            if(teamController == null || teamController.IsEnemy(collision.gameObject)) 
            {
                healthController.MakeDamage(damage, Creator);
                Destroy(this.gameObject);
            }
        }
    }
}
