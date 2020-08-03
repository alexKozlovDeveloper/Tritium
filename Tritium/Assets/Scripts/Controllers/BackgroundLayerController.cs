using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private float height = 40f;
    [SerializeField] private float width = 70f;

    [SerializeField] private Vector2 countRange = new Vector2(0, 10);

    [SerializeField] private float zLevel = 24f;

    [SerializeField] private float scaleMultiplier = 4f;

    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f;

    private List<GameObject> itemsContainer;

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
        itemsContainer = new List<GameObject>();

        itemsContainer.AddRange(GenerateItems(sprites, zLevel, countRange));        
    }

    private IEnumerable<GameObject> GenerateItems(Sprite[] templates, float level, Vector2 countRange)
    {
        var result = new List<GameObject>();

        int count = Random.Range((int)countRange.x, (int)countRange.y);

        for (int i = 0; i < count; i++)
        {
            int type = Random.Range(0, templates.Length);

            var x = Random.Range(minX, maxX);
            var y = Random.Range(minY, maxY);

            GameObject newItem = new GameObject($"Item_{i}");
            SpriteRenderer renderer = newItem.AddComponent<SpriteRenderer>();
            renderer.sprite = templates[type];

            newItem.transform.position = new Vector3(x, y, level);
            newItem.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);

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