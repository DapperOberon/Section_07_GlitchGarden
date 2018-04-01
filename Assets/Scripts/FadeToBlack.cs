using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{

    public float fadeTime;
    private Image panel;
    private Color currentColor = Color.black;

    private void Start()
    {
        panel = GetComponent<Image>();
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad < fadeTime)
        {
            panel.CrossFadeAlpha(0f, fadeTime, false);
        } else
        {
            panel.enabled = false;
        }
    }
}
