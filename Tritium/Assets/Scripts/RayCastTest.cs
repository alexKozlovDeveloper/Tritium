using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    [SerializeField] private float radius = 20f;

    //private float angle = 0f;

    void Start()
    {
        
    }

    void Update()
    {
       // angle += 1f;

       // Debug.Log($"angle: '{angle}', vector: '{VectorHelper.DegreeToVector2(angle + 90f)}'");

        var result = Physics2D.CircleCast(transform.position.ToVector2(), radius, Vector2.up);

        if(result.collider != null)
        {
           // Debug.Log($"Hit object '{result.collider.gameObject.name}' layer '{LayerMask.LayerToName(result.collider.gameObject.layer)}'");
        }

        var result2 = Physics2D.BoxCast(transform.position.ToVector2(), new Vector2(3, 10), 0, Vector2.up, 10f);

        if (result2.collider != null)
        {
            //Debug.Log($"Hit object '{result.collider.gameObject.name}' layer '{LayerMask.LayerToName(result.collider.gameObject.layer)}'");
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;

        //Gizmos.DrawSphere(transform.position, radius);
        

    }
}
