using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    [SerializeField] private GameObject destroyAnimation;

    private void Awake()
    {
        Messenger<GameObject>.AddListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
        Messenger<GameObject>.AddListener(GameEvent.STARSHIP_HIT, OnStarshipHit);
    }

    private void OnDestroy()
    {
        Messenger<GameObject>.RemoveListener(GameEvent.STARSHIP_DESTROY, OnStarshipDestroy);
        Messenger<GameObject>.RemoveListener(GameEvent.STARSHIP_HIT, OnStarshipHit);
    }

    private void OnStarshipDestroy(GameObject target)
    {
        var anim = Instantiate(destroyAnimation);

        anim.transform.position = target.transform.position;
    }

    private void OnStarshipHit(GameObject target)
    {
        var colorEffect = target.GetComponent<ColorEffect>();

        colorEffect.ActivateColorEffect();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
