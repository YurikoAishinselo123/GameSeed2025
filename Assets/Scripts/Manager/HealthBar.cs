using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI Slider component for health
    public Gradient healthGradient; // Gradient for health bar color 
    public Image fillImage; // Reference to the Image component of the slider fill

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health; // Set the maximum value of the slider
        healthSlider.value = health; // Initialize the slider value to the maximum health

        fillImage.color = healthGradient.Evaluate(1f); // Set the gradient to full health color
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health; // Update the slider value to reflect current health

        fillImage.color = healthGradient.Evaluate(healthSlider.normalizedValue); // Update the fill color based on current health
    }
}
