using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyController : MonoBehaviour
{
    [SerializeField] private StarshipSpawnController starshipSpawnController;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject hero;

    public float starshipCount = 10;

    void Start()
    {
        if(starshipSpawnController == null)
        {
            return;
        }
        
        //var hero = Instantiate(heroPrefab);

        //hero.transform.SetParent(transform);

        starshipSpawnController.AddStarship(hero);

        while(starshipSpawnController.StarshipCount < starshipCount)
        {
            var enemy = Instantiate(enemyPrefab);

            enemy.transform.SetParent(transform);

            starshipSpawnController.AddStarship(enemy);
        }
    }

    void Update()
    {
        
    }
}
