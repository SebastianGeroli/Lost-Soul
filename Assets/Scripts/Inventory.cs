using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "newInventory", menuName = ("Scriptables/Inventory"))]
public class Inventory : ScriptableObject
{
    private Dictionary<int, List<ICollectable>> collection = new Dictionary<int, List<ICollectable>>();
    public List<ICollectable> temporalList = new List<ICollectable>();

    public void AddToDictionary(int nextLevel)
    {
        foreach (var item in temporalList)
        {
            Add(item, nextLevel);
        }
    }

    public bool IsInDictionary(CollectableSO collectableSO)
    {
        bool result = false;
        if (collection.ContainsKey(collectableSO.GroupID.ID))
        {
            foreach (var item in collection[collectableSO.GroupID.ID])
            {
                if (item.CollectableSO == collectableSO)
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }
    public bool ListContains(CollectableSO collectableSO)
    {
        bool result = false;
        foreach (var item in temporalList)
        {
            if (item.CollectableSO == collectableSO)
            {
                result = true;
                break;
            }
        }
        return result;

    }
    public void AddToList(ICollectable collectable)
    {
        if (temporalList.Contains(collectable))
        {
            return;
        }
        Debug.Log("Add to TEMPORAL LIST");
        temporalList.Add(collectable);
    }
    public bool Add(ICollectable collectable, int nextLevel)
    {
        bool success = false;
        if (collection.ContainsKey(collectable.CollectableSO.GroupID.ID))
        {
            foreach (var item in collection[collectable.CollectableSO.GroupID.ID])
            {
                if (item.CollectableSO == collectable.CollectableSO)
                {
                    Debug.Log("Not Added To dictionary");
                    return false;
                }
            }
            if (nextLevel > collectable.CollectableSO.ImInScene)
            {
                Debug.Log("Added To Dictionary");

                collection[collectable.CollectableSO.GroupID.ID].Add(collectable);
            }
            if (nextLevel == -1)
            {
                Debug.Log("Added To Dictionary");

                collection[collectable.CollectableSO.GroupID.ID].Add(collectable);
            }
        }
        else
        {
            collection.Add(collectable.CollectableSO.GroupID.ID, new List<ICollectable>());
            collection[collectable.CollectableSO.GroupID.ID].Add(collectable);
            Debug.Log("Added to Dictionary");
            success = true;
        }
        return success;
    }
}
