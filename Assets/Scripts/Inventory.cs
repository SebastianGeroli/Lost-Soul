﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName ="newInventory", menuName =("Scriptables/Inventory"))]
public class Inventory : ScriptableObject
{
    private Dictionary<int, List<ICollectable>> collection = new Dictionary<int, List<ICollectable>>();
    public List<ICollectable> temporalList = new List<ICollectable>();

    public void AddToDictionary()
    {
        foreach (var item in temporalList)
        {
            Add(item);
        }
        temporalList = new List<ICollectable>();
    }

    public bool IsInDictionary(CollectableSO collectableSO)
    {
        bool result = false;
        if (collection.ContainsKey(collectableSO.GroupID.ID))
        {
            foreach (var item in collection[collectableSO.GroupID.ID])
            {
                if (item.CollectableSO == collectableSO) {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }
    public bool  ListContains(CollectableSO collectableSO) {
        bool result = false;
        foreach (var item in temporalList)
        {
            if (item.CollectableSO == collectableSO) {
                result = true;
                break;
            }
        }
        return result;

    }
    public void AddToList(ICollectable collectable)
    {
        if (temporalList.Contains(collectable)) {
            return;
        }
        temporalList.Add(collectable);
    }
    public bool Add(ICollectable collectable)
    {
        bool success = false;
        if (collection.ContainsKey(collectable.CollectableSO.GroupID.ID))
        {
            if (collection[collectable.CollectableSO.GroupID.ID].Contains(collectable))
            {
                success = false;
            }
            else if(SceneManager.GetActiveScene().buildIndex > collectable.CollectableSO.ImInScene)
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