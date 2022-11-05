using TMPro;
using UnityEngine;

/// <summary>
/// Das PlayerPanel ist für die Visuelle Anzeige der Spielerinfos zuständig.
/// </summary>

public class PlayerPanel : MonoBehaviour
{
    public TextMeshProUGUI textHeroName;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textSanity;
    public TextMeshProUGUI textInventory;
    private Hero hero;


    private void Awake()
    {
        string heroName = hero.GetHeroName();
        textHeroName.text = $"{heroName}";
        textHealth.text = $"Health: {hero.GetHealth()}/100";
        textSanity.text = $"Sanity: {hero.GetInsanity()}/100";
        //TODO Placeholder für Inventory Object
        textInventory.text = $"Inventory: {Inventory.Instance.InventoryCount}";
    }

}