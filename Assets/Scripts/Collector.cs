using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Collector : MonoBehaviour, ICollector
{
    private Dictionary<int, List<ICollectable>> collection = new Dictionary<int, List<ICollectable>>();
    public bool Add(ICollectable collectable)
    {
        bool success = false;
        if (collection.ContainsKey(collectable.CollectableSO.GroupID.ID))
        {
            if (collection[collectable.CollectableSO.GroupID.ID].Contains(collectable))
            {
                success = false;
            }
            else
            {
                collection[collectable.CollectableSO.GroupID.ID].Add(collectable);
                success = true;
            }
        }
        else
        {
            collection.Add(collectable.CollectableSO.GroupID.ID, new List<ICollectable>());
            collection[collectable.CollectableSO.GroupID.ID].Add(collectable);
            success = true;
        }
        return success;
    }
}
