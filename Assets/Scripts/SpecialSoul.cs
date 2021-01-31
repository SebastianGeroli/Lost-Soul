using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSoul : MonoBehaviour
{
    const string bad = "003C08";
    const string good = "00FF23";
    const int r = 0 ,g = 255, b = 34 ;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Inventory inventory;
    private void Start()
    {
        if (inventory.Collection[0].Count == 12) {
            Color color = new Color(0, 255, 34,1);
            spriteRenderer.color = color;
        }
    }
}
