using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSlider : MonoBehaviour
{
    float vSliderValue = 0.0f;
    GUIStyle style;

    public void Slider()
    {
        GUI.skin.verticalSlider = style;
        vSliderValue = GUILayout.VerticalSlider(vSliderValue, 0.0f, 10.0f);
    }
}
