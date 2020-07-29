using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] starts;

    [SerializeField] private float height = 40f;
    [SerializeField] private float width = 70f;

    [SerializeField] private Vector2 startsCountRange = new Vector2(0, 10);

    [SerializeField] private float startsLevelZ = 24f;

    [SerializeField] private float starsScaleMultiplier = 4f;

    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f;

    private List<GameObject> stars;

    void Start()
    {
        minX = transform.position.x - width / 2f;
        maxX = transform.position.x + width / 2f;
        minY = transform.position.y - height / 2f;
        maxY = transform.position.y + height / 2f;

        GenerateBackground();
    }

    private void GenerateBackground()
    {
        stars = new List<GameObject>();

        stars.AddRange(GenerateStars(starts, startsLevelZ, startsCountRange));        
    }

    private IEnumerable<GameObject> GenerateStars(Sprite[] templates, float level, Vector2 countRange)
    {
        var result = new List<GameObject>();

        int count = (int)Random.Range(countRange.x, countRange.y);

        for (int i = 0; i < count; i++)
        {
            int type = Random.Range(0, templates.Length);

            var x = Random.Range(minX, maxX);
            var y = Random.Range(minY, maxY);

            GameObject newItem = new GameObject("Star");
            SpriteRenderer renderer = newItem.AddComponent<SpriteRenderer>();
            renderer.sprite = templates[type];

            newItem.transform.position = new Vector3(x, y, level);
            newItem.transform.localScale = new Vector3(starsScaleMultiplier, starsScaleMultiplier, starsScaleMultiplier);

            newItem.transform.SetParent(transform);

            result.Add(newItem);
        }

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector3(transform.position.x - width / 2f, transform.position.y - height / 2f, 0),
                        new Vector3(transform.position.x + width / 2f, transform.position.y - height / 2f, 0));
        Gizmos.DrawLine(new Vector3(transform.position.x - width / 2f, transform.position.y + height / 2f, 0),
                        new Vector3(transform.position.x + width / 2f, transform.position.y + height / 2f, 0));
        Gizmos.DrawLine(new Vector3(transform.position.x - width / 2f, transform.position.y - height / 2f, 0),
                        new Vector3(transform.position.x - width / 2f, transform.position.y + height / 2f, 0));
        Gizmos.DrawLine(new Vector3(transform.position.x + width / 2f, transform.position.y - height / 2f, 0),
                        new Vector3(transform.position.x + width / 2f, transform.position.y + height / 2f, 0));
    }
}