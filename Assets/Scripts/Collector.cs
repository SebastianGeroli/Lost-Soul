using System.Collections;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Collector : MonoBehaviour, ICollector
{
    [SerializeField]
    private Inventory inventory;
    private PlayerController playerController;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void OnEnable()
    {
        GoToNextLevel.GoingBackLevel += GoToNextLevel_GoingBackLevel;
        GoToNextLevel.GoingNextLevel += GoToNextLevel_GoingNextLevel;
        playerController.OnDeath.AddListener(ResetTemporalList);
    }
    private void ResetTemporalList()
    {
        inventory.temporalList = new System.Collections.Generic.List<ICollectable>();
    }
    private void OnDisable()
    {
        playerController.OnDeath.RemoveListener(ResetTemporalList);
        GoToNextLevel.GoingBackLevel -= GoToNextLevel_GoingBackLevel;
        GoToNextLevel.GoingNextLevel -= GoToNextLevel_GoingNextLevel;
    }
    private void GoToNextLevel_GoingNextLevel()
    {
        inventory.AddToDictionary();
    }

    private void GoToNextLevel_GoingBackLevel()
    {
        inventory.AddToDictionary();
    }

    public bool Add(ICollectable collectable)
    {
        inventory.AddToList(collectable);
        return true;
    }
}
