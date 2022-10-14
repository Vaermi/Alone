using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    public Hero hero;
    public TextMeshProUGUI textHeroName;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textSanity;
    public TextMeshProUGUI textInventory;

    private void Awake()
    {
        //TODO heroName per User Auswahl bef�llen lassen
        
        string playerName = hero.HeroName;
        textHeroName.text = $"{playerName} ";

        int playerHealth = hero.Health;
        textHealth.text = $"Health: {playerHealth}/100";

        int playerSanity = hero.Insanity;
        textSanity.text = $"Sanity: {playerSanity}/100";

        //TODO Placeholder f�r Inventory Object
        int playerInventory = hero.Inventory;
        textInventory.text = $"Inventory: {playerInventory}";

    }
    
}
