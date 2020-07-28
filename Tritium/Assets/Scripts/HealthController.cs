using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float MaxHealthPoints = 100f;
    [SerializeField] private GameObject deathAnimation;

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

    void LateUpdate()
    {
        if (IsDead)
        {
            if(deathAnimation != null)
            {
                var deathItem = Instantiate(deathAnimation);

                deathItem.transform.position = transform.position;
            }

            Destroy(this.gameObject);
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

        gameObject.SendMessage("ActivateColorEffect", SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"AAA: [{this.gameObject.name}] x [{collision.gameObject.name}]");
    }
}
