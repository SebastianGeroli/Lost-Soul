using System.Collections;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Collector : MonoBehaviour, ICollector
{
    [SerializeField]
    private Inventory inventory;
    private PlayerController playerController;
    public UnityEvent OnCollect;
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
        Debug.Log("TEMPORAL LIST RESETED");
        inventory.temporalList = new System.Collections.Generic.List<ICollectable>();
    }
    private void OnDisable()
    {
        playerController.OnDeath.RemoveListener(ResetTemporalList);
        GoToNextLevel.GoingBackLevel -= GoToNextLevel_GoingBackLevel;
        GoToNextLevel.GoingNextLevel -= GoToNextLevel_GoingNextLevel;
    }
    private void GoToNextLevel_GoingNextLevel(int nextlevel)
    {
        inventory.AddToDictionary(nextlevel);
    }

    private void GoToNextLevel_GoingBackLevel(int nextlevel)
    {
        inventory.AddToDictionary(nextlevel);
    }

    public bool Add(ICollectable collectable)
    {
        OnCollect?.Invoke();
        inventory.AddToList(collectable);
        return true;
    }
}
