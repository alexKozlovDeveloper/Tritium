using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeedEffect : MonoBehaviour
{
    public void Init(float speedMultiplier, float duration)
    {
        StartCoroutine(Effect(speedMultiplier, duration));
    }

    private IEnumerator Effect(float speedMultiplier, float duration)
    {
        var movingController = GetComponent<MovingController>();

        movingController.movingSpeed *= speedMultiplier;
        movingController.rotationSpeed *= speedMultiplier;

        Messenger<GameObject>.Broadcast(GameEvent.STARSHIP_BOOST, this.gameObject);

        yield return new WaitForSeconds(duration);

        movingController.movingSpeed /= speedMultiplier;
        movingController.rotationSpeed /= speedMultiplier;

        Destroy(this);
    }
}
