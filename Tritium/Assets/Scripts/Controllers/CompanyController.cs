using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyController : MonoBehaviour
{
    [SerializeField] private StarshipSpawnController starshipSpawnController;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject hero;

    [SerializeField] private KillCountController killCountController;

    public float starshipCount = 10;
    public float deathmatchTime = 200f;

    private Timer _timer;

    void Start()
    {
        _timer = new Timer(deathmatchTime);

        if (starshipSpawnController == null)
        {
            return;
        }

        starshipSpawnController.AddStarship(hero);
        killCountController?.AddStarship(hero);

        while (starshipSpawnController.StarshipCount < starshipCount)
        {
            var enemy = Instantiate(enemyPrefab);

            enemy.name = "Bot_" + NameHelper.GetRandomName();

            enemy.transform.SetParent(transform);

            starshipSpawnController.AddStarship(enemy, Random.Range(0.9f, 2.4f));
            killCountController?.AddStarship(enemy);
        }
    }

    void Update()
    {
        _timer.AddPassedTime(Time.deltaTime);
    }
}
