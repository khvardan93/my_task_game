using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject SpritePrefab;
    [SerializeField] private Vector2Int GridDimentions = new (5, 5);
    [SerializeField] private Vector2 CardSpacing = new (1.0f, 1.0f);

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        Vector2 spriteSize = SpritePrefab.GetComponent<SpriteRenderer>().bounds.size;

        Vector2 gridSpacing = new Vector2
        {
            x = CardSpacing.x * spriteSize.x,
            y = CardSpacing.y * spriteSize.y
        };

        Vector2 gridSize = new Vector2
        {
            x = GridDimentions.x * gridSpacing.x,
            y = GridDimentions.y * gridSpacing.y
        };

        Vector2 offset = (gridSize - gridSpacing) * 0.5f;
        Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2;

        float scale = Mathf.Min(screenSize.x / gridSize.x, screenSize.y / gridSize.y);
        
        for (int y = 0; y < GridDimentions.y; y++)
        {
            for (int x = 0; x < GridDimentions.x; x++)
            {
                Vector3 position = (new Vector2(x * gridSpacing.x, y * gridSpacing.y) - offset) * scale;

                GameObject newSprite = Instantiate(SpritePrefab, position, Quaternion.identity, transform);

                newSprite.transform.localScale = Vector3.one * scale;
                
                newSprite.name = $"Sprite_{x}_{y}";
            }
        }
    }
}