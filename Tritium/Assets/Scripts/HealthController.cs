using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float MaxHealthPoints = 100f;

    private float healthPoints;

    public bool IsDead
    {
        get
        {
            return healthPoints <= 0f;
        }
    }

    void Start()
    {
        healthPoints = MaxHealthPoints;
    }

    void Update()
    {
        if (IsDead)
        {
            //Destroy(this.gameObject);
        }
    }

    public void MakeDamage(float damage)
    {
        healthPoints -= damage;

        Debug.Log($"[{this.gameObject.name}] HP: {healthPoints}");

        if(healthBar != null)
        {
            healthBar.SetHealth01(healthPoints / MaxHealthPoints);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"AAA: [{this.gameObject.name}] x [{collision.gameObject.name}]");
    }
}
