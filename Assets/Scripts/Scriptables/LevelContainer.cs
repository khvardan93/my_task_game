using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelContainer")]
public class LevelContainer : ScriptableObject
{
   [SerializeField] private int LevelIndex;
   
   [SerializeField] private CardType[] CardTypes;
   [SerializeField] private Vector2Int GridDimentions;

   public Vector2Int GetGridDimentions()
   {
      return GridDimentions;
   }

   public CardType[] GetCardTypes()
   {
      return CardTypes;
   }
}