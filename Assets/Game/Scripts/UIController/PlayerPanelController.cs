using Assets.Game.Scripts.GameObjects;
using TMPro;
using UnityEngine;

public class PlayerPanelController : MonoBehaviour
{
    public TextMeshProUGUI textHeroName;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textSanity;
    public TextMeshProUGUI textLevel;
    [SerializeField]
    private HeroService heroService = HeroService.Instance;

    private async void Start()
    {
        await heroService.Init();
        UpdatePanel();

    }


    public void UpdatePanel()
    {
        string playerName = heroService.HeroName;
        textHeroName.text = $"{playerName}";

        float playerHealth = heroService.Health;
        textHealth.text = $"Leben: {playerHealth}/100";

        int playerSanity = heroService.Insanity;
        textSanity.text = $"Verrückt: {playerSanity}/100";

        int playerLevel = heroService.Level;
        textLevel.text = $"Level: {playerLevel}";

    }

}