using Assets.Scripts.Core.Messenging.Entityes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    [SerializeField] private GameObject destroyAnimation;
    [SerializeField] private Color hitEffectColor = Color.red;
    [SerializeField] private Color healingEffectColor = Color.green;
    [SerializeField] private Color BoostingEffectColor = Color.green;
    [SerializeField] private float effectTime = 0.4f;

    private void Awake()
    {
        Messenger<StarshipDestroyInfo>.AddListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
        Messenger<StarshipHitInfo>.AddListener(GameEvent.STARSHIP_HIT, OnStarshipHit);
        Messenger<GameObject>.AddListener(GameEvent.STARSHIP_HEALING, OnStarshipHealing);
        Messenger<GameObject>.AddListener(GameEvent.STARSHIP_BOOST, OnStarshipBoost);
    }

    private void OnDestroy()
    {
        Messenger<StarshipDestroyInfo>.RemoveListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
        Messenger<StarshipHitInfo>.RemoveListener(GameEvent.STARSHIP_HIT, OnStarshipHit);
        Messenger<GameObject>.RemoveListener(GameEvent.STARSHIP_HEALING, OnStarshipHealing);
        Messenger<GameObject>.RemoveListener(GameEvent.STARSHIP_BOOST, OnStarshipBoost);
    }

    private void OnStarshipDestroy(StarshipDestroyInfo info)
    {
        var animation = Instantiate(destroyAnimation);

        animation.transform.position = info.Victim.transform.position;
    }

    private void OnStarshipHit(StarshipHitInfo info)
    {
        var colorEffect = info.Victim.GetComponent<ColorEffect>();

        colorEffect?.ActivateColorEffect(hitEffectColor, effectTime);
    }

    private void OnStarshipHealing(GameObject starship)
    {
        var colorEffect = starship.GetComponent<ColorEffect>();

        colorEffect?.ActivateColorEffect(healingEffectColor, effectTime);
    }

    private void OnStarshipBoost(GameObject starship)
    {
        var colorEffect = starship.GetComponent<ColorEffect>();

        colorEffect?.ActivateColorEffect(BoostingEffectColor, effectTime);
    }
}
