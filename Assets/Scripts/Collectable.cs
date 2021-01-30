using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField]
    private CollectableSO collectable;
    public CollectableSO CollectableSO { get => collectable; }

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddToCollection(collision.gameObject);
    }
    void AddToCollection(GameObject gameObject)
    {
        bool? success = gameObject.GetComponent<ICollector>()?.Add(this);

        if (success == null)
        {
            return;
        }
        Destroy(this.gameObject);
    }
    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
