using Assets.Scripts.Controllers.Entityes;
using System.Collections.Generic;
using UnityEngine;

public class StarshipSpawnController : MonoBehaviour
{
    public float spawnTime = 3f;
    public Vector2 spawnAreaSize = new Vector2(100, 100);

    private List<StarshipContainer> _starships;

    public int StarshipCount
    {
        get
        {
            return _starships.Count;
        }
    }

    public StarshipSpawnController()
    {
        _starships = new List<StarshipContainer>();
    }

    void Update()
    {
        foreach (var starship in _starships)
        {
            if (starship.Health.IsDead)
            {
                starship.Health.ResetHealth();
                starship.GameObject.SetActive(false);                
                starship.RespawnTimer.ResetTime(spawnTime);
            }
            else
            {
                if (starship.RespawnTimer.IsTimeEnd && starship.GameObject.activeSelf == false)
                {                   
                    var x = Random.Range(transform.position.x - spawnAreaSize.x / 2f, transform.position.x + spawnAreaSize.x / 2f);
                    var y = Random.Range(transform.position.y - spawnAreaSize.y / 2f, transform.position.y + spawnAreaSize.y / 2f);

                    starship.GameObject.transform.position = new Vector3(x, y, 0);

                    starship.GameObject.SetActive(true);
                }
            }

            starship.RespawnTimer.AddPassedTime(Time.deltaTime);
        }
    }

    public void AddStarship(GameObject starship, float startRespawnTime = 0f)
    {
        var container = new StarshipContainer(starship);

        container.GameObject.SetActive(false);
        container.RespawnTimer.ResetTime(startRespawnTime);

        _starships.Add(container);
    }

    public void AddStarship(IEnumerable<GameObject> starships)
    {
        foreach (var starship in starships)
        {
            AddStarship(starship);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

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
