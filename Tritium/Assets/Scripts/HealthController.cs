using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float MaxHealthPoints = 100f;

    public float HealthPoints { get; private set; }

    public bool IsDead
    {
        get
        {
            return HealthPoints <= 0f;
        }
    }

    void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        HealthPoints = MaxHealthPoints;
    }

    public void SetHealth(float healthPoints)
    {
        HealthPoints = Mathf.Clamp(healthPoints, 0, MaxHealthPoints);
    }

    public void MakeDamage(float damage)
    {
        HealthPoints -= damage;

        HealthPoints = Mathf.Clamp(HealthPoints, 0, MaxHealthPoints);

        Messenger<GameObject>.Broadcast(GameEvent.STARSHIP_HIT, gameObject);

        if (IsDead)
        {
            Messenger<GameObject>.Broadcast(GameEvent.STARSHIP_DESTROY, gameObject);
        }
    }
}
