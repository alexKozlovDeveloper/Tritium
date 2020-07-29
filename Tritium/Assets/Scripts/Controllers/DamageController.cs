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

    void Start()
    {
        
    }

    void Update()
    {
        
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
            Debug.Log($"DamageDealer: give {damage} damage to {collision.gameObject.name}");
            healthController.MakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
