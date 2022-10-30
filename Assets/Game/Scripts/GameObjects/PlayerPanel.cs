using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Das PlayerPanel ist für die Visuelle Anzeige der Spielerinfos zuständig.
/// </summary>

public class PlayerPanel : MonoBehaviour
{
    public Hero hero;
    public TextMeshProUGUI textHeroName;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textSanity;
    public TextMeshProUGUI textInventory;

    private void Awake()
    {
        //TODO heroName per User Auswahl befüllen lassen
        
        string playerName = hero.HeroName;
        textHeroName.text = $"{playerName} ";

        int playerHealth = hero.Health;
        textHealth.text = $"Health: {playerHealth}/100";

        int playerSanity = hero.Insanity;
        textSanity.text = $"Sanity: {playerSanity}/100";

        //TODO Placeholder für Inventory Object
        int playerInventory = Inventory.Instance.InventoryCount;
        textInventory.text = $"Inventory: {playerInventory}";

    }
    
}
