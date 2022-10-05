using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelPlayer : MonoBehaviour
{
    public Hero hero;
    private TextMeshProUGUI tm;

    private void Awake()
    {
        //TODO heroName per User Auswahl befüllen lassen
        hero.heroName = "Doris";
        hero.health = 80;
        hero.sanity = 0;
        string playerName = hero.heroName;
        int playerHealth = hero.health;
        int playerSanity = hero.sanity;
        tm = GetComponent<TextMeshProUGUI>();
        tm.text = playerName +"  " + "Health: " + playerHealth + "  " + "Sanity: " + playerSanity + "  " + "INV";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
