using UnityEngine;

[CreateAssetMenu(fileName ="NewCollectable",menuName = "Scriptables/Collectables/Collectable")]
public class CollectableSO : ScriptableObject
{
    [SerializeField]
    private CollectableGroup groupID;
    public CollectableGroup GroupID => groupID;
    private int imInScene;
    public int ImInScene { get => imInScene; set => imInScene = value; }
}
