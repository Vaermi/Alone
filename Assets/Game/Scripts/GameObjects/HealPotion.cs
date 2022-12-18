using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public EventWindowController EventWindow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name is not "Hero") return;

        EventWindow.SetEventWindowActive();
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }



    public void DestroyObjectButton()
    {
        Destroy(gameObject);
    }

}
