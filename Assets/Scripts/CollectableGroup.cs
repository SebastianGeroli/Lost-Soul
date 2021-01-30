using UnityEngine;

[CreateAssetMenu(fileName = "NewGroupOfCollectable", menuName = "Scriptables/Collectables/CollectableGroup")]
public class CollectableGroup : ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string groupName;
    public string Name => groupName;
    public int ID => id;
}