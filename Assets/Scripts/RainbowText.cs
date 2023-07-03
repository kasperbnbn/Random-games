using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    public float colorChangeSpeed = 1f;

    private TMP_Text textComponent;
    private float hue;

    private void Start()
    {
        textComponent = GetComponentInChildren<TMP_Text>();

        if (textComponent == null)
        {
            Debug.LogError("No TextMeshPro component found on the button or its children.");
        }
    }

    private void Update()
    {
        if (textComponent == null)
            return;

        hue += Time.deltaTime * colorChangeSpeed;
        if (hue >= 1f)
            hue -= 1f;

        Color newColor = Color.HSVToRGB(hue, 1f, 1f);
        textComponent.color = newColor;
    }
}
