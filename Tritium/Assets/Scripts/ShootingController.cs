using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    void Start()
    {
        
    }

    public void Shoot()
    {
        var newBullet = Instantiate(bullet);

        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
    }

    void Update()
    {
        
    }
}
