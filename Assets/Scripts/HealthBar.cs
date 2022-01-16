using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image healthSlider;

    public void UpdateHealth(float fraction)
    {
        healthSlider.fillAmount = fraction;
    }
}
