using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelPlayer : MonoBehaviour
{
    public Hero hero;
    // Start is called before the first frame update
    void Start()
    {
        var textComponent = GetComponent<TextMeshPro>();

        string playerName = hero.heroName;
        textComponent.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
