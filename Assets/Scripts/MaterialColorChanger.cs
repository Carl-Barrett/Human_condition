using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialColorChanger : MonoBehaviour
{
    // Declare materials and colors
    public Material material;
    public Color[] colors;
    private int currentColorIndex = 0;

    // Declare TMP button
    public TMP_Text button;

    void Start()
    {
        // Set the initial material color to the first color in the colors array
        material.color = colors[currentColorIndex];

        // Set the button text to show the current color
        button.text = "Color: " + colors[currentColorIndex].ToString();
    }

    public void ChangeColor()
    {
        // Update the current color index to the next color in the colors array (looping back to the beginning if we've reached the end)
        currentColorIndex = (currentColorIndex + 1) % colors.Length;

        // Update the material color to the new color
        material.color = colors[currentColorIndex];

        // Update the button text to show the new color
        button.text = "Color: " + colors[currentColorIndex].ToString();
    }
}

