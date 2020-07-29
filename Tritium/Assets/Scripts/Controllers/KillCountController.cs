using Assets.Scripts.Core.Messenging.Entityes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class KillCountController : MonoBehaviour
{
    public Dictionary<GameObject, int> Score { get; private set; }

    void Start()
    {
        Score = new Dictionary<GameObject, int>();
    }

    private void Awake()
    {
        Messenger<StarshipDestroyInfo>.AddListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
    }

    private void OnDestroy()
    {
        Messenger<StarshipDestroyInfo>.RemoveListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
    }

    void Update()
    {
        
    }

    public void AddStarship(GameObject starship)
    {
        if (Score.Keys.Contains(starship) == false)
        {
            Score.Add(starship, 0);
        }
    }

    private void OnStarshipDestroy(StarshipDestroyInfo info)
    {
        if(Score.Keys.Contains(info.Destroyer) == false)
        {
            Score.Add(info.Destroyer, 0);
        }

        Debug.Log($"{info.Destroyer.name} kill {info.Victim.name}");

        Score[info.Destroyer]++;
    }
}
