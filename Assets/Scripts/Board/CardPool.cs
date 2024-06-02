using System.Collections.Generic;
using UnityEngine;

public class CardPool
{
    private Queue<CardController> Pool = new();
    private CardController Prefab;
    private Transform Parent;

    public CardPool(CardController prefab, int initialSize, Transform parent = null)
    {
        Prefab = prefab;
        Parent = parent;
        
        for (int i = 0; i < initialSize; i++)
        {
            CardController obj = Object.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            Pool.Enqueue(obj);
        }
    }

    public CardController Spawn(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        CardController obj = Pool.Count > 0 ? Pool.Dequeue() : Object.Instantiate(Prefab, position, rotation, Parent);

        Transform objTransform = obj.transform;
        objTransform.position = position;
        objTransform.rotation = rotation;
        objTransform.localScale = scale;

        return obj;
    }

    public void Despawn(CardController obj)
    {
        Pool.Enqueue(obj);
    }
}
