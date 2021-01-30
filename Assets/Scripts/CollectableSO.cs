using UnityEngine;

[CreateAssetMenu(fileName ="NewCollectable",menuName = "Scriptables/Collectables/Collectable")]
public class CollectableSO : ScriptableObject
{
    [SerializeField]
    private CollectableGroup groupID;
    public CollectableGroup GroupID => groupID;
}
