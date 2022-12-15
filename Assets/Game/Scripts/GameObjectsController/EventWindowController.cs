using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventWindowController : MonoBehaviour
{
    public TextMeshProUGUI HealPotionText;
    public GameObject EventWindow;
    private HealPotion potion;

    private void Start()
    {
        
        var potion = GameObject.Find("HealPotion").GetComponent<HealPotion>();

        if (gameObject.activeSelf)
        {
            AddHealPotion();
            Debug.Log("Add Healpotion");
        }
    }

    public void SetEventWindowActive()
    {
        EventWindow.SetActive(true);
        Debug.Log("Eventtext Activatet");
    }


    public void DeactivateEventWindow()
    {
        EventWindow.SetActive(false);
        Debug.Log("Eventtext Deactivatet");
    }


    public void AddHealPotionText(int number)
    {
        int hpText = number;
        HealPotionText.text = $"+ {hpText}";
    }

    public void AddHealPotion()
    {
        int number = UnityEngine.Random.Range(1, 5);
        HeroService.Instance.AddHealPotionToInventory(number);
        AddHealPotionText(number);
    }
}
