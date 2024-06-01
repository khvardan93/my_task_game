using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int GridDimentions = new (5, 5);
    [SerializeField] private Vector2 CardSpacing = new (1.0f, 1.0f);

    private CardPrefabContainer CardObject;
    private Transform Parent;
    private Camera MainCamera;

    private Dictionary<string, CardController> Cards = new();

    private void Start()
    {
        CardObject = ResourcesManager.GetCardPrefab();
        Parent = transform;
        MainCamera = Camera.main;
        
        GenerateGrid();

        EventManager.Instance.OnClickCard += OnClickCard;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnClickCard -= OnClickCard;
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
        Vector3 screenSize = MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2f;

        float scale = Mathf.Min(screenSize.x / gridSize.x, screenSize.y / gridSize.y);
        
        for (int y = 0; y < GridDimentions.y; y++)
        {
            for (int x = 0; x < GridDimentions.x; x++)
            {
                Vector3 position = (Vector3)(new Vector2(x * gridSpacing.x, y * gridSpacing.y) - offset) * scale;
                AddNewCard(position, Vector3.one * scale, $"Sprite_{x}_{y}");
            }
        }
    }

    private void AddNewCard(Vector3 cardPosition, Vector3 cardScale, string cardName)
    {
        CardController newCard = Instantiate(CardObject.GetCard(), cardPosition, Quaternion.identity, Parent);
        newCard.InitCard((CardType)Random.Range(0, 9));
        newCard.transform.localScale = cardScale;
                
        newCard.name = cardName;
        
        Cards.Add(cardName, newCard);
    }

    private void OnClickCard(string cardName)
    {
        if (Cards.TryGetValue(cardName, out CardController card))
        {
            card.OpenCard();
        }
    }
}