using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForTesting : MonoBehaviour
{
    [SerializeField] private GameObject Bar;
    void Start()
    {
        
    }

    private float health = 1f;

    void Update()
    {
        //Bar.GetComponent<HealthBar>().SetHealth01(health);

        health -= 0.01f;

        if(health <= 0)
        {
            health = 1f;
        }
    }

    private void OnDrawGizmos()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"CCC: [{gameObject.name}] x [{collision.gameObject.name}]");
    }
}
