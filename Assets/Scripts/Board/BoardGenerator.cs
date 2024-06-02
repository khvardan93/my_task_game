using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private Transform Parent;
    
    private Vector2 CardSpacing = new(1.2f, 1.2f);
    private LevelContainer LevelContainer;
    private CardPrefabContainer CardObject;
    private Camera MainCamera;

    private CardPool CardPool;

    private Dictionary<CardType, int> TypeList = new();
    

    private void Start()
    {
        CardObject = Core.Resources.GetCardPrefab();
        MainCamera = Camera.main;

        CardPool = new(CardObject.GetCard(), 10, Parent);

        Core.Events.OnStartLevel += StartLevel;
    }

    private void OnDestroy()
    {
        Core.Events.OnStartLevel -= StartLevel;
    }

    private void StartLevel()
    {
        LevelContainer = Core.Resources.GetLevel(Core.Data.CurrentLevel);
        
        GenerateTypeDictionary(LevelContainer.GetCardTypes());
        GenerateGrid(LevelContainer.GetGridDimentions());
    }

    private void GenerateGrid(Vector2Int gridDimensions)
    {
        Vector2 spriteSize = CardObject.GetSpriteSize();
        Vector2 gridSpacing = new Vector2
        {
            x = CardSpacing.x * spriteSize.x,
            y = CardSpacing.y * spriteSize.y
        };

        Vector2 gridSize = new Vector2
        {
            x = gridDimensions.x * gridSpacing.x,
            y = gridDimensions.y * gridSpacing.y
        };

        Vector2 offset = (gridSize - gridSpacing) * 0.5f;
        Vector3 screenSize = MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2f;

        float scale = Mathf.Min(screenSize.x / gridSize.x, screenSize.y / gridSize.y);

        Vector2Int passiveCardIndex = -Vector2Int.one;

        if (gridDimensions.x * gridDimensions.y % 2 == 1)
        {
            passiveCardIndex = (gridDimensions - Vector2Int.one) / 2;
        }

        for (int y = 0; y < gridDimensions.y; y++)
        {
            for (int x = 0; x < gridDimensions.x; x++)
            {
                if (passiveCardIndex.x == x && passiveCardIndex.y == y)
                    continue;

                Vector3 position = (Vector3)(new Vector2(x * gridSpacing.x, y * gridSpacing.y) - offset) * scale;
                AddNewCard(position, Vector3.one * scale, $"Sprite_{x}_{y}");
            }
        }
    }

    private void AddNewCard(Vector3 cardPosition, Vector3 cardScale, string cardName)
    {
        CardController newCard = CardPool.Spawn(cardPosition, Quaternion.identity, cardScale);
        
        newCard.InitCard(GetRandomCardType(), CardPool.Despawn);

        newCard.name = cardName;

        Core.Game.RegisterCard(cardName, newCard);
    }

    private void RemoveFromList(CardType type)
    {
        if (!TypeList.ContainsKey(type))
            return;
        TypeList[type]--;

        if (TypeList[type] == 0)
            TypeList.Remove(type);
    }

    private CardType GetRandomCardType()
    {
        CardType randomType = TypeList.Keys.ToList()[Random.Range(0, TypeList.Count)];

        RemoveFromList(randomType);
        
        return randomType;
    }

    private void GenerateTypeDictionary(CardType[] types)
    {
        Vector2Int dimensions = LevelContainer.GetGridDimentions();
        int cardCount = ((dimensions.x * dimensions.y) / 2) * 2;

        while (cardCount > 0)
        {
            foreach (CardType type in types)
            {
                if (TypeList.ContainsKey(type))
                {
                    TypeList[type] += 2;
                }
                else
                {
                    TypeList.Add(type, 2);
                }

                cardCount -= 2;
                if (cardCount == 0)
                    return;
            }
        }
    }
}