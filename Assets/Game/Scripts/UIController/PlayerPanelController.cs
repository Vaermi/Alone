using Assets.Game.Scripts.GameObjects;
using TMPro;
using UnityEngine;

/// <summary>
/// Das PlayerPanel ist für die Visuelle Anzeige der Spielerinfos zuständig.
/// </summary>

public class PlayerPanelController : MonoBehaviour
{
    public TextMeshProUGUI textHeroName;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textSanity;
    public TextMeshProUGUI textInventory;
    [SerializeField]
    private HeroService heroService = HeroService.Instance;

    private async void Start()
    {
        await heroService.Init();

        string playerName = heroService.HeroName;
        textHeroName.text = $"{playerName}";

        float playerHealth = heroService.Health;
        textHealth.text = $"Health: {playerHealth}/100";

        int playerSanity = heroService.Insanity;
        textSanity.text = $"Sanity: {playerSanity}/100";

        //TODO Placeholder für Inventory Object
        int playerInventory = Inventory.Instance.InventoryCount;
        textInventory.text = $"Inventory: {playerInventory}";
    }


    private void Awake()
    {
    }

}