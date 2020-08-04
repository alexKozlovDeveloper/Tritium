using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private Sprite enemyPoint;
    [SerializeField] private StarshipSpawnController spawner;
    [SerializeField] private GameObject centerTarget;

    public float scale = 0.1f;
    public float mapRadius = 5f;

    private List<GameObject> points = new List<GameObject>();

    private void Awake()
    {
        Messenger.AddListener(GameEvent.MISSION_STARTED, Init);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.MISSION_STARTED, Init);
    }

    private void Init()
    {
        var starships = spawner.Starships.Select(a => a.GameObject);

        foreach (var starship in starships)
        {
            GameObject newItem = new GameObject($"MapPoint_{starship.name}");

            newItem.transform.SetParent(transform);

            var renderer = newItem.AddComponent<SpriteRenderer>();
            renderer.sprite = enemyPoint;

            var follower = newItem.AddComponent<MapPointFollower>();
            follower.target = starship;
            follower.centerTarget = centerTarget;
            follower.scale = scale;
            follower.mapRadius = mapRadius;

            newItem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            points.Add(newItem);
        }
    }
}
