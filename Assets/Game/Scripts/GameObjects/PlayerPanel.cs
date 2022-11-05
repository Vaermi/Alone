using TMPro;
using UnityEngine;

/// <summary>
/// Das PlayerPanel ist f�r die Visuelle Anzeige der Spielerinfos zust�ndig.
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
        //TODO Placeholder f�r Inventory Object
        textInventory.text = $"Inventory: {Inventory.Instance.InventoryCount}";
    }

}