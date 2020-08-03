using Assets.Scripts.Core.Messenging.Entityes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    [SerializeField] private GameObject destroyAnimation;

    private void Awake()
    {
        Messenger<StarshipDestroyInfo>.AddListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
        Messenger<StarshipHitInfo>.AddListener(GameEvent.STARSHIP_HIT, OnStarshipHit);
    }

    private void OnDestroy()
    {
        Messenger<StarshipDestroyInfo>.RemoveListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
        Messenger<StarshipHitInfo>.RemoveListener(GameEvent.STARSHIP_HIT, OnStarshipHit);
    }

    private void OnStarshipDestroy(StarshipDestroyInfo info)
    {
        var animation = Instantiate(destroyAnimation);

        animation.transform.position = info.Victim.transform.position;
    }

    private void OnStarshipHit(StarshipHitInfo info)
    {
        var colorEffect = info.Victim.GetComponent<ColorEffect>();

        colorEffect?.ActivateColorEffect();
    }
}
