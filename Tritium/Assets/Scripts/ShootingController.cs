using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reloadTime = 0.1f;

    private Timer _timer;

    void Start()
    {
        _timer = new Timer(0);        
    }

    public void Shoot()
    {
        if (_timer.IsTimeEnd)
        {
            var newBullet = Instantiate(bullet);

            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = transform.rotation;

            newBullet.name += $"_{Guid.NewGuid()}";

            newBullet.GetComponent<DamageDealer>().Creator = this.gameObject;

            _timer.ResetTime(reloadTime);
        }
    }

    void Update()
    {
        _timer.AddPassedTime(Time.deltaTime);
    }
}
