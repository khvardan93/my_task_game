using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int GridDimentions = new (5, 5);
    [SerializeField] private Vector2 CardSpacing = new (1.0f, 1.0f);

    private CardPrefabContainer CardObject;
    
    private void Start()
    {
        CardObject = Resources.Load<CardPrefabContainer>("Prefabs/CardPrefab");
        
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        Vector2 spriteSize = CardObject.GetSpriteSize();
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
        Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2f;

        float scale = Mathf.Min(screenSize.x / gridSize.x, screenSize.y / gridSize.y);
        
        for (int y = 0; y < GridDimentions.y; y++)
        {
            for (int x = 0; x < GridDimentions.x; x++)
            {
                Vector3 position = (new Vector2(x * gridSpacing.x, y * gridSpacing.y) - offset) * scale;

                CardController newCard = Instantiate(CardObject.GetCard(), position, Quaternion.identity, transform);
                newCard.SetType((CardType)Random.Range(0, 9));
                newCard.transform.localScale = Vector3.one * scale;
                
                newCard.name = $"Sprite_{x}_{y}";
            }
        }
    }
}