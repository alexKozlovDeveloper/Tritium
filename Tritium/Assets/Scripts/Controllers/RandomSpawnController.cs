using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(200, 200);
    [SerializeField] private float spawnFrequency = 1f;

    [SerializeField] private Color GizmosColor = Color.green;

    private Timer _timer;

    void Start()
    {
        _timer = new Timer(spawnFrequency);
    }

    void Update()
    {
        if(ItemPrefab == null)
        {
            return;
        }

        _timer.AddPassedTime(Time.deltaTime);

        if (_timer.IsTimeEnd)
        {
            _timer.ResetTime(spawnFrequency);

            var x = UnityEngine.Random.Range(transform.position.x - spawnAreaSize.x / 2f, transform.position.x + spawnAreaSize.x / 2f);
            var y = UnityEngine.Random.Range(transform.position.y - spawnAreaSize.y / 2f, transform.position.y + spawnAreaSize.y / 2f);

            var newEnemy = Instantiate(ItemPrefab);

            newEnemy.transform.position = new Vector3(x, y, 0);

            newEnemy.name += $"_{Guid.NewGuid()}";
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;

        Gizmos.DrawLine(new Vector3(transform.position.x - spawnAreaSize.x / 2f, transform.position.y - spawnAreaSize.y / 2f, 0),
                        new Vector3(transform.position.x + spawnAreaSize.x / 2f, transform.position.y - spawnAreaSize.y / 2f, 0));
        Gizmos.DrawLine(new Vector3(transform.position.x - spawnAreaSize.x / 2f, transform.position.y + spawnAreaSize.y / 2f, 0),
                        new Vector3(transform.position.x + spawnAreaSize.x / 2f, transform.position.y + spawnAreaSize.y / 2f, 0));
        Gizmos.DrawLine(new Vector3(transform.position.x - spawnAreaSize.x / 2f, transform.position.y - spawnAreaSize.y / 2f, 0),
                        new Vector3(transform.position.x - spawnAreaSize.x / 2f, transform.position.y + spawnAreaSize.y / 2f, 0));
        Gizmos.DrawLine(new Vector3(transform.position.x + spawnAreaSize.x / 2f, transform.position.y - spawnAreaSize.y / 2f, 0),
                        new Vector3(transform.position.x + spawnAreaSize.x / 2f, transform.position.y + spawnAreaSize.y / 2f, 0));
    }
}
