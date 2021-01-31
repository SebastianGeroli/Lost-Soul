using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    public static HUD instance;
    [SerializeField]
    private TextMeshProUGUI text;
    private void Start()
    {
        inventory.soulsUpdated += Inventory_soulsUpdated;
        text.text = "0";

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (inventory != this) {
            Destroy(gameObject);
        }
    }

    private void Inventory_soulsUpdated(int souls)
    {
        text.text = souls.ToString();
    }
}
