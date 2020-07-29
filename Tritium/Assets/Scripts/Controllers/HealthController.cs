using Assets.Scripts.Core.Messenging.Entityes;
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

    public void MakeDamage(float damage, GameObject damageDealer)
    {
        HealthPoints -= damage;

        HealthPoints = Mathf.Clamp(HealthPoints, 0, MaxHealthPoints);

        Messenger<StarshipHitInfo>.Broadcast(GameEvent.STARSHIP_HIT, new StarshipHitInfo { Victim = this.gameObject, DamageDealer = damageDealer, Damage = damage });

        if (IsDead)
        {
            Messenger<StarshipDestroyInfo>.Broadcast(GameEvent.STARSHIP_DESTROY, new StarshipDestroyInfo { Victim = this.gameObject, Destroyer = damageDealer});
        }
    }
}
