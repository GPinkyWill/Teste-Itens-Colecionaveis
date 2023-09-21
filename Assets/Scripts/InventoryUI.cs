using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI seedText;
    // Start is called before the first frame update
    void Start()
    {
        seedText = GetComponent<TextMeshProUGUI>();
    }

    
    private void UpdateSeedText(PlayerInventory playerInventory)
    {
        seedText.text = playerInventory.numberOfSeeds.ToString();
    }
}
