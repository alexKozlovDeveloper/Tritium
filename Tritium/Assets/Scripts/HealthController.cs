using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float HealthPoints = 100f;

    public bool IsDead
    {
        get
        {
            return HealthPoints <= 0f;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (IsDead)
        {
            Destroy(this.gameObject);
        }
    }

    public void MakeDamage(float damage)
    {
        HealthPoints -= damage;

        Debug.Log($"[{this.gameObject.name}] HP: {HealthPoints}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"AAA: [{this.gameObject.name}] x [{collision.gameObject.name}]");
    }
}
